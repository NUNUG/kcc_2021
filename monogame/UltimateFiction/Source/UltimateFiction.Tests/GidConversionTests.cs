using System;
using Xunit;
using UltimateFiction.MonoGameHelpers;
using Shouldly;


namespace UltimateFiction.Tests
{
	public class GidConversionTests
	{
		[Theory]
		[InlineData(0, 5, 0, 0)]
		[InlineData(1, 5, 1, 0)]
		[InlineData(2, 5, 2, 0)]
		[InlineData(3, 5, 3, 0)]
		[InlineData(4, 5, 4, 0)]
		[InlineData(5, 5, 0, 1)]
		[InlineData(6, 5, 1, 1)]
		[InlineData(7, 5, 2, 1)]
		public void GidToXyTest(int gid, int width, int expectedx, int expectedy)
		{
			(int x, int y) = gid.GidToXy(width);
			x.ShouldBe(expectedx);
			y.ShouldBe(expectedy);
		}

		[Theory]
		[InlineData(0, 5, 0, 0)]
		[InlineData(1, 5, 0, 1)]
		[InlineData(2, 5, 0, 2)]
		[InlineData(3, 5, 0, 3)]
		[InlineData(4, 5, 0, 4)]
		[InlineData(5, 5, 1, 0)]
		[InlineData(6, 5, 1, 1)]
		[InlineData(7, 5, 1, 2)]
		public void GidToRowColTest(int gid, int colCount, int expectedRow, int expectedCol)
		{
			(int Row, int Col) = gid.GidToRowCol(colCount);
			Row.ShouldBe(expectedRow);
			Col.ShouldBe(expectedCol);
		}

		[Theory]
		[InlineData(0, 0, 5, 0)]
		[InlineData(0, 1, 5, 1)]
		[InlineData(0, 2, 5, 2)]
		[InlineData(0, 3, 5, 3)]
		[InlineData(0, 4, 5, 4)]
		[InlineData(1, 0, 5, 5)]
		[InlineData(1, 1, 5, 6)]
		[InlineData(1, 2, 5, 7)]
		public void RowColToGidTest(int row, int col, int colCount, int expectedGid)
		{
			var gid = (row, col).RowColToGid(colCount);
			gid.ShouldBe(expectedGid);
		}

		[Theory]
		[InlineData(0, 0, 5, 0)]
		[InlineData(1, 0, 5, 1)]
		[InlineData(2, 0, 5, 2)]
		[InlineData(3, 0, 5, 3)]
		[InlineData(4, 0, 5, 4)]
		[InlineData(0, 1, 5, 5)]
		[InlineData(1, 1, 5, 6)]
		[InlineData(2, 1, 5, 7)]
		public void XyToGidTest(int x, int y, int width, int expectedGid)
		{
			var gid = (x, y).XyToGid(width);
			gid.ShouldBe(expectedGid);
		}
	}
}
