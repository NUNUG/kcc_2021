using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Entities;
using UltimateFiction.Tiling;

namespace UltimateFiction.Services
{
	public class TileMapService
	{
		protected readonly int screenScale;
		public const string BACKGROUND_TILEMAP_ID = "BackgroundTileMapId";
		public Dictionary<string, TileMapComponent> TileMapComponents;

		public TileMapService(Dictionary<string, TileMapComponent> tileMapComponents)
		{
			TileMapComponents = tileMapComponents;
		}

		public TileMapComponent UseBackgroundTileMap(Entity entity, string tileMapId)
		{
			// Remove the old background component.
			var oldBackground = entity.Components.FirstOrDefault(c =>
				c.ComponentType == ComponentType.TileMap && 
				(c as TileMapComponent).Id == BACKGROUND_TILEMAP_ID);

			if (oldBackground != null)
			{
				((TileMapComponent)oldBackground).Visible = false;
				oldBackground.Active = false;
				entity.Components.Remove(oldBackground);
			}

			// Set the new background component.
			var newTileMapComponent = TileMapComponents[tileMapId];
			entity.Components.Add(newTileMapComponent);
			((TileMapComponent)newTileMapComponent).Visible = true;
			newTileMapComponent.Active = true;
			return newTileMapComponent;
		}
	}
}
