using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Shops;

namespace UltimateFiction.Data
{
	public class WorldData
	{
		public class MapCoord
		{
			public string Map { get; set; }
			public int XTile { get; set; }
			public int YTile { get; set; }

			public (string Map, (int XTile, int YTile) Coord) AsTuple => (this.Map, (this.XTile, this.YTile));
			public (int XTile, int YTile) Coord => (this.XTile, this.YTile);

			public MapCoord(string map, int xTile, int yTile)
			{
				this.Map = map;
				this.XTile = xTile;
				this.YTile = yTile;
			}

			public MapCoord((string Map, (int XTile, int YTile) Coord) value)
			{
				this.Map = value.Map;
				this.XTile = value.Coord.XTile;
				this.YTile = value.Coord.YTile;
			}

			public MapCoord(MapCoord value)
			{
				this.Map = value.Map;
				this.XTile = value.Coord.XTile;
				this.YTile = value.Coord.YTile;
			}

			public static MapCoord Parse(string text)
			{
				KeyValue(text, "(", out string map, out string coordsText);
				var coords = ParseCoord(coordsText);
				return new MapCoord(map, coords.XTile, coords.YTile);
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

			public override string ToString()
			{
				return $"{Map}({XTile}, {YTile})";
			}
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

		public class Teleport
		{
			public Teleport() { }
			public Teleport(MapCoord sourceMapCoord, MapCoord targetMapCoord)
			{
				this.SourceMapCoord = sourceMapCoord;
				this.TargetMapCoord = targetMapCoord;
			}

			public MapCoord SourceMapCoord { get; set; }
			public MapCoord TargetMapCoord { get; set; }

			public override string ToString()
			{
				return $"{SourceMapCoord}:{TargetMapCoord}";
			}
		}

		public class NpcInteraction
		{
			public NpcInteraction() { }
			public NpcInteraction(MapCoord mapCoord, int spriteRow, int spriteCol, int spriteFrameCount, string dialogText)
			{
				this.MapCoord = mapCoord;
				this.SpriteRow = spriteRow;
				this.SpriteCol = spriteCol;
				this.SpriteFrameCount = spriteFrameCount;
				this.DialogText = dialogText;
			}

			public MapCoord MapCoord { get; set; }
			public int SpriteRow { get; set; }
			public int SpriteCol { get; set; }
			public int SpriteFrameCount { get; set; }
			public string DialogText { get; set; }

			public override string ToString()
			{
				return $"{MapCoord}: {SpriteRow}, {SpriteCol}, {SpriteFrameCount}; \"{DialogText}\"";
			}
		}

		public class Port
		{
			public Port() { }
			public Port(MapCoord mapCoord)
			{
				this.MapCoord = mapCoord;
			}

			public MapCoord MapCoord { get; set; }

			public override string ToString()
			{
				return MapCoord.ToString();
			}
		}

		public class Shop
		{
			public Shop() { }
			public Shop(MapCoord mapCoord, string name)
			{
				this.MapCoord = mapCoord;
				this.ShopName = name;
			}

			public MapCoord MapCoord { get; set; }
			public string ShopName;
			public string ShopTypeName => ShopName.Split("_", StringSplitOptions.None).Last();
			public ShopType ShopType =>
				ShopTypeName == "whitemagic" ? ShopType.WhiteMagic
					: ShopTypeName == "blackmagic" ? ShopType.BlackMagic
						: ShopTypeName == "clinic" ? ShopType.Clinic
							: ShopTypeName == "item" ? ShopType.Item
								: ShopTypeName == "weapon" ? ShopType.Weapon
									: ShopTypeName == "armor" ? ShopType.Armor
										: ShopTypeName == "inn" ? ShopType.Inn
											: throw new Exception($"Unsupported shop type ({ShopTypeName}).");

			public override string ToString()
			{
				return $"{MapCoord}: {ShopName}";
			}
		}

		public class Trigger
		{
			public Trigger() { }
			public Trigger(MapCoord mapCoord, string actionName)
			{
				this.MapCoord = mapCoord;
				this.ActionName = actionName;
			}

			public MapCoord MapCoord { get; set; }
			public string ActionName { get; set; }

			public override string ToString()
			{
				return $"{MapCoord}: {ActionName}";
			}
		}

		public class Treasure
		{
			public string Label => TreasureName.ToLower() == "gold" ? $"{Quantity} Gold" : TreasureName;
			public Treasure() { }
			public Treasure(MapCoord mapCoord, string treasureName, int quantity)
			{
				this.MapCoord = mapCoord;
				this.TreasureName = treasureName;
				this.Quantity = quantity;
			}

			public MapCoord MapCoord { get; set; }
			public string TreasureName { get; set; }
			public int Quantity { get; set; }

			public override string ToString()
			{
				return $"{MapCoord}: {TreasureName}, {Quantity}";
			}
		}

		public class Battle
		{
			public Battle() { }
			public Battle(MapCoord mapCoord, string battleName)
			{
				this.MapCoord = mapCoord;
				this.BattleName = battleName;
			}

			public MapCoord MapCoord { get; set; }
			public string BattleName { get; set; }

			public override string ToString()
			{
				return $"{MapCoord}: {BattleName}";
			}

		}

		public class ResumePoint
		{
			public ResumePoint() { }
			public ResumePoint(MapCoord mapCoord, string innName)
			{
				this.MapCoord = mapCoord;
				this.InnName = innName;
			}
			public MapCoord MapCoord { get; set; }
			public string InnName { get; set; }

			public override string ToString()
			{
				return $"{InnName}: {MapCoord}";
			}
		}

		public List<Teleport> Teleports { get; }
		public List<NpcInteraction> NpcInteractions { get; }
		public List<Port> Ports { get; }
		public List<Shop> Shops { get; }
		public List<Trigger> Triggers { get; }
		public List<Treasure> Treasures { get; }
		public List<Battle> Battles { get; }
		public List<ResumePoint> ResumePoints { get; }

		public WorldData()
		{
			Teleports = new List<Teleport>();
			NpcInteractions = new List<NpcInteraction>();
			Ports = new List<Port>();
			Shops = new List<Shop>();
			Triggers = new List<Trigger>();
			Treasures = new List<Treasure>();
			Battles = new List<Battle>();
			ResumePoints = new List<ResumePoint>();
		}
	}
}
