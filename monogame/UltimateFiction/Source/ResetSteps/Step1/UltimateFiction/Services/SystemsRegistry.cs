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
	public class SystemsRegistry
	{
		public List<IEcsSystem> Systems { get; }
		public SystemsRegistry()
		{
			Systems = new List<IEcsSystem>();
		}

		public SystemsRegistry Register(IEcsSystem system)
		{
			Register(new[] { system });
			return this;
		}

		public SystemsRegistry Register(params IEcsSystem[] systems)
		{
			Systems.AddRange(systems);
			return this;
		}

		public SystemsRegistry Register(IEnumerable<IEcsSystem> systems)
		{
			Systems.AddRange(systems);
			return this;
		}
	}
}
