using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Entities;

namespace UltimateFiction.Services
{
	public class ComponentsService
	{
		public void ForeachComponent(IEnumerable<Entity> entities, Action<Component> componentAction)
		{
			if (componentAction != null)
				foreach (Entity e in entities)
					foreach (Component c in e.Components)
						componentAction(c);

		}

		public void DeactivateAllComponents(IEnumerable<Entity> entities)
		{
			ForeachComponent(entities, c => c.Active = false);
		}

		public void HideAllComponents(IEnumerable<Entity> entities)
		{
			ForeachComponent(entities, c =>
			{
				if (c is VisibleComponent)
					(c as VisibleComponent).Visible = false;
			});
		}
	}
}
