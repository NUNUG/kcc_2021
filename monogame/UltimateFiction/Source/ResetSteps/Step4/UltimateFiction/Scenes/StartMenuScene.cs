/*
**********************************************************************************************
* Ultimate Fiction Step 4 - Add a sprite to the screen.
**********************************************************************************************
* We add a pointy finger as a menu cursor.  
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
			int newGameRow = continueRow + 1;
			int quitGameRow = newGameRow + 1;
			int firstSelectionRow = continueRow;

			var continueGameText = new TextComponent()
			{
				Color = Color.White,
				Text = "Continue",
				Position = new Vector2(menuLeftCol * tilePix, continueRow * tilePix),
				Scale = gameSettings.Scale / 4
			};

			var newGameText = new TextComponent()
			{
				Color = Color.White,
				Text = "New Game",
				Position = new Vector2(menuLeftCol * tilePix, newGameRow * tilePix),
				Scale = gameSettings.Scale / 4
			};

			var QuitGameText = new TextComponent()
			{
				Color = Color.White,
				Text = "Quit",
				Position = new Vector2(menuLeftCol * tilePix, quitGameRow * tilePix),
				Scale = gameSettings.Scale / 4
			};

			textContinueEntity = Entity.From("Continue text", continueGameText);
			textNewEntity = Entity.From("NewGame text", newGameText);
			textQuitEntity = Entity.From("Quit text", QuitGameText);

			menuPointerCol = menuLeftCol - 2;
			pointerSpriteComponent = new SpriteComponent(
				"Pointer finger",
				new Vector2(tilePix * menuPointerCol - 1, tilePix * (firstSelectionRow + SelectionIndex)),
				(47, 8),
				gameContent.SpriteSheet
			);

			fingerEntity = Entity.From("Pointer finger sprite",
				pointerSpriteComponent);


			entities.Clear();
			entities.AddRange(new[] {
				textContinueEntity,
				textNewEntity,
				textQuitEntity,
				fingerEntity,
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
