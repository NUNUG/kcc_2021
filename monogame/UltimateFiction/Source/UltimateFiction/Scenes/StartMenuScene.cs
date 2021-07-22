/*
**********************************************************************************************
* Ultimate Fiction Step 1 - Start here
**********************************************************************************************
* This is the main program file for the title screen.  It has some functionality built into it
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
using UltimateFiction.ECS.Engine;
using UltimateFiction.ECS.Entities;
using UltimateFiction.GameCode;
using UltimateFiction.Services;
using UltimateFiction.Sprites;

namespace UltimateFiction.Scenes
{
	public class StartMenuScene : AbstractStartMenuScene
	{
		public StartMenuScene(GameSettings gameSettings, GameContent gameContent, GameTime gameTime, List<Entity> entities, GameStorage gameStorage, TileMapService tileMapService) : base(gameSettings, gameContent, gameTime, entities, gameStorage, tileMapService)
		{
		}

		public override void Activate(SceneController sceneController)
		{
			base.Activate(sceneController);

		}

		public override void Deactivate()
		{
			base.Deactivate();

		}

		public override void Update(GameTime gameTime)
		{

		}
	}
}
