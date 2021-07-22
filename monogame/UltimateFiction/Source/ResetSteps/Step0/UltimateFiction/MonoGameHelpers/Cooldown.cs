using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace UltimateFiction.MonoGameHelpers
{
	public class Cooldown : Cooldown<object> { }
	public class Cooldown<T>
	{
		public Cooldown()
		{
			StartTime = new GameTime(new TimeSpan(0), new TimeSpan(0));
			EndTime = new GameTime(new TimeSpan(0), new TimeSpan(0));
			TotalTime = new TimeSpan(0);
		}

		protected TimeSpan _totalTime;
		public TimeSpan TotalTime
		{
			get => _totalTime;
			set
			{
				if (_totalTime != value)
				{
					_totalTime = value;
					EndTime = AddToGameTime(StartTime, (int)_totalTime.TotalMilliseconds);
				}
			}
		}

		public static TimeSpan FromFrameCount(int framesPerSecond, int cooldownFrames)
		{
			int msPerFrame = 1000 / framesPerSecond;
			int cooldownMs = msPerFrame * cooldownFrames;
			return new TimeSpan(0, 0, 0, 0, cooldownMs);
		}

		public static TimeSpan From(int cooldownsPerSecond)
		{
			int msPerCooldown = 1000 / cooldownsPerSecond;
			return new TimeSpan(0, 0, 0, 0, msPerCooldown);
		}

		public void Reset(GameTime gameTime)
		{
			StartTime = gameTime;
			EndTime = AddToGameTime(StartTime, (int)_totalTime.TotalMilliseconds);
		}

		public GameTime StartTime { get; set; }
		public GameTime EndTime { get; set; }
		public TimeSpan Remaining => new TimeSpan(0, 0, 0, 0, (int)(EndTime.TotalGameTime.TotalMilliseconds - StartTime.TotalGameTime.TotalMilliseconds));
		public bool Expired(GameTime gameTime) =>
			EndTime.TotalGameTime.TotalMilliseconds < gameTime.TotalGameTime.TotalMilliseconds;

		protected GameTime AddToGameTime(GameTime baseTime, int millisecondsToAdd)
		{
			TimeSpan timeToAdd = new TimeSpan(0, 0, 0, 0, millisecondsToAdd);
			var result = new GameTime(baseTime.TotalGameTime.Add(timeToAdd), baseTime.ElapsedGameTime);
			return result;
		}
	}
}
