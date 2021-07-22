/*
**********************************************************************************************
* Ultimate Fiction Step 9 - Arrow keys (part 2)
**********************************************************************************************
* Move the character around the screen in response to the arrow keys.
**********************************************************************************************
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Entities;
using UltimateFiction.GameCode;
using UltimateFiction.MonoGameHelpers;
using UltimateFiction.Services;

namespace UltimateFiction.Scenes
{
	public class OverworldScene : AbstractOverworldScene
	{
		public OverworldScene(GameSettings gameSettings, GameContent gameContent, GameTime gameTime, List<Entity> entities, GameStorage gameStorage, TileMapService tileMapService)
			: base(gameSettings, gameContent, gameTime, entities, gameStorage, tileMapService)
		{
			walkingCooldown = new Cooldown() { TotalTime = Cooldown.From(4) };
		}

		public override void Update(GameTime gameTime)
		{
			var viewport = backgroundTileMap.MapViewport;

			InputState inputState = ReadInput();
			if (!Walking())
			{
				// We are not walking.  Watch the keyboard to determine if we should start walking.
				if (inputState.UpArrowPressed || inputState.UpArrowHeld)
					AttemptToWalk(SpriteDirections.Up, DIRECTION_UP);
				else if (inputState.DownArrowPressed || inputState.DownArrowHeld)
					AttemptToWalk(SpriteDirections.Down, DIRECTION_DOWN);
				else if (inputState.LeftArrowPressed || inputState.LeftArrowHeld)
					AttemptToWalk(SpriteDirections.Left, DIRECTION_LEFT);
				else if (inputState.RightArrowPressed || inputState.RightArrowHeld)
					AttemptToWalk(SpriteDirections.Right, DIRECTION_RIGHT);

				// If the arrow keys made us start walking, turn on a walking animation.
				if (Walking())
				{
					playerSpriteAnimator.Active = true;
					// Don't reset the animation if we're continuing to walk in the same direction.  Just continue with it where it is so the animation stays smooth.
					if (previousVelocity != velocity)
						playerSpriteAnimator.ExpireCooldown(gameTime);
				}

				previousVelocity = velocity;
			}
			else
			{
				// We are currently "walking" to the next tile.
				if (walkingCooldown.Expired(gameTime))
				{
					// Move one tile over.
					viewport.X += velocity.X * gameSettings.TileSize.Width;
					viewport.Y += velocity.Y * gameSettings.TileSize.Height;
					backgroundTileMap.MapViewport = viewport;

					// We've landed on a tile.
					StopWalking();
					var newPosition = (viewport.X / gameSettings.TileSize.Width, viewport.Y / gameSettings.TileSize.Height);
					gamePlayData.CurrentMapLocation = newPosition;
					playerSpriteAnimator.Active = false;

					walkingCooldown.Reset(gameTime);
				}
			}
			UpdateDebugText();
		}
	}
}


