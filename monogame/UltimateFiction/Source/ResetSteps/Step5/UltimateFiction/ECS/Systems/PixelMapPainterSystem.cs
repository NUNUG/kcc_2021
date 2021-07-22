using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Entities;

namespace UltimateFiction.ECS.Systems
{
	public class PixelMapPainterSystem : IEcsSystem
	{
		protected readonly GraphicsDevice graphicsDevice;
		protected IEnumerable<(Entity Entity, TileMapComponent Component)> components;
		private bool showZero = true;
		private bool showThree = true;


		public PixelMapPainterSystem(GraphicsDevice graphicsDevice)
		{
			this.graphicsDevice = graphicsDevice;
		}

		public void Draw(GameTime gameTime, IEnumerable<Entity> entities)
		{
			SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);
			foreach (var component in components)
			{
				PaintTileMap(gameTime, spriteBatch, (TileMapComponent)component.Component);
			}
		}

		public void Update(GameTime gameTime, List<Entity> entities)
		{
			components = entities
				.SelectMany(e => e.Components, (e, c) => new { Entity = e, Component = c })
				.Where(x => x.Component.ComponentType == ComponentType.TileMap)
				.Select(x => ((Entity Entity, TileMapComponent Component))(x.Entity, (TileMapComponent)x.Component))
				.Where(x => x.Component.Visible)
				.OrderBy(x => x.Component.Depth);
		}

		private (int X, int Y) XyOfIndex(int mapWidth, int mapHeight, int gid)
		{
			int row = gid / mapWidth;
			int col = gid % mapWidth;
			return (col, row);
		}

		private int IndexOfXy(int mapWidth, int mapHeight, int x, int y)
		{
			return y * mapWidth + x;
		}

		//private void PaintTileMap(GameTime gameTime, SpriteBatch spriteBatch, TileMapComponent pixelMapComponent)
		//{
		//	// Enable "clipping" so that anything we try to draw outside the destination rectangle doesn't show up.
		//	//spriteBatch.GraphicsDevice.RasterizerState.ScissorTestEnable = true;
		//	var initialRasterizerState = spriteBatch.GraphicsDevice.RasterizerState;
		//	//initialRasterizerState.ScissorTestEnable = true;
		//	//spriteBatch.GraphicsDevice.RasterizerState = initialRasterizerState;

		//	//spriteBatch.GraphicsDevice.RasterizerState = new RasterizerState()
		//	//{
		//	//	ScissorTestEnable = true,
		//	//	CullMode = initialRasterizerState.CullMode,
		//	//	DepthBias = initialRasterizerState.DepthBias,
		//	//	DepthClipEnable = initialRasterizerState.DepthClipEnable,
		//	//	FillMode = initialRasterizerState.FillMode,
		//	//	MultiSampleAntiAlias = initialRasterizerState.MultiSampleAntiAlias,
		//	//	SlopeScaleDepthBias = initialRasterizerState.SlopeScaleDepthBias
		//	//};

		//	spriteBatch.GraphicsDevice.ScissorRectangle = pixelMapComponent.DestinationRect;

		//	spriteBatch.Begin(
		//		SpriteSortMode.FrontToBack,
		//		BlendState.AlphaBlend,
		//		SamplerState.PointClamp
		//	);

		//	//graphicsDevice.Clear(Color.CornflowerBlue);

		//	int scale = pixelMapComponent.DrawScale;
		//	(int tileSizeX, int tileSizeY) = pixelMapComponent.TileDimensions;
		//	(int drawPosX, int drawPosY) = pixelMapComponent.DrawPosition;
		//	int tilesWide = pixelMapComponent.MapViewport.PixelsWide / tileSizeX;
		//	int tilesHigh = pixelMapComponent.MapViewport.PixelsHigh / tileSizeY;
		//	int xTileOffset = pixelMapComponent.MapViewport.X / tileSizeX;
		//	int yTileOffset = pixelMapComponent.MapViewport.Y / tileSizeY;
		//	int xPixelOffset = pixelMapComponent.MapViewport.X % tileSizeX;
		//	int yPixelOffset = pixelMapComponent.MapViewport.Y % tileSizeY;
		//	(int xDrawPosition, int yDrawPosition) = pixelMapComponent.DrawPosition;

