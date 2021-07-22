/*
**********************************************************************************************
* Ultimate Fiction Step 2 - Added first text component.
**********************************************************************************************
* We have added an entity with a text component.  We put it in the entity list and it will
* appear on the screen.
**********************************************************************************************
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Engine;
using UltimateFiction.ECS.Entities;
using UltimateFiction.GameCode;
using UltimateFiction.Services;
using UltimateFiction.Sprites;

namespace UltimateFiction.Scenes
{
	public class StartMenuScene : AbstractStartMenuScene
	{
		public StartMenuScene(GameSettings gameSettings, GameContent gameContent, GameTime gameTime, List<Entity> entities, GameStorage gameStorage, TileMapService tileMapService) : base(gameSettings, gameContent, gameTime, entities, gameStorage, tileMapService)
		{
		}

		public override void Activate(SceneController sceneController)
		{
			base.Activate(sceneController);
			var tilePix = gameSettings.TileSize.Width * gameSettings.Scale;
			int menuLeftCol = 7;
			int continueRow = 9;

			var continueGameText = new TextComponent()
			{
				Color = Color.White,
				Text = "Continue",
				Position = new Vector2(menuLeftCol * tilePix, continueRow * tilePix),
				Scale = gameSettings.Scale / 4
			};

			textContinueEntity = Entity.From("Continue text", continueGameText);

			entities.Clear();
			entities.AddRange(new[] {
				textContinueEntity,
			});
			entities.ActivateAll();
		}

		public override void Deactivate()
		{
			base.Deactivate();

			// This is where we clean up after ourselves by reversing the actions we took in the Activate() method.
			entities.DeactivateAll();
			entities.Clear();
		}

		public override void Update(GameTime gameTime)
		{

		}
	}
}
