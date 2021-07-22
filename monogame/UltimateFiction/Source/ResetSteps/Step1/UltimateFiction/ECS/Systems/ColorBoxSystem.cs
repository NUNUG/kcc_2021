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
	public class ColorBoxSystem : IEcsSystem
	{
		private Dictionary<Color, Texture2D> pixels;
		protected readonly GraphicsDevice graphicsDevice;

		public ColorBoxSystem(GraphicsDevice graphicsDevice)
		{
			pixels = new Dictionary<Color, Texture2D>();
			this.graphicsDevice = graphicsDevice;
		}

		private Texture2D CreatePixel(Color color)
		{
			// Is it cached?
			if (!pixels.TryGetValue(color, out Texture2D result))
			{
				// No.  Create it, cache it, return it.
				var pixel = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
				pixel.SetData(new Color[] { color });
				pixels[color] = pixel;
				return pixel;
			}
			// It's cached.  Return the cached pixel.
			return result;
		}

		public void Draw(GameTime gameTime, IEnumerable<Entity> entities)
		{
			var boxes = entities
				.SelectMany(e => e.Components, (e, c) => new { Entity = e, Component = c })
				.Where(x => x.Component.ComponentType == ComponentType.ColorBox)
				.Select(x => new { x.Entity, Component = (ColorBoxComponent)x.Component })
				.Where(x => x.Component.Visible);

			SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);
			spriteBatch.Begin();
			foreach (var box in boxes)
				spriteBatch.Draw(CreatePixel(box.Component.Color), box.Component.Rect, Color.White);
			spriteBatch.End();
		}

		public void Tick(GameTime gameTime)
		{
		}

		public void Update(GameTime gameTime, List<Entity> entities)
		{
		}
	}
}
