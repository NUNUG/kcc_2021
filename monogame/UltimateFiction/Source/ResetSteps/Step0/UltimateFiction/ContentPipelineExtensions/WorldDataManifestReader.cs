using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using UltimateFiction.Data;
using UltimateFiction.Sprites;

namespace UltimateFiction.ContentPipelineExtensions
{
	public class WorldDataManifestReader : ContentTypeReader<WorldData>
	{

		protected bool IsHeader(string line)
		{
			return line.StartsWith("header_");
		}

		protected string SectionFromHeader(string headerLine)
		{
			if (!headerLine.Contains("_"))
				throw new Exception($"Invalid header line {headerLine} importing WorldDataManifest.");
			string section = headerLine.Split("_", StringSplitOptions.None)[1];
			return section;
		}

		protected static string Unsurround(string text, string leftSurround, string rightSurround)
		{
			if (text.StartsWith(leftSurround) && text.EndsWith(rightSurround))
				return text.Substring(leftSurround.Length, text.Length - leftSurround.Length - rightSurround.Length);
			return text;

		}
		protected static string Unquote(string text)
		{
			return Unsurround(text, "\"", "\"");
		}

		protected static (string key, string value) KeyValue(string text, string delimiter, out string key, out string value, string defaultValue = "", string defaultKey = "")
		{
			string[] parts = text.Split(new string[] { delimiter }, StringSplitOptions.None);

			key = defaultKey;
			value = defaultValue;

			if (parts.Length >= 1)
				key = parts[0];
			if (parts.Length >= 2)
				value = parts[1];

			return (key, value);
		}

		public static WorldData.MapCoord ParseMapCoord(string text)
		{
			KeyValue(text, "(", out string map, out string coordsText);
			var coords = ParseCoord(coordsText);
			return new WorldData.MapCoord(map.Trim(), coords.XTile, coords.YTile);
		}

		protected static (int XTile, int YTile) ParseCoord(string text)
		{
			string s = text
				.Replace(" ", "")
				.Replace("(", "")
				.Replace(")", "");
			KeyValue(s, ",", out string xtext, out string ytext);

			if (!int.TryParse(xtext, out int x))
				throw new Exception($"Error parsing x-coord in manifest: '{text}'");
			if (!int.TryParse(ytext, out int y))
				throw new Exception($"Error parsing y-coord in manifest: '{text}'");

			return (x, y);
		}

		public static WorldData.Teleport ParseTeleport(string text)
		{
			KeyValue(text, ":", out string sourceText, out string targetText);

			var result = new WorldData.Teleport();
			result.SourceMapCoord = ParseMapCoord(sourceText);
			result.TargetMapCoord = ParseMapCoord(targetText);
			return result;
		}

		public static WorldData.NpcInteraction ParseNpcInteraction(string text)
		{
			KeyValue(text, ":", out string mapCoordText, out string theRestText);
			KeyValue(theRestText, ";", out string spriteDataText, out string dialogText);

			var spriteParts = spriteDataText.Split(",", StringSplitOptions.None).Select(s => s.Trim()).ToList();
			if (spriteParts.Count != 3)
				throw new Exception($"Error parsing NPC Interaction: {text}");
			int spriteRow = int.Parse(spriteParts[0]);
			int spriteCol = int.Parse(spriteParts[1]);
			int spriteFrameCount = int.Parse(spriteParts[2]);

			var result = new WorldData.NpcInteraction(
				ParseMapCoord(mapCoordText),
				spriteRow,
				spriteCol,
				spriteFrameCount,
				Unquote(dialogText.Trim()));
			return result;
		}

		public static WorldData.Port ParsePort(string text)
		{
			return new WorldData.Port(ParseMapCoord(text));
		}

		public static WorldData.Shop ParseShop(string text)
		{
			KeyValue(text, ":", out string mapCoordText, out string shopNameText);
			var result = new WorldData.Shop(ParseMapCoord(mapCoordText), Unquote(shopNameText.Trim()));
			return result;
		}

		public static WorldData.Trigger ParseTrigger(string text)
		{
			KeyValue(text, ":", out string mapCoordText, out string actionName);
			var result = new WorldData.Trigger(ParseMapCoord(mapCoordText), Unquote(actionName.Trim()));
			return result;
		}

		public static WorldData.Treasure ParseTreasure(string text)
		{
			KeyValue(text, ":", out string mapCoordText, out string theRestText);
			KeyValue(theRestText, ",", out string treasureName, out string quantityText);

			var mapCoord = ParseMapCoord(mapCoordText);
			int quantity = int.Parse(quantityText);

			var result = new WorldData.Treasure(mapCoord, Unquote(treasureName.Trim()), quantity);
			return result;
		}

		public static WorldData.Battle ParseBattle(string text)
		{
			KeyValue(text, ":", out string mapCoordText, out string battleName);
			var result = new WorldData.Battle(ParseMapCoord(mapCoordText), Unquote(battleName.Trim()));
			return result;
		}

		public static WorldData.ResumePoint ParseResumePoint(string text)
		{
			KeyValue(text, ":", out string innName, out string mapCoordText);
			var result = new WorldData.ResumePoint(ParseMapCoord(mapCoordText), Unquote(innName.Trim()));
			return result;
		}


		protected override WorldData Read(ContentReader input, WorldData existingInstance)
		{
			WorldData result = new WorldData();
			string section = "";

			Action<string, string, WorldData> TeleportLoadAction = (line, headerName, worldData) => { worldData.Teleports.Add(ParseTeleport(line)); };
			Action<string, string, WorldData> NpcInterctionLoadAction = (line, headerName, worldData) => { worldData.NpcInteractions.Add(ParseNpcInteraction(line)); };
			Action<string, string, WorldData> PortLoadAction = (line, headerName, worldData) => { worldData.Ports.Add(ParsePort(line)); };
			Action<string, string, WorldData> ShopLoadAction = (line, headerName, worldData) => { worldData.Shops.Add(ParseShop(line)); };
			Action<string, string, WorldData> TriggerLoadAction = (line, headerName, worldData) => { worldData.Triggers.Add(ParseTrigger(line)); };
			Action<string, string, WorldData> TreasureLoadAction = (line, headerName, worldData) => { worldData.Treasures.Add(ParseTreasure(line)); };
			Action<string, string, WorldData> BattleLoadAction = (line, headerName, worldData) => { worldData.Battles.Add(ParseBattle(line)); };
			Action<string, string, WorldData> ResumePointLoadAction = (line, headerName, worldData) => { worldData.ResumePoints.Add(ParseResumePoint(line)); };

			int linesToRead = input.ReadInt32();

			Action<string, string, WorldData> currentAction = null;


			for (int lineNumber = 0; lineNumber < linesToRead; lineNumber++)
			{
				var line = input.ReadString();

				if (IsHeader(line))
				{
					section = SectionFromHeader(line);
					if (section == "teleports") currentAction = TeleportLoadAction;
					else if (section == "npcinteractions") currentAction = NpcInterctionLoadAction;
					else if (section == "ports") currentAction = PortLoadAction;
					else if (section == "shops") currentAction = ShopLoadAction;
					else if (section == "triggers") currentAction = TriggerLoadAction;
					else if (section == "treasures") currentAction = TreasureLoadAction;
					else if (section == "battles") currentAction = BattleLoadAction;
					else if (section == "resumepoints") currentAction = ResumePointLoadAction;
				}
				else
					currentAction?.Invoke(line, section, result);
			}

			return result;

		}
	}
}
