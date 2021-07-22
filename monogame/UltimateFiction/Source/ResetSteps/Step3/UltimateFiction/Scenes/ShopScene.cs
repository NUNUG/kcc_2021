using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UltimateFiction.ECS.Entities;
using UltimateFiction.GameCode;
using UltimateFiction.Services;

namespace UltimateFiction.Scenes
{
	public class ShopScene: Scene, IShopScene
	{
		private readonly GameSettings gameSettings;
		private readonly GameContent gameContent;
		private readonly List<Entity> entities;
		private readonly GameStorage gameStorage;
		private readonly TileMapService tileMapService;

		private Entity backgroundTileMapEntity;
		private List<Entity> myEntities;

		public ShopScene(
			GameSettings gameSettings,
			GameContent gameContent,
			GameTime gameTime,
			List<Entity> entities,
			GameStorage gameStorage,
			TileMapService tileMapService)
		{
			this.gameSettings = gameSettings;
			this.gameContent = gameContent;
			this.entities = entities;
			this.gameStorage = gameStorage;
			this.tileMapService = tileMapService;

			myEntities = new();
		}

		public override string Name => "Shop scene";

		public override void Activate(SceneController sceneController)
		{
			base.Activate(sceneController);

			backgroundTileMapEntity = new Entity();
			tileMapService.UseBackgroundTileMap(backgroundTileMapEntity, "DIALOG");
		}

		public override void Deactivate()
		{
			myEntities.ForEach(e => e.Components.ForEach(c => c.Active = false));
			myEntities.ForEach(e => { if (entities.Any(e2 => e2 == e)) entities.Remove(e); });
			myEntities.Clear();

			base.Deactivate();
		}

		public override void Tick(GameTime gameTime)
		{
		}

		public override void Initialize()
		{
		}

		public override void LoadContent()
		{
		}

		public override void Update(GameTime gameTime)
		{
		}

		public override void Draw(GameTime gameTime)
		{
		}
	}
}
