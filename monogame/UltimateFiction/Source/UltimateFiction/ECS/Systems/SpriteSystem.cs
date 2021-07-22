using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Entities;
using UltimateFiction.GameCode;

namespace UltimateFiction.ECS.Systems
{
	public class SpriteSystem : IEcsSystem
	{
		protected readonly GameSettings gameSettings;
		protected readonly GraphicsDevice graphicsDevice;

		public SpriteSystem(GameSettings gameSettings, GraphicsDevice graphicsDevice)
		{
			this.gameSettings = gameSettings;
			this.graphicsDevice = graphicsDevice;
		}

		public void Draw(GameTime gameTime, IEnumerable<Entity> entities)
		{
			// Find sprite components.
			var sprites = entities
				.SelectMany(e => e.Components, (e, c) => new { Entity = e, Component = c })
				.Where(x => x.Component.ComponentType == ComponentType.Sprite)
				.Select(x => new { x.Entity, Component = (SpriteComponent)x.Component })
				.Where(x => x.Component.Visible);


			SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);
			spriteBatch.Begin(
				SpriteSortMode.FrontToBack,
				BlendState.AlphaBlend,
				SamplerState.PointClamp
			);

			foreach (var sprite in sprites)
			{
				DrawSprite(spriteBatch, (SpriteComponent)sprite.Component);
			}
			spriteBatch.End();
		}

		public void Update(GameTime gameTime, List<Entity> entities)
		{
		}

		private void DrawSprite(SpriteBatch spriteBatch, SpriteComponent sprite)
		{
			Texture2D texture = sprite.SpriteSheet.Texture;
			Rectangle sourceRect;
			Rectangle destRect;
			Color color = Color.White;
			Vector2 origin = sprite.Origin;
			float layerDepth = 0;

			int sourceX = sprite.SpriteSheet.CellWidth * sprite.ImageRowCol.Col;
			int sourceY = sprite.SpriteSheet.CellHeight * sprite.ImageRowCol.Row;
			int sourceX2 = sourceX + sprite.SpriteSheet.CellWidth;
			int sourceY2 = sourceY + sprite.SpriteSheet.CellHeight;

			float destX = sprite.Position.X;
			float destY = sprite.Position.Y;

			sourceRect = new Rectangle(
				(int) sourceX,
				(int) sourceY,
				sprite.SpriteSheet.CellWidth,
				sprite.SpriteSheet.CellHeight);

			destRect = new Rectangle(
				(int)destX,
				(int)destY,
				(int)(sprite.SpriteSheet.CellWidth * gameSettings.Scale),
				(int)(sprite.SpriteSheet.CellHeight * gameSettings.Scale));

			float rotation = sprite.Rotation;
			spriteBatch.Draw(
				texture,
				destRect,
				sourceRect,
				color,
				rotation,
				origin,
				SpriteEffects.None,
				layerDepth);
		}

		public void Tick(GameTime gameTime)
		{
		}
	}
}