		//	//for (int layerNumber = pixelMapComponent.Map.Layers.Count - 1; layerNumber >= 0; layerNumber--)
		//	for (int layerNumber = 0; layerNumber <= pixelMapComponent.Map.Layers.Count - 1; layerNumber++)
		//	{
		//		var layer = pixelMapComponent.Map.Layers[layerNumber];
		//		//if (layer.Visible)
		//		if ((layerNumber == 0 && showZero) || (layerNumber == 3 && showThree))
		//		{
		//			// Draw the whole tiles if tile-aligned.
		//			for (int y = 0; y <= tilesHigh - 1; y++)
		//			{
		//				for (int x = 0; x <= tilesWide - 1; x++)
		//				{

		//					// The black line on the top row and bottom row of the first (upper left) tile
		//					// occurs on the second tile if we skip the first!
		//					//if (x == 0 && y == 0) continue;

		//					//if (x > 0 || y > 0) continue;

		//					var tileIndex = IndexOfXy(
		//						pixelMapComponent.TileMapDimensions.Width,
		//						pixelMapComponent.TileMapDimensions.Height,
		//						//pixelMapComponent.MapViewport.X + x,
		//						//pixelMapComponent.MapViewport.Y + y);
		//						xTileOffset + x,
		//						yTileOffset + y);

		//					if ((tileIndex <= layer.Tiles.Count - 1)
		//						&& (tileIndex >= 0))
		//					{
		//						// Determine which tile to draw here.
		//						var gid = layer.Tiles[tileIndex].Gid - 1;
		//						if (gid > 0)    // If it's 0, there is no tile here.  Do not draw anything.
		//						{
		//							// Draw the tile.
		//							(int tileSheetX, int tileSheetY) = XyOfIndex(
		//								pixelMapComponent.TileSheetRowCols.Cols,
		//								pixelMapComponent.TileSheetRowCols.Rows,
		//								gid);

		//							// This rectangle is the region in the tilesheet where this single tile exists.
		//							Rectangle sourceRect = new Rectangle(
		//								tileSizeX * tileSheetX,
		//								tileSizeY * tileSheetY,
		//								tileSizeX,
		//								tileSizeY);

		//							//Rectangle sourceRect = new Rectangle(
		//							//	tileSizeX * tileSheetX, //tileSizeX * tileSheetX,
		//							//	tileSizeY * tileSheetY,
		//							//	tileSizeX,
		//							//	tileSizeY);

		//							//Rectangle sourceRect = new Rectangle(
		//							//	8 * 33,//tileSizeX * tileSheetX, //tileSizeX * tileSheetX,
		//							//	8 * 2, //tileSizeY * tileSheetY,
		//							//	8, //tileSizeX,
		//							//	8); //tileSizeY);

		//							//Rectangle sourceRect = new Rectangle(
		//							//	tileSizeX * tileSheetX, //tileSizeX * tileSheetX,
		//							//	tileSizeY * tileSheetY,
		//							//	tileSizeX,
		//							//	tileSizeY);

		//							//Rectangle destRect = new Rectangle(
		//							//	(x * tileSizeX + xDrawPosition) * scale,
		//							//	(y * tileSizeY + yDrawPosition) * scale,
		//							//	(x * tileSizeX + xDrawPosition) * scale + tileSizeX * scale,
		//							//	(y * tileSizeY + yDrawPosition) * scale + tileSizeY * scale);

		//							//Rectangle destRect = new Rectangle(
		//							//(xDrawPosition + x * tileSizeX),
		//							//	(yDrawPosition + y * tileSizeY),
		//							//	(xDrawPosition + x * tileSizeX) + tileSizeX,
		//							//	(yDrawPosition + y * tileSizeY) + tileSizeY);

