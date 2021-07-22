using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UltimateFiction.ECS.Components
{
	public abstract class Component: ISelfRemove
	{
		public string Id { get; set; }
		public string ClassName { get; }
		public bool Active { get; set; }
		public abstract ComponentType ComponentType { get; }
		public bool RemovalRequested { get; set; }

		public Component()
		{
			Id = new Guid().ToString();
			ClassName = this.GetType().Name;
			Active = true;
			RemovalRequested = false;
		}

		public abstract void Tick(GameTime now);
	}
}
