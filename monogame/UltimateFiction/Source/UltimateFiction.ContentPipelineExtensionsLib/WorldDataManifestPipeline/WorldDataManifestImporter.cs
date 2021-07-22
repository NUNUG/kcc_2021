using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace UltimateFiction.ContentPipelineExtensionsLib.WorldDataManifestPipeline
{
	[ContentImporter(".txt", DefaultProcessor = "WorldDataManifestProcessor", DisplayName = "WorldDataManifest Importer - Ultimate Fiction")]
	public class WorldDataManifestImporter : ContentImporter<WorldDataManifest>
	{
		protected bool IsHeader(string line)
		{
			string trimmed = line.Trim();
			bool isheader = trimmed.StartsWith("[") && trimmed.EndsWith("]");
			return isheader;
		}

		protected string SectionFromHeader(string headerLine)
		{
			string sectionName = headerLine
				.Trim()
				.Replace("[", "")
				.Replace("]", "");
			return sectionName;
		}


		public override WorldDataManifest Import(string filename, ContentImporterContext context)
		{
			var lines = File.ReadAllLines(filename)
				.Select((s, i) => ((int LineNumber, string Content))(i, s))	// preserve line numbers for error logging.
				.Where(line => !(line.Content.Trim().StartsWith("#")))
				.Where(line => !(string.IsNullOrEmpty(line.Content.Trim())));

			string section = "";

			Action<string, string, WorldDataManifest> TeleportLoadAction = (line, headerName, manifest) => { manifest.Teleports.Add(WorldDataManifest.Teleport.Parse(line)); };
			Action<string, string, WorldDataManifest> NpcInterctionLoadAction = (line, headerName, manifest) => { manifest.NpcInteractions.Add(WorldDataManifest.NpcInteraction.Parse(line)); };
			Action<string, string, WorldDataManifest> PortLoadAction = (line, headerName, manifest) => { manifest.Ports.Add(WorldDataManifest.Port.Parse(line)); };
			Action<string, string, WorldDataManifest> ShopLoadAction = (line, headerName, manifest) => { manifest.Shops.Add(WorldDataManifest.Shop.Parse(line)); };
			Action<string, string, WorldDataManifest> TriggerLoadAction = (line, headerName, manifest) => { manifest.Triggers.Add(WorldDataManifest.Trigger.Parse(line)); };
			Action<string, string, WorldDataManifest> TreasureLoadAction = (line, headerName, manifest) => { manifest.Treasures.Add(WorldDataManifest.Treasure.Parse(line)); };
			Action<string, string, WorldDataManifest> BattleLoadAction = (line, headerName, manifest) => { manifest.Battles.Add(WorldDataManifest.Battle.Parse(line)); };
			Action<string, string, WorldDataManifest> ResumePointLoadAction = (line, headerName, manifest) => { manifest.ResumePoints.Add(WorldDataManifest.ResumePoint.Parse(line)); };

			Action<string, string, WorldDataManifest> currentAction = null;
			WorldDataManifest result = new WorldDataManifest();
			int lineNumber = -1;
			foreach (var line in lines)
			{
				lineNumber++;
				try
				{
					if (IsHeader(line.Content))
					{
						section = SectionFromHeader(line.Content).ToLower();
						if (section == "teleports") currentAction = TeleportLoadAction;
						else if (section == "npc interactions") currentAction = NpcInterctionLoadAction;
						else if (section == "ports") currentAction = PortLoadAction;
						else if (section == "shops") currentAction = ShopLoadAction;
						else if (section == "triggers") currentAction = TriggerLoadAction;
						else if (section == "treasures") currentAction = TreasureLoadAction;
						else if (section == "battles") currentAction = BattleLoadAction;
						else if (section == "resume points") currentAction = ResumePointLoadAction;
					}
					else
						currentAction?.Invoke(line.Content, section, result);
				}
				catch (Exception ex)
				{
					throw new Exception($"Error processing line #{line.LineNumber} with content: {line.Content}", ex);
				}
			}

			return result;
		}
	}
}