		//							//Rectangle destRect = new Rectangle(
		//							//	(1 * 8) * scale,
		//							//	(1 * 8) * scale,
		//							//	32,//8 * scale,
		//							//	32//8 * scale
		//							//	);

		//							Rectangle destRect = new Rectangle(
		//								((-1 * xPixelOffset) + (x * tileSizeX)) * scale,
		//								((-1 * yPixelOffset) + (y * tileSizeY)) * scale,
		//								tileSizeX * scale,
		//								tileSizeY * scale
		//								);


		//							spriteBatch.Draw(pixelMapComponent.TileSheetImages[0], destRect, sourceRect, Color.White);
		//						}
		//					}
		//				}
		//			}
		//		}
		//	}

		//	spriteBatch.End();
		//}


		private void PaintTileMap(GameTime gameTime, SpriteBatch spriteBatch, TileMapComponent pixelMapComponent)
		{
			// Enable "clipping" so that anything we try to draw outside the destination rectangle doesn't show up.
			//spriteBatch.GraphicsDevice.RasterizerState.ScissorTestEnable = true;
			var initialRasterizerState = spriteBatch.GraphicsDevice.RasterizerState;
			//initialRasterizerState.ScissorTestEnable = true;
			//spriteBatch.GraphicsDevice.RasterizerState = initialRasterizerState;

			//spriteBatch.GraphicsDevice.RasterizerState = new RasterizerState()
			//{
			//	ScissorTestEnable = true,
			//	CullMode = initialRasterizerState.CullMode,
			//	DepthBias = initialRasterizerState.DepthBias,
			//	DepthClipEnable = initialRasterizerState.DepthClipEnable,
			//	FillMode = initialRasterizerState.FillMode,
			//	MultiSampleAntiAlias = initialRasterizerState.MultiSampleAntiAlias,
			//	SlopeScaleDepthBias = initialRasterizerState.SlopeScaleDepthBias
			//};

			spriteBatch.GraphicsDevice.ScissorRectangle = pixelMapComponent.DestinationRect;

			spriteBatch.Begin(
				SpriteSortMode.FrontToBack,
				BlendState.AlphaBlend,
				SamplerState.PointClamp
			);

			//graphicsDevice.Clear(Color.CornflowerBlue);

			int scale = pixelMapComponent.DrawScale;
			(int tileSizeX, int tileSizeY) = pixelMapComponent.TileDimensions;
			(int drawPosX, int drawPosY) = pixelMapComponent.DrawPosition;
			int tilesWide = pixelMapComponent.MapViewport.PixelsWide / tileSizeX;
			int tilesHigh = pixelMapComponent.MapViewport.PixelsHigh / tileSizeY;
			int xTileOffset = pixelMapComponent.MapViewport.X / tileSizeX;
			int yTileOffset = pixelMapComponent.MapViewport.Y / tileSizeY;
			int xPixelOffset = pixelMapComponent.MapViewport.X % tileSizeX;
			int yPixelOffset = pixelMapComponent.MapViewport.Y % tileSizeY;
			(int xDrawPosition, int yDrawPosition) = pixelMapComponent.DrawPosition;

			//for (int layerNumber = pixelMapComponent.Map.Layers.Count - 1; layerNumber >= 0; layerNumber--)
			for (int y = 0; y <= tilesHigh - 1; y++)
			{
				for (int x = 0; x <= tilesWide - 1; x++)
				{
					// Draw the whole tiles if tile-aligned.

					// The black line on the top row and bottom row of the first (upper left) tile
					// occurs on the second tile if we skip the first!
					//if (x == 0 && y == 0) continue;

					//if (x > 0 || y > 0) continue;

					var tileIndex = IndexOfXy(
						pixelMapComponent.TileMapDimensions.Width,
						pixelMapComponent.TileMapDimensions.Height,
						//pixelMapComponent.MapViewport.X + x,
						//pixelMapComponent.MapViewport.Y + y);
						xTileOffset + x,
						yTileOffset + y);

					//for (int layerNumber = 0; layerNumber <= pixelMapComponent.Map.Layers.Count - 1; layerNumber++)
					//{
						//var layer = pixelMapComponent.Map.Layers[layerNumber];
						//if (layer.Visible)

					var layer = pixelMapComponent.Map.Layers[0];
					if ((tileIndex <= layer.Tiles.Count - 1)
						&& (tileIndex >= 0))
					{
						int highestGid = 0;
						int highestLayerNumber = 0;
						for (int layerNumber = 0; layerNumber <= pixelMapComponent.Map.Layers.Count - 1; layerNumber++)
						{
							if ((layerNumber == 0 && showZero) || (layerNumber == 3 && showThree && pixelMapComponent.CeilingOn))
							{
								// Determine which tile in which layer to draw here.
								layer = pixelMapComponent.Map.Layers[layerNumber];
								var gid = layer.Tiles[tileIndex].Gid - 1;
								if (gid > 0)    // If it's 0, there is no tile here.  Do not draw anything.
								{
									highestGid = gid;
									highestLayerNumber = layerNumber;
								}
							}
						}

						if (highestGid > 0)
						{
							// Draw the tile.
							(int tileSheetX, int tileSheetY) = XyOfIndex(
								pixelMapComponent.TileSheetRowCols.Cols,
								pixelMapComponent.TileSheetRowCols.Rows,
								highestGid);

							// This rectangle is the region in the tilesheet where this single tile exists.
							Rectangle sourceRect = new Rectangle(
								tileSizeX * tileSheetX,
								tileSizeY * tileSheetY,
								tileSizeX,
								tileSizeY);

							//Rectangle sourceRect = new Rectangle(
							//	tileSizeX * tileSheetX, //tileSizeX * tileSheetX,
							//	tileSizeY * tileSheetY,
							//	tileSizeX,
							//	tileSizeY);

							//Rectangle sourceRect = new Rectangle(
							//	8 * 33,//tileSizeX * tileSheetX, //tileSizeX * tileSheetX,
							//	8 * 2, //tileSizeY * tileSheetY,
							//	8, //tileSizeX,
							//	8); //tileSizeY);

							//Rectangle sourceRect = new Rectangle(
							//	tileSizeX * tileSheetX, //tileSizeX * tileSheetX,
							//	tileSizeY * tileSheetY,
							//	tileSizeX,
							//	tileSizeY);

							//Rectangle destRect = new Rectangle(
							//	(x * tileSizeX + xDrawPosition) * scale,
							//	(y * tileSizeY + yDrawPosition) * scale,
							//	(x * tileSizeX + xDrawPosition) * scale + tileSizeX * scale,
							//	(y * tileSizeY + yDrawPosition) * scale + tileSizeY * scale);

							//Rectangle destRect = new Rectangle(
							//(xDrawPosition + x * tileSizeX),
							//	(yDrawPosition + y * tileSizeY),
							//	(xDrawPosition + x * tileSizeX) + tileSizeX,
							//	(yDrawPosition + y * tileSizeY) + tileSizeY);

							//Rectangle destRect = new Rectangle(
							//	(1 * 8) * scale,
							//	(1 * 8) * scale,
							//	32,//8 * scale,
							//	32//8 * scale
							//	);

							Rectangle destRect = new Rectangle(
								((-1 * xPixelOffset) + (x * tileSizeX)) * scale,
								((-1 * yPixelOffset) + (y * tileSizeY)) * scale,
								tileSizeX * scale,
								tileSizeY * scale
								);


							spriteBatch.Draw(pixelMapComponent.TileSheetImages[0], destRect, sourceRect, Color.White);
						}
					}
				}
			}

			spriteBatch.End();
		}

		public void Tick(GameTime gameTime)
		{
		}
	}
}
