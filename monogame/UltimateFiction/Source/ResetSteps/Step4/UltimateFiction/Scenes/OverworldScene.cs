/*
**********************************************************************************************
* Ultimate Fiction
**********************************************************************************************
*
**********************************************************************************************
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Entities;
using UltimateFiction.GameCode;
using UltimateFiction.Services;

namespace UltimateFiction.Scenes
{
	public class OverworldScene : AbstractOverworldScene
	{
		public OverworldScene(GameSettings gameSettings, GameContent gameContent, GameTime gameTime, List<Entity> entities, GameStorage gameStorage, TileMapService tileMapService)
			: base(gameSettings, gameContent, gameTime, entities, gameStorage, tileMapService)
		{
		}

		public override void Update(GameTime gameTime)
		{
		}
	}
}
