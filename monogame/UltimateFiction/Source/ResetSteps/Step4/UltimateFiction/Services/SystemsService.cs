using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UltimateFiction.ECS.Entities;
using UltimateFiction.ECS.Systems;

namespace UltimateFiction.Services
{
	public class SystemsService
	{
		public SystemsRegistry Registry { get; }

		public SystemsService(SystemsRegistry registry)
		{
			Registry = registry;
		}

		public void DrawAll(GameTime gameTime, List<Entity> entities)
		{
			for (int j = 0; j <= Registry.Systems.Count - 1; j++)
				Registry.Systems[j].Draw(gameTime, entities);
		}

		public void UpdateAll(GameTime gameTime, List<Entity> entities)
		{
			for (int j = 0; j <= Registry.Systems.Count - 1; j++)
				Registry.Systems[j].Update(gameTime, entities);
		}

		public void TickAll(GameTime gameTime)
		{
			Registry.Systems.ForEach(s => s.Tick(gameTime));
		}
	}
}
