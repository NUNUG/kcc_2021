using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Tiling
{
	public class TileMapList
	{
		public List<TileMap> Maps { get; set; }
		public TileMapList()
		{
			Maps = new List<TileMap>();
		}
	}
}
