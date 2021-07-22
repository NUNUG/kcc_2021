using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.ECS.Engine
{
	public class GameScript : IGameScript
	{
		protected object data;
		protected Action<object> scriptFunction;

		public GameScript(object data, Action<object> scriptFunction)
		{
			this.data = data;
			this.scriptFunction = scriptFunction;
		}

		public void Execute()
		{
			scriptFunction?.Invoke(data);
		}
	}
}
