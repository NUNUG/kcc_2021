using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UltimateFiction.Scenes
{
	public interface IScene
	{
		void Activate(SceneController sceneController);
		void Deactivate();

		void Tick(GameTime gameTime);
		void Initialize();
		void LoadContent();
		void Update(GameTime gameTime);
		void Draw(GameTime gameTime);
	}
}
