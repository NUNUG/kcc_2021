using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Entities;

namespace UltimateFiction.ECS.Systems
{
	public class TextSystem : IEcsSystem
	{
		protected readonly GraphicsDevice graphicsDevice;
		protected readonly GameContent gameContent;
		protected IEnumerable<(Entity Entity, TextComponent Component)> components;

		public TextSystem(GraphicsDevice graphicsDevice, GameContent gameContent)
		{
			this.graphicsDevice = graphicsDevice;
			this.gameContent = gameContent;
		}

		public void Draw(GameTime gameTime, IEnumerable<Entity> entities)
		{
			SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);

			spriteBatch.Begin(
				SpriteSortMode.FrontToBack,
				BlendState.AlphaBlend,
				SamplerState.PointClamp
			);

			foreach (var component in components)
				DrawText(gameTime, spriteBatch, component.Entity, component.Component);

			spriteBatch.End();
		}

		public void Update(GameTime gameTime, List<Entity> entities)
		{
			this.components = entities
				.SelectMany(e => e.Components, (e, c) => new { Entity = e, Component = c })
				.Where(x => x.Component.ComponentType == ComponentType.Text)
				.Select(x => ((Entity Entity, TextComponent Component))(x.Entity, (TextComponent)x.Component))
				.Where(x => x.Component.Visible);
		}

		private void DrawText(GameTime gameTime, SpriteBatch spriteBatch, Entity entity, TextComponent component)
		{
			var font = gameContent.Font;
			spriteBatch.DrawString(font, component.Text, component.Position, component.Color, 0f, Vector2.Zero, component.Scale, SpriteEffects.None, 0);
		}

		public void Tick(GameTime gameTime)
		{
		}
	}
}
