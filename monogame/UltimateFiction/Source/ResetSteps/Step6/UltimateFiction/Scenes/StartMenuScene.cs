/*
**********************************************************************************************
* Ultimate Fiction Step 6 - Respond to arrow keys
**********************************************************************************************
* Our pointy finger flashes multiple colors.
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

			var fingerAnimationComponent = new SpriteAnimationComponent(gameTime)
			{
				AnimationSpeed = 8,
				CurrentFrameIndex = 0,
				Frames = new FrameSet()
				{
					Name = "Pointer finger animation",
					ColStart = 10,
					Row = 47,
					ColCount = 2,
					SpriteId = pointerSpriteComponent.SpriteId,
				}
			};

			fingerEntity = Entity.From("Pointer finger sprite",
				pointerSpriteComponent,
				fingerAnimationComponent);


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
			var tilePix = 8 * gameSettings.Scale;
			int continueRow = 9;
			int firstSelectionRow = continueRow;

			// Watch for arrow keys and Z button presses.
			InputState inputState = ReadInput();
			if (inputState.DownArrowPressed)
			{
				this.SelectionIndex = Math.Min(SelectionIndex + 1, 2);
				gameContent.Sounds[SoundNames.KeyNav].Play();
			}
			else if (inputState.UpArrowPressed)
			{
				this.SelectionIndex = Math.Max(SelectionIndex - 1, 0);
				gameContent.Sounds[SoundNames.KeyNav].Play();
			}
			pointerSpriteComponent.Position = new Vector2(tilePix * menuPointerCol - 1, tilePix * (firstSelectionRow + SelectionIndex));
		}
	}
}
