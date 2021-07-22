using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.ECS.Components
{
	public abstract class VisibleComponent: Component
	{
		public bool Visible { get; set; }

		public VisibleComponent()
		{
			Visible = true;
		}
	}
}
