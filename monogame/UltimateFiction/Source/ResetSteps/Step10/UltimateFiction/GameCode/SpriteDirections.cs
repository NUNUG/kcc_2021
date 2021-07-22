using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.GameCode
{
	/// <summary>A class which declares the frame offsets for sprite directions in the spritesheet.</summary>
	/// <remarks>Add any of these constants to the leftmost (0th) frame of a charcter's sprites to get the index of the first frame in the given direction.</remarks>
	public static class SpriteDirections
	{
		public const int Up = 4;
		public const int Down = 0;
		public const int Left = 6;
		public const int Right = 2;
	}
}
