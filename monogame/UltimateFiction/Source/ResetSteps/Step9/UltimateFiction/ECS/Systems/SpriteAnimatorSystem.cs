using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.ECS.Entities;
using UltimateFiction.ECS.Components;
using UltimateFiction.MonoGameHelpers;

namespace UltimateFiction.ECS.Systems
{
	public class SpriteAnimatorSystem : IEcsSystem
	{
		public void Draw(GameTime gameTime, IEnumerable<Entity> entities)
		{
		}

		public void Update(GameTime gameTime, List<Entity> entities)
		{
			entities
				.Where(e => e.Components.Any(c => c.ComponentType == ComponentType.FrameSetAnimation))
				.ForEach(entity => AnimateEntity(entity, gameTime));
		}

		private void AnimateEntity(Entity entity, GameTime gameTime)
		{
			var sprite = entity.Components.FirstOrDefault(c => c.ComponentType == ComponentType.Sprite);
			var animation = entity.Components.FirstOrDefault(c => c.ComponentType == ComponentType.FrameSetAnimation);

			if ((sprite == null) || (animation == null))
				return;
			if (!((SpriteComponent)sprite).Visible)
				return;
			if (!sprite.Active)
				return;
			if (!animation.Active)
				return;

			ProcessAnimationComponent(gameTime, (SpriteComponent)sprite, (SpriteAnimationComponent)animation);
		}

		private void ProcessAnimationComponent(
			GameTime gameTime,
			SpriteComponent sprite,
			SpriteAnimationComponent animation)
		{
			if (animation.Cooldown.Expired(gameTime))
			{
				animation.CurrentFrameIndex =
					((animation.CurrentFrameIndex + 1) % animation.Frames.ColCount);

				var row = sprite.ImageRowCol.Row;
				var col = animation.Frames.ColStart + animation.CurrentFrameIndex;
				var rowCol = (row, col);

				sprite.ImageRowCol = rowCol;
				animation.Cooldown.Reset(gameTime);
			}
		}

		public void Tick(GameTime gameTime)
		{
		}
	}
}
