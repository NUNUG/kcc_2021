using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TiledSharp;

namespace UltimateFiction.ECS.Components
{
	public class TileMapComponent : VisibleComponent
	{
		public override ComponentType ComponentType => ComponentType.TileMap;

		public string MapId { get; set; }
		// The name of the content in the content pipeline.
		public string ContentName { get; set; }
		// The tile map.
		public TmxMap Map { get; set; }
		// The tilesheet image.
		public List<Texture2D> TileSheetImages { get; set; }
		// Pixel dimensions of the TileSheet image.
		public (int Width, int Height) TileSheetSize { get; set; }
		// The index indicating which of the tilesets in the Tiled file we are using for this map.
		public List<int> TileSetIndexes { get; set; }
		// The Tilesheet metadata from the Tiled editor
		public TmxTileset TileSet { get; set; }
		// How many tiles high and wide in the tile map.
		public (int Width, int Height) TileMapDimensions { get; set; }
		// How many tiles high and wide in the tilesheet.
		public (int Rows, int Cols) TileSheetRowCols { get; set; }
		// How many tiles high and wide in the tilemap.
		public (int Rows, int cols) TileMapRowCols { get; set; }
		// How many pixels high and wide in each tile.
		public (int Width, int Height) TileDimensions { get; set; }
		public Rectangle DestinationRect { get; set; }

		public bool CeilingOn { get; set; }

		public (int Width, int Height) TileSize { get; set; }
		//public (int X, int Y, int TilesWide, int TilesHigh) MapViewport { get; set; }
		public (int X, int Y, int PixelsWide, int PixelsHigh) MapViewport { get; set; }
		public (int X, int Y) DrawPosition { get; set; }
		public (int XCount, int YCount) TileAreaToDraw { get; set; }
		public int DrawScale { get; set; }
		public int Depth { get; set; }

		public TileMapComponent LoadTileMap(GameContent gameContent, string tilemapContentName)
		{
			TileSheetImages = new List<Texture2D>();
			TileSetIndexes = new List<int>();

			Depth = 0;
			Map = gameContent.TileMaps[tilemapContentName].Map;
			MapId = gameContent.TileMaps[tilemapContentName].Id;
			ContentName = tilemapContentName;
			TileMapDimensions = (Map.Width, Map.Height);
			for (int layerNumber = 0; layerNumber <= Map.Layers.Count - 1; layerNumber++)
			{
				TileSheetImages.Add(gameContent.TileSheetForLayer(layerNumber));
				TileSetIndexes.Add(gameContent.TilesetIndexForLayer(layerNumber));
			}
			// We have simplified everything by miles because we assume all tilesets are the same size.
			// For our appliacation, all tilesets are 64x64 tiles and all tiles are 8x8 pixels.
			TileSet = Map.Tilesets[0];
			TileDimensions = (TileSet.TileWidth, TileSet.TileHeight);
			TileSheetRowCols = (TileSheetImages[0].Width / TileDimensions.Width, TileSheetImages[0].Height / TileDimensions.Height);
			TileMapRowCols = (Map.Height, Map.Width);
		
			//TileDimensions = (TileSheetImage.Width, TileSheetImage.Height);
			TileDimensions = (TileSet.TileWidth, TileSet.TileHeight);

			return this;
		}

		public override void Tick(GameTime now)
		{
		}

		public override string ToString()
		{
			return $"TileMap {MapId}";
		}
	}
}
