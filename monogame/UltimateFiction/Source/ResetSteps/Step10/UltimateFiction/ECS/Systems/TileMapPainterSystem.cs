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
	//public class TileMapPainterSystem : IEcsSystem
	//{
	//	protected readonly GraphicsDevice graphicsDevice;

	//	public TileMapPainterSystem(GraphicsDevice graphicsDevice)
	//	{
	//		this.graphicsDevice = graphicsDevice;
	//	}

	//	public void Execute(GameTime gameTime, IEnumerable<Entity> entities)
	//	{
	//		var components = entities
	//			.SelectMany(e => e.Components, (e, c) => new { Entity = e, Component = c })
	//			.Where(x => x.Component.ComponentType == ComponentType.TileMap)
	//			.OrderBy(x => (x.Component as TileMapComponent).Depth);

	//		SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);
	//		foreach (var component in components)
	//		{
	//			PaintTileMap(gameTime, spriteBatch, (TileMapComponent)component.Component);
	//		}
	//	}

	//	private (int X, int Y) XyOfIndex(int mapWidth, int mapHeight, int gid)
	//	{
	//		int row = gid / mapWidth;
	//		int col = gid % mapWidth;
	//		return (col, row);
	//	}

	//	private int IndexOfXy(int mapWidth, int mapHeight, int x, int y)
	//	{
	//		return y * mapWidth + x;
	//	}

	//	public void PaintTileMap(GameTime gameTime, SpriteBatch spriteBatch, TileMapComponent tileMapComponent)
	//	{
	//		spriteBatch.Begin(
	//			SpriteSortMode.FrontToBack,
	//			BlendState.AlphaBlend,
	//			SamplerState.PointClamp
	//		);

	//		(int tileSizeX, int tileSizeY) = tileMapComponent.TileDimensions;
	//		(int xDrawPosition, int yDrawPosition) = tileMapComponent.DrawPosition;
	//		for (int y = 0; y <= tileMapComponent.MapViewport.TilesWide - 1; y++)
	//		{
	//			for (int x = 0; x <= tileMapComponent.MapViewport.TilesHigh - 1; x++)
	//			{
	//				var tileindex = IndexOfXy(
	//					tileMapComponent.TileMapDimensions.Width,
	//					tileMapComponent.TileMapDimensions.Height,
	//					tileMapComponent.MapViewport.X + x,
	//					tileMapComponent.MapViewport.Y + y);

	//				for (int layerNumber = tileMapComponent.Map.Layers.Count - 1; layerNumber >= 0; layerNumber--)
	//				{
	//					var layer = tileMapComponent.Map.Layers[layerNumber];
	//					if (layer.Visible)
	//					{
	//						var gid = layer.Tiles[tileindex].Gid - 1;
	//						if (gid != 0)	// If Gid = is 0, there is no tile here.  Do nothing.
	//						{
	//							(int tilex, int tiley) = XyOfIndex(
	//								tileMapComponent.TileSheetRowCols.Cols,
	//								tileMapComponent.TileSheetRowCols.Rows, gid);

	//							var scale = tileMapComponent.DrawScale;
	//							Rectangle sourceRect = new Rectangle(tileSizeX * tilex, tileSizeY * tiley, tileSizeX, tileSizeY);
	//							Rectangle destRect = new Rectangle((int)((x * tileSizeX + xDrawPosition) * scale), (int)((y * tileSizeY + yDrawPosition) * scale), (int)(tileSizeX * scale), (int)(tileSizeY * scale));

	//							spriteBatch.Draw(tileMapComponent.TileSheetImages[0], destRect, sourceRect, Color.White);
	//						}
	//					}
	//				}
	//			}
	//		}
	//		spriteBatch.End();
	//	}

	//	public void Tick(GameTime gameTime)
	//	{
	//	}
	//}
}
