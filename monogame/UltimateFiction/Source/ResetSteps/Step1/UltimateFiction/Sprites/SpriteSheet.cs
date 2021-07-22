using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Sprites
{
	public class SpriteSheet
	{
		public List<FrameSet> FrameSets { get; set; }
		public Texture2D Texture { get; set; }

		public SpriteSheet()
		{
			FrameSets = new List<FrameSet>();
		}

		public string Name { get; set; }
		public int RowCount { get; set; }
		public int ColCount { get; set; }
		public int CellWidth { get; set; }
		public int CellHeight { get; set; }
	}
}
