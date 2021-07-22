using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.MonoGameHelpers
{
	public static class EnumerableForeach
	{
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> collection, Action<T> action)
		{
			if (action != null)
			{
				var enumerator = collection.GetEnumerator();
				while (enumerator.MoveNext())
					action(enumerator.Current);
			}

			return collection;
		}

		public static (int X, int Y) GidToXy(this int gid, int width)
		{
			int x = gid % width;
			int y = gid / width;
			return (x, y);
		}

		public static (int Row, int Col) GidToRowCol(this int gid, int colCount)
		{
			int row = gid / colCount;
			int col = gid % colCount;
			return (row, col);
		}

		public static int XyToGid(this (int X, int Y) xy, int width)
		{
			return xy.Y * width + xy.X;
		}

		public static int RowColToGid(this (int Row, int Col) rowCol, int colCount)
		{
			return rowCol.Row * colCount + rowCol.Col;
		}
	}
}
