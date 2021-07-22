using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UltimateFiction.Sprites;

namespace UltimateFiction.ECS.Components
{
	public class SpriteComponent : VisibleComponent
	{
		// TODO: Re-implement this with SpriteSheetInfo.
		//public SpriteSheetInfo Image { get; set; }
		//public Vector2 ImageRowCol { get; set; }
		//public Vector2 Position { get; set; }
		//public float Scale { get; set; }

		public Guid SpriteId { get; }
		public SpriteSheet SpriteSheet { get; set; }
		public (int Row, int Col) ImageRowCol { get; set; }
		public (int Width, int Height) Size { get; set; }
		public Vector2 Position { get; set; }
		public Vector2 Origin { get; set; }
		public float Rotation { get; set; }
		public float Scale { get; set; }

		public SpriteComponent(
			string id,
			Vector2 position,
			(int Row, int Col) imageRowCol,
			SpriteSheet spriteSheet) : base()
		{
			Id = id;
			Position = position;
			this.ImageRowCol = imageRowCol;
			SpriteSheet = spriteSheet;
			SpriteId = Guid.NewGuid();
		}

		public override ComponentType ComponentType => ComponentType.Sprite;

		public override void Tick(GameTime now)
		{
		}
	}
}
