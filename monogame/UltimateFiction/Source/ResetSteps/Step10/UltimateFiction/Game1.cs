using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TiledSharp;
using UltimateFiction.ECS;
using UltimateFiction.ECS.Components;
using UltimateFiction.ECS.Entities;
using UltimateFiction.ECS.Systems;
using UltimateFiction.GameCode;
using UltimateFiction.MonoGameHelpers;
using UltimateFiction.Scenes;
using UltimateFiction.Services;
using UltimateFiction.Sprites;
using UltimateFiction.Tiling;

namespace UltimateFiction
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private SceneController sceneController;

		private (int Width, int Height) BaseScreenDimensions;
		private int ScreenScale = 8;
		private (int Width, int Height) ScreenDimensions;
		private bool IsFullScreen = false;

		// Builders and content
		private GameContent GameContent;
		private GameStorage GameStorage;
		private GameSettings GameSettings;
		private GameCreator GameCreator;
		public List<Entity> Entities;
		public Dictionary<string, TileMapComponent> TileMapComponents;

		// Services
		private TileMapService TileMapService;
		private SystemsService SystemsService;

		// Player IO
		private KeyboardState oldKbdState;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// Set the screen resolution.  I should be able to do this in the constructor, but had to move it to the Initialize() method due to a bug in Monogame 3.8.0.  It should be fixed in 3.8.1.
			BaseScreenDimensions = (128, 128);
			ScreenDimensions = (BaseScreenDimensions.Width * ScreenScale, BaseScreenDimensions.Height * ScreenScale);
			graphics.PreferredBackBufferWidth = ScreenDimensions.Width;
			graphics.PreferredBackBufferHeight = ScreenDimensions.Height;
			graphics.IsFullScreen = IsFullScreen;
			graphics.ApplyChanges();

			GameSettings = new GameSettings()
			{
				PlayerTilePosition = (7, 7),
				TileSize = (8, 8),
				TileViewPortSize = (16, 16),
				Scale = this.ScreenScale,
				ScreenSize = this.ScreenDimensions
			};

			GameCreator = new GameCreator();
			oldKbdState = Keyboard.GetState();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			
			GameContentLoader contentLoader = new GameContentLoader();
			GameContent = contentLoader.LoadContent(Content);
			GameStorage = new GameStorage();
			GameCreator.CreateAll(GameSettings, GraphicsDevice, GameContent, ScreenScale);
			Entities = GameCreator.Entities;
			TileMapService = GameCreator.TileMapService;
			SystemsService = GameCreator.SystemsService;
			TileMapComponents = GameCreator.TileMapComponents;

			// How to use TiledSharp (example).  Ignore the way they load the content.  It doesn't work that way and they outright lie.
			//https://github.com/Temeez/TiledSharp-MonoGame-Example/blob/master/TiledSharp%20MonoGame%20Example/Game1.cs

			sceneController = new SceneController(this, GameSettings, GameContent, GameStorage, Entities, TileMapService);
			sceneController.Initialize();	// This couldn't be called in this.Initialize() due to dependency availability.
			sceneController.LoadContent();

			sceneController.NavigateToScene(sceneController.StartMenuScene);
		}

		protected bool CheckForKeyPress(KeyboardState kbdState, Keys keyToCheckFor)
		{
			return kbdState.IsKeyDown(keyToCheckFor) && !oldKbdState.IsKeyDown(keyToCheckFor);
		}

		protected override void Update(GameTime gameTime)
		{
			// Close if ESC is pressed.
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			SystemsService.UpdateAll(gameTime, Entities);
			SystemsService.TickAll(gameTime);
			sceneController.Tick(gameTime);
			sceneController.Update(gameTime);

			base.Update(gameTime);
		}


		protected override void Draw(GameTime gameTime)
		{
			// Need this, I guess.  If the screen fails to paint, I get the WEIRDEST
			// behavior where it shows the title screen on the screen, text, sprites,
			// tilemap and all, even though those objects have been completely destroyed
			// and the systems are not actually processing them.  Some remnant in the
			// memory of the graphics card maybe?  Had this face when I saw it:  >8O
			graphics.GraphicsDevice.Clear(Color.Black);

			SystemsService.DrawAll(gameTime, Entities);
			base.Draw(gameTime);
		}
	}
}
