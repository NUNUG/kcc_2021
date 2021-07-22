using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Sprites
{
	public class FrameSet
	{
		public string Name { get; set; }
		public int Row { get; set; }
		public int ColStart { get; set; }
		public int ColCount { get; set; }
		public int FrameCount => ColCount;
		public int ColEnd => ColStart + ColCount - 1;
		public Guid SpriteId { get; set; }
	}
}
