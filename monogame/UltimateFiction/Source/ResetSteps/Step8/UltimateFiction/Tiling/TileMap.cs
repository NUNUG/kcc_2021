using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace UltimateFiction.Tiling
{
	public class TileMap
	{
		public List<string> TilesheetNames { get; }
		public string Filename { get; }
		public string Id { get; }
		public string ContentName { get; }
		public string Description { get; }
		public TmxMap Map { get; set; }
		public (int Width, int Height) TileWH { get; }
		public (int Width, int Height) TileSize { get; }
		public (int Width, int Height) PixelWH { get; }
		public TileMap(string filename, string id, string contentName, string description, TmxMap map)
		{
			TilesheetNames = new List<string>();
			Filename = filename;
			Id = id;
			ContentName = contentName;
			Description = description;

			//var tmxPath = Path.Combine("..\tilemaps", fileName);
			//Map = new TmxMap(tmxPath);
			Map = map;

			TileWH = (Map.Width, Map.Height);
			TileSize = (Map.TileWidth, Map.TileHeight);
			PixelWH = (Map.Width * Map.TileWidth, Map.Height * Map.TileHeight);

			for (int i = 0; i <= Map.Tilesets.Count - 1; i++)
			{
				TilesheetNames.Add(Map.Tilesets[i].Name);
			}
		}
	}
}
