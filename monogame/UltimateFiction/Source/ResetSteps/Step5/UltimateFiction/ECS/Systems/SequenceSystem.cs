using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Entities;

namespace UltimateFiction.ECS.Systems
{
	public class SequenceSystem : IEcsSystem
	{
		public void Draw(GameTime gameTime, IEnumerable<Entity> entities)
		{
		}

		public void Tick(GameTime gameTime)
		{
		}

		public void Update(GameTime gameTime, List<Entity> entities)
		{
			var pairs = entities
				.SelectMany(e => e.Components, (e, c) => new { Entity = e, Component = c })
				.Where(x => x.Component.ComponentType == ComponentType.Sequence)
				.Select(x => ((Entity Entity, ISequenceComponent Component))(x.Entity, (ISequenceComponent)x.Component))
				.Where(x => x.Component.Active);

			foreach (var x in pairs)
			{
				var sequenceComponent = x.Component;
				var entity = x.Entity;
				var targetComponent = x.Entity.Components.FirstOrDefault(c => c.Id == sequenceComponent.TargetId);
				sequenceComponent.Apply?.Invoke(targetComponent, sequenceComponent.Advance());
			}
		}
	}
}
