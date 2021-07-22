using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UltimateFiction.MonoGameHelpers;
using UltimateFiction.Sprites;

namespace UltimateFiction.ECS.Components
{
	public class SpriteAnimationComponent : Component
	{

		public Cooldown Cooldown { get; set; }
		/// <summary>The coordinates in the sprite sheet for all the frames in this animation.</summary>
		/// <remarks>All framesets exist in the spritesheet in a contiguous row.</remarks>
		public FrameSet Frames { get; set; }
		//public int FrameCount => Frames.Length;
		/// <summary>The current frame.</summary>
		public int CurrentFrameIndex { get; set; }
		protected int _animationSpeed;
		/// <summary>The number of frames per second to use in the animation.</summary>
		public int AnimationSpeed
		{
			get => _animationSpeed;
			set
			{
				if (_animationSpeed != value)
				{
					_animationSpeed = value;
					Cooldown.TotalTime = new TimeSpan(0, 0, 0, 0, 1000 / _animationSpeed);
				}
			}
		}

		public SpriteAnimationComponent(GameTime gameTime)
		{
			//Cooldown = new Cooldown(gameTime, true) { TotalTime = new TimeSpan(1000) };
			Cooldown = new Cooldown() { TotalTime = new TimeSpan(1000) };
			Cooldown.Reset(gameTime);
		}

		public void ResetCooldown(GameTime gameTime)
		{
			Cooldown.Reset(gameTime);
		}

		public void ExpireCooldown(GameTime gameTime)
		{
			Cooldown.EndTime = new GameTime(TimeSpan.FromMinutes(-1), TimeSpan.FromMinutes(-1));
		}

		public void ResetAnimation(GameTime gameTime)
		{
			CurrentFrameIndex = 0;
		}

		public override ComponentType ComponentType => ComponentType.FrameSetAnimation;

		public override void Tick(GameTime now)
		{
			//Cooldown.Tick(now);
		}
	}
}
