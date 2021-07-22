using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Entities;
using UltimateFiction.MonoGameHelpers;

namespace UltimateFiction.ECS.Engine
{
	public static class EntityExtensions
	{
		public static void SyncAllCooldowns(this List<Entity> entities, GameTime gameTime)
		{
			entities
				.SelectMany(e => e.Components, (e, c) => new { Entity = e, Component = c })
				.ForEach(x =>
				{
					if (x.Component.ComponentType == ComponentType.FrameSetAnimation)
						((SpriteAnimationComponent)x.Component).Cooldown.Reset(gameTime);
				});
		}

		public static IEnumerable<Entity> ActivateAll(this IEnumerable<Entity> entities)
		{
			entities.SetActive(true);
			return entities;
		}

		public static IEnumerable<Entity> DeactivateAll(this IEnumerable<Entity> entities)
		{
			entities.SetActive(false);
			return entities;
		}

		public static IEnumerable<Entity> SetActive(this IEnumerable<Entity> entities, bool value)
		{
			entities
				.SelectMany(e => e.Components, (e, c) => new { Entity = e, Component = c })
				.ForEach(x => x.Component.Active = value)
				.Where(x => x.Component is VisibleComponent)
				.ForEach(x => (x.Component as VisibleComponent).Visible = value);
			return entities;
		}
	}
}
