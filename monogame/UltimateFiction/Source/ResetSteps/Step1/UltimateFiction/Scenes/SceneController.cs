using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UltimateFiction.Data;
using UltimateFiction.ECS.Entities;
using UltimateFiction.GameCode;
using UltimateFiction.Services;

namespace UltimateFiction.Scenes
{
	public class SceneController : ISceneController
	{
		protected readonly Game game;
		protected readonly GameSettings gameSettings;
		protected readonly Stack<IScene> sceneStack;
		protected readonly GameContent gameContent;
		protected readonly GameStorage gameStorage;
		protected readonly TileMapService tileMapService;

		public IScene CurrentScene => sceneStack.Peek();
		public IScene StartMenuScene { get; }
		public IScene BattleScene { get; }
		public IScene MenuScene { get; }
		public IScene OverworldScene { get; }
		public IShopScene ShopScene { get; }
		public IScene DialogScene { get; }

		public List<IScene> AllScenes { get; }

		public SceneController(
			Game game,
			GameSettings gameSettings,
			GameContent gameContent,
			GameStorage gameStorage,
			List<Entity> entities,
			TileMapService tileMapService)
		{
			this.game = game;
			this.gameSettings = gameSettings;
			this.gameContent = gameContent;
			this.gameStorage = gameStorage;
			this.tileMapService = tileMapService;
			GameTime gameTime = new GameTime(new TimeSpan(0), new TimeSpan(0));
			StartMenuScene = new StartMenuScene(gameSettings, gameContent, gameTime, entities, gameStorage, tileMapService);
			BattleScene = new BattleScene();
			MenuScene = new MenuScene();
			OverworldScene = new OverworldScene(gameSettings, gameContent, gameTime, entities, gameStorage, tileMapService);
			ShopScene = new ShopScene(gameSettings, gameContent, gameTime, entities, gameStorage, tileMapService);
			DialogScene = new DialogScene(gameSettings, entities, tileMapService);

			AllScenes = new List<IScene>()
			{
				StartMenuScene,
				BattleScene,
				MenuScene,
				OverworldScene,
				ShopScene,
				DialogScene
			};

			sceneStack = new Stack<IScene>();
		}

		public void Activate(SceneController sceneController)
		{
			// Do nothing.
		}
		public void Deactivate()
		{
			// Do nothing.
		}

		public void EndCurrentScene()
		{
			// Terminate this scene and go back the next one in the stack.
			// This is usually requested by the current scene itself, when it's done doing its job.
			if (sceneStack.Count > 1)
			{
				sceneStack.Peek().Deactivate();
				sceneStack.Pop();
			}
			else
				game.Exit();

			sceneStack.Peek().Activate(this);
		}

		public void NavigateToScene(IScene newScene, bool addToStack = true)
		{
			// Deactivate the current scene.
			if (sceneStack.Count > 0)
				sceneStack.Peek().Deactivate();

			// If addToStack is true, we add the new scene on top of the stack so that the 
			// current scene will be the one we return to.  Otherwise, we remove the current 
			// scene from the stack and replace it with the new scene.
			if (!addToStack && (sceneStack.Count > 0))
				sceneStack.Pop();
			sceneStack.Push(newScene);

			// Now that the new scene is on the stack, activate it.
			newScene.Activate(this);
		}

		public void Tick(GameTime gameTime) => AllScenes.ForEach(scene => scene.Tick(gameTime));
		

		public void Initialize()
		{
			AllScenes.ForEach(scene => scene.Initialize());
		}

		
		public void LoadContent()
		{
			AllScenes.ForEach(scene => scene.LoadContent());
		}

		public void Update(GameTime gameTime)
		{
			CurrentScene.Update(gameTime);
		}

		public void Draw(GameTime gameTime)
		{
			CurrentScene.Draw(gameTime);
		}
	}
}
