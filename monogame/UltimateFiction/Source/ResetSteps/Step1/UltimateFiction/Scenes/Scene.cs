using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using UltimateFiction.GameCode;

namespace UltimateFiction.Scenes
{
	public abstract class Scene : IScene
	{
		protected KeyboardState prevKbdState;
		protected KeyboardState kbdState;
		protected SceneController sceneController;
		public abstract string Name { get; }

		public virtual void Activate(SceneController sceneController)
		{
			this.sceneController = sceneController;
			prevKbdState = Keyboard.GetState();
		}

		public virtual void Deactivate()
		{
			
		}

		public abstract void Tick(GameTime gameTime);
		public abstract void Initialize();
		public abstract void LoadContent();
		public abstract void Update(GameTime gameTime);
		public abstract void Draw(GameTime gameTime);

		protected virtual bool CheckForKeyPress(Keys keyToCheckFor)
		{
			return kbdState.IsKeyDown(keyToCheckFor) && !prevKbdState.IsKeyDown(keyToCheckFor);
		}

		protected InputState ReadInput()
		{
			kbdState = Keyboard.GetState();
			var result = new InputState()
			{
				EscPressed = CheckForKeyPress(Keys.Escape),
				UpArrowPressed = CheckForKeyPress(Keys.Up),
				DownArrowPressed = CheckForKeyPress(Keys.Down),
				LeftArrowPressed = CheckForKeyPress(Keys.Left),
				RightArrowPressed = CheckForKeyPress(Keys.Right),
				ZButtonPressed = CheckForKeyPress(Keys.Z),
				XButtonPressed = CheckForKeyPress(Keys.X),

				UpArrowHeld = kbdState.IsKeyDown(Keys.Up),
				DownArrowHeld = kbdState.IsKeyDown(Keys.Down),
				LeftArrowHeld = kbdState.IsKeyDown(Keys.Left),
				RightArrowHeld = kbdState.IsKeyDown(Keys.Right),
			};
			prevKbdState = kbdState;
			return result;
		}

		public override string ToString()
		{
			return $"{Name}";
		}
	}
}
