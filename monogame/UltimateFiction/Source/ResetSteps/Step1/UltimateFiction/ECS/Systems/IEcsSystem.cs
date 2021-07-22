using System.Collections.Generic;
using Microsoft.Xna.Framework;
using UltimateFiction.ECS.Entities;

namespace UltimateFiction.ECS.Systems
{
	public interface IEcsSystem
	{
		/// <summary>This is called from the Update method.</summary>
		void Tick(GameTime gameTime);

		void Update(GameTime gameTime, List<Entity> entities);

		/// <summary>This is called from the Draw method.</summary>
		void Draw(GameTime gameTime, IEnumerable<Entity> entities);
	}
}
