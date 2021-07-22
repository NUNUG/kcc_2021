using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UltimateFiction.ECS.Components
{
	public class ColorBoxComponent : VisibleComponent
	{
		public override ComponentType ComponentType => ComponentType.ColorBox;

		public Color Color { get; set; }

		public Rectangle Rect { get; set; }

		public override void Tick(GameTime now)
		{
		}
	}
}
