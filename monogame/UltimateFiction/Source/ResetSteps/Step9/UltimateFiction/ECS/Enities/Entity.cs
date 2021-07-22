using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.ECS.Components;

namespace UltimateFiction.ECS.Entities
{
	public class Entity
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public List<Component> Components { get; }

		public Entity()
		{
			Components = new List<Component>();
		}

		public static Entity From(string name, params Component[] components)
		{
			var result = new Entity()
			{
				Name = name,
				Id = Guid.NewGuid()
			};
			result.Components.AddRange(components);
			return result;
		}
	}
}
