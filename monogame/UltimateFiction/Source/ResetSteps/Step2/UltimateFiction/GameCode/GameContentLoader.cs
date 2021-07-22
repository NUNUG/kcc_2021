using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;
using UltimateFiction.Data;
using UltimateFiction.Sprites;
using UltimateFiction.Tiling;

namespace UltimateFiction.GameCode
{
	public class GameContentLoader
	{
		public GameContent Content { get; }

		public GameContentLoader()
		{
			Content = new GameContent();
		}

		public GameContent LoadContent(ContentManager contentManager)
		{
			// Load fonts
			Content.Font = contentManager.Load<SpriteFont>("fonts/alagard");

			// Load tilemaps and tilesheets
			Content.TileSheets = new Dictionary<string, Texture2D>();
			Content.TileMaps = new Dictionary<string, TileMap>();
			LoadTileMaps(contentManager);
			LoadSounds(contentManager);
			LoadWorldData(contentManager);

			Content.SpriteSheet = SpriteSheetLoader.Load(contentManager, @"spritesheets/Sprites");

			return Content;
		}

		private void LoadSounds(ContentManager contentManager)
		{
			Content.Sounds[SoundNames.KeyClick] = contentManager.Load<SoundEffect>("sound/keyclick");
			Content.Sounds[SoundNames.KeyNav] = contentManager.Load<SoundEffect>("sound/keynav");
		}

		public void LoadWorldData(ContentManager contentManager)
		{
			Content.WorldData = contentManager.Load<WorldData>("gamedata/worlddata");
		}

		protected void LoadTileMaps(ContentManager contentManager)
		{
			var tileMapManifest = contentManager.Load<TileMapManifest>("tilemap-manifests/tilemap_manifest");

			foreach (var entry in tileMapManifest.Entries)
			{
				string tmxFilename = $"Assets/tiled/{entry.MapFilename}";
				TmxMap tmxMap = new TmxMap(tmxFilename);

				var newTileMap = new TileMap(entry.MapFilename, entry.Id, entry.ContentName, entry.Description, tmxMap);
				LoadTileSheetsForMap(contentManager, newTileMap);
				Content.TileMaps[entry.ContentName] = newTileMap;
			}
		}

		public TileMap LoadTileSheetsForMap(ContentManager contentManager, TileMap map)
		{
			for (int i = 0; i <= map.Map.Tilesets.Count - 1; i++)
			{
				string contentName = map.Map.Tilesets[i].Name;
				map.TilesheetNames.Add(contentName);

				if (!Content.TileSheets.ContainsKey(contentName))
				{
					var tilesheetImage = contentManager.Load<Texture2D>($"tilesheets/{contentName}");
					Content.TileSheets[contentName] = tilesheetImage;
				}
				
			}
			return map;
		}
	}
}
