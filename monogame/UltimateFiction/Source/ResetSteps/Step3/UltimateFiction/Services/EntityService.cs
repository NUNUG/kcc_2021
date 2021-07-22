using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.ECS.Entities;

namespace UltimateFiction.Services
{
	public class EntityService
	{
		public const string PLAYER_SPRITE_NAME = "PlayerSprite";
		public const string BACKGROUND_TILE_MAP_NAME = "BackgroundTileMap";

		public Entity EntityByName(IEnumerable<Entity> entities, string name)
		{
			return entities.FirstOrDefault(e => e.Name == name);
		}
	}
}
