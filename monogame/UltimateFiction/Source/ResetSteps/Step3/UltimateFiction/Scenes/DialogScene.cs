using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Entities;
using UltimateFiction.GameCode;
using UltimateFiction.Services;

namespace UltimateFiction.Scenes
{
	public class DialogScene : Scene
	{
		private const string TILEMAP_DIALOG_ID = "DIALOG";

		public List<string> Lines { get; }
		private readonly TileMapService tileMapService;
		private readonly GameSettings gameSettings;
		private readonly List<Entity> entities;
		private List<Entity> myEntities;
		private List<Entity> textEntities;
		private Entity backgroundTileMapEntity;

		public override string Name => "DialogScene";

		public DialogScene(GameSettings gameSettings, List<Entity> entities, TileMapService tileMapService)
		{
			this.gameSettings = gameSettings;
			this.tileMapService = tileMapService;
			this.Lines = new();
			this.entities = entities;
		}

		public override void Draw(GameTime gameTime)
		{
		}

		public override void Activate(SceneController sceneController)
		{
			base.Activate(sceneController);

			backgroundTileMapEntity = new Entity();
			tileMapService.UseBackgroundTileMap(backgroundTileMapEntity, TILEMAP_DIALOG_ID);
			textEntities = new List<Entity>();
			foreach (string line in Lines)
			{
				var entity = new Entity();
				var textComponent = new TextComponent() { Text = line, Color = Color.White, Scale = gameSettings.Scale / 4};
				entity.Components.Add(textComponent);
				textEntities.Add(entity);
			}

			int lineCount = Lines.Count;
			int firstline = 7 - (lineCount / 2);
			int rowHeight = gameSettings.TileSize.Height;
			int colWidth = gameSettings.TileSize.Width;
			int firstPixel = firstline * rowHeight;
			for (int j = 0; j <= lineCount - 1; j++)
			{
				((TextComponent)(textEntities[j].Components[0])).PositionX = colWidth * 2 * gameSettings.Scale;
				((TextComponent)(textEntities[j].Components[0])).PositionY = (j * rowHeight + firstPixel) * gameSettings.Scale;
				((TextComponent)(textEntities[j].Components[0])).Text = Lines[j];
			}

			myEntities = new();
			myEntities.Add(backgroundTileMapEntity);
			myEntities.AddRange(textEntities);
			entities.AddRange(myEntities);
		}

		public override void Deactivate()
		{
			myEntities.ForEach(e => e.Components.ForEach(c => c.Active = false));
			foreach (var entity in myEntities)
			{
				if (entities.Contains(entity))
					entities.Remove(entity);
			}
			myEntities = null;

			base.Deactivate();
		}

		public override void Initialize()
		{
		}

		public override void LoadContent()
		{
		}

		public override void Tick(GameTime gameTime)
		{
		}

		public override void Update(GameTime gameTime)
		{
			InputState inputState = ReadInput();
			if (inputState.ZButtonPressed || inputState.XButtonPressed)
			{
				// Done. Exit the scene.
				sceneController.EndCurrentScene();
			}
		}
	}
}
