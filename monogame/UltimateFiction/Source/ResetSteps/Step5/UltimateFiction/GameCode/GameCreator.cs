using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using UltimateFiction.ECS;
using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Entities;
using UltimateFiction.ECS.Systems;
using UltimateFiction.Services;
using UltimateFiction.Tiling;

namespace UltimateFiction.GameCode
{
	public class GameCreator 
	{
		private const string TILEMAP_OVERWORLD_ID = "OW";

		public List<Entity> Entities { get; set; }
		public Dictionary<string, TileMapComponent> TileMapComponents;
		public Dictionary<string, PixelMapComponent> PixelMapComponents;
		public TileMapService TileMapService { get; set; }
		public SystemsService SystemsService { get; set; }
		public EntityService EntityService { get; set; }

		public GameCreator()
		{
			TileMapComponents = new Dictionary<string, TileMapComponent>();
			PixelMapComponents = new Dictionary<string, PixelMapComponent>();
			Entities = new List<Entity>();
		}

		public void CreateAll(GameSettings gameSettings, GraphicsDevice graphicsDevice, GameContent gameContent, int screenScale)
		{
			// Create initial components.
			CreateTileMapComponents(gameContent, screenScale);

			// Create systems
			SystemsRegistry systemsRegistry = new SystemsRegistry()
				.Register(
					new SpriteAnimatorSystem(),
					new PixelMapPainterSystem(graphicsDevice),
					new SpriteSystem(gameSettings, graphicsDevice),
					new ColorBoxSystem(graphicsDevice),
					new TextSystem(graphicsDevice, gameContent),
					new SequenceSystem()
				);

			// Create services.
			TileMapService = new TileMapService(TileMapComponents);
			SystemsService = new SystemsService(systemsRegistry);

			// Create initial entities.
			var backgroundEntity = new Entity()
			{
				Id = new Guid(),
				Name = EntityService.BACKGROUND_TILE_MAP_NAME
			};
		}

		protected void CreateTileMapComponents(GameContent gameContent, int scale)
		{
			foreach (var key in gameContent.TileMaps.Keys)
			{
				TileMap tileMap = gameContent.TileMaps[key];
				TileMapComponent component = new TileMapComponent()
				{
					Id = TileMapService.BACKGROUND_TILEMAP_ID,
					DrawPosition = (0, 0),
					Active = true,
					Visible = false,
					Depth = 0,
					DrawScale = scale,
					MapViewport = (0, 0, 18 * 8, 18 * 8),
					DestinationRect = new Microsoft.Xna.Framework.Rectangle(0, 0, 18 * 8 * scale, 18 * 8 * scale)
				};

				component.LoadTileMap(gameContent, tileMap.ContentName);
				TileMapComponents.Add(tileMap.Id, component);
			}
		}
	}
}
