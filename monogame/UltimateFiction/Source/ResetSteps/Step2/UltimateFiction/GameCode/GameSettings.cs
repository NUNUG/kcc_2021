using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.GameCode
{
	public class GameSettings
	{
		public bool Debug => true;
		public (int X, int Y) PlayerTilePosition { get; set; }
		public (int Width, int Height) TileSize { get; set; }
		public (int Cols, int Rows) TileViewPortSize { get; set; }
		public int Scale { get; set; }
		public (int Width, int Height) ScreenSize { get; set; }
	}
}
