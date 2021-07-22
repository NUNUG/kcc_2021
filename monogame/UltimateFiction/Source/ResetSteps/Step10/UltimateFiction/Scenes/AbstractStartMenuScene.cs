using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using UltimateFiction.Data;
using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Engine;
using UltimateFiction.ECS.Entities;
using UltimateFiction.GameCode;
using UltimateFiction.MonoGameHelpers;
using UltimateFiction.Services;
using UltimateFiction.Sprites;

namespace UltimateFiction.Scenes
{
	public abstract class AbstractStartMenuScene : Scene
	{
		protected const int SELECTION_CONTINUE = 0;
		protected const int SELECTION_NEWGAME = 1;
		protected const int SELECTION_QUIT = 2;

		protected readonly GameSettings gameSettings;
		protected readonly GameContent gameContent;
		protected readonly List<Entity> entities;
		protected readonly TileMapService tileMapService;
		protected readonly GameStorage gameStorage;
		protected readonly TileMapComponent backgroundTilemapComponent;
		protected SpriteComponent pointerSpriteComponent;
		protected int menuPointerCol;
		protected int SelectionIndex { get; set; }
		protected Entity fingerEntity;
		protected Entity textNewEntity;
		protected Entity textContinueEntity;
		protected Entity textQuitEntity;
		protected Entity backgroundTilemapEntity;
		protected GameTime gameTime;
		//protected List<Entity> myEntities;
		public override string Name => "Start menu scene";

		public AbstractStartMenuScene(
			GameSettings gameSettings,
			GameContent gameContent,
			GameTime gameTime,
			List<Entity> entities,
			GameStorage gameStorage,
			TileMapService tileMapService)
		{
			this.gameSettings = gameSettings;
			this.gameContent = gameContent;
			this.gameTime = gameTime;
			this.entities = entities;
			this.tileMapService = tileMapService;
			this.gameStorage = gameStorage;

			// Create entities and components.
			backgroundTilemapComponent = tileMapService.TileMapComponents["START"];
			backgroundTilemapComponent.MapViewport = (0, 0, 16 * 8, 16 * 8);
			backgroundTilemapComponent.DestinationRect = new Microsoft.Xna.Framework.Rectangle(0, 0, 16 * 8 * backgroundTilemapComponent.DrawScale, 16 * 8 * backgroundTilemapComponent.DrawScale);
			backgroundTilemapComponent.Visible = true;
			backgroundTilemapEntity = Entity.From("Background tilemap", backgroundTilemapComponent);
			SelectionIndex = 0;
		}

		public override void Tick(GameTime gameTime)
		{
			this.gameTime = gameTime;
		}

		public override void Initialize()
		{
		}

		public override void LoadContent()
		{
		}

		public override void Draw(GameTime gameTime)
		{
		}
	}
}
