using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UltimateFiction.MonoGameHelpers;

namespace UltimateFiction.ECS.Components
{
	//public class CounterComponent : Component, ISyncable
	//{
	//	public Cooldown Cooldown { get; set; }
	//	public string SyncPulseName { get; set; }
	//	public override ComponentType ComponentType => ComponentType.Counter;
	//	public int Value { get; protected set; }
	//	public int FramesPerSecond { get; set; }
	//	public int Min { get; set; }
	//	public int Max { get; set; }
	//	public Action<CounterComponent, GameTime> EndAction { get; set; }
	//	public bool AutoRepeat { get; set; }
		
	//	public void Reset()
	//	{
	//		Value = Min;
	//	}

	//	public void Syncronize(SyncPulseComponent syncPulse)
	//	{
	//		Reset();
	//	}

	//	public override void Tick(GameTime now)
	//	{
	//		throw new NotImplementedException();
	//	}
	//}
}
