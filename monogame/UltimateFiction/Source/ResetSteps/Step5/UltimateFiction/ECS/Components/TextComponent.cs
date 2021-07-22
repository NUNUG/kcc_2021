using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UltimateFiction.ECS.Components
{
	public class TextComponent : VisibleComponent
	{
		public TextComponent()
		{
			Scale = 1f;
		}

		public string Text { get; set; }
		public Color Color { get; set; }
		public float PositionX { get; set; }
		public float PositionY { get; set; }
		public float Scale { get; set; }
		/// <summary>The x,y pixel position of the upper-left corner of the text.</summary>
		public Vector2 Position
		{
			get { return new Vector2(PositionX, PositionY); }
			set { PositionX = value.X; PositionY = value.Y; }
		}

		public override ComponentType ComponentType => ComponentType.Text;

		public override void Tick(GameTime now)
		{
		}
	}
}
