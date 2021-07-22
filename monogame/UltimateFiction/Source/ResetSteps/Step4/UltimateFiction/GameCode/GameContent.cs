using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;
using UltimateFiction.Data;
using UltimateFiction.ECS.Components;
using UltimateFiction.MonoGameHelpers;
using UltimateFiction.Sprites;
using UltimateFiction.Tiling;

namespace UltimateFiction
{
	public class GameContent
	{
		public SpriteFont Font { get; set; }
		public Dictionary<string, Texture2D> TileSheets { get; set; }
		public Dictionary<string, TileMap> TileMaps { get; set; }
		public SpriteSheet SpriteSheet { get; set; }
		public Dictionary<string, SoundEffect> Sounds { get; set; }
		public WorldData WorldData { get; set; }

		public GameContent()
		{
			TileSheets = new Dictionary<string, Texture2D>();
			TileMaps = new Dictionary<string, TileMap>();
			Sounds = new Dictionary<string, SoundEffect>();
		}

		public Texture2D TileSheetForLayer(string layerName)
		{
			switch (layerName)
			{
				case "Events": return TileSheets["Zones"];
				case "Ceiling": return TileSheets["Overworld"];
				case "CanWalk": return TileSheets["Zones"];
				case "MonsterZones": return TileSheets["Zones"];
				case "Background": return TileSheets["Overworld"];
				default: throw new ArgumentException($"Unsupported layer name ({layerName})");
			}
		}

		public Texture2D TileSheetForLayer(int index)
		{
			switch (index)
			{
				case 4: return TileSheets["Zones"];
				case 3: return TileSheets["Overworld"];
				case 2: return TileSheets["Zones"];
				case 1: return TileSheets["Zones"];
				case 0: return TileSheets["Overworld"];
				default: throw new ArgumentException($"Unsupported layer index ({index})");
			}
		}

		public int TilesetIndexForLayer(int layerIndex)
		{
			switch (layerIndex)
			{
				case 4: return 1;
				case 3: return 0;
				case 2: return 1;
				case 1: return 1;
				case 0: return 0;
				default: throw new ArgumentException($"Unsupported layer ({layerIndex})");
			}
		}
	}
}
