using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using UltimateFiction.ECS.Entities;

namespace UltimateFiction.ECS.Components
{
	public class SequenceComponent : Component, ISequenceComponent
	{
		public override ComponentType ComponentType => ComponentType.Sequence;

		public IEnumerable<float> Sequence { get; }
		private IEnumerator<float> enumerator;
		private int repeatsRemaining;
		//private bool nextResult;

		public bool RepeatForever { get; set; }
		public int RepeatCount { get; set; }
		public float Scale { get; set; }
		public bool RemoveOnCompletion { get; set; }
		public string TargetId { get; set; }
		public Action<Component, float> Apply { get; set; }

		public float Advance()
		{
			bool nextResult = enumerator.MoveNext();
			if (!nextResult)
			{
				if (RepeatForever || (!RepeatForever && (repeatsRemaining > 0)))
				{
					repeatsRemaining = Math.Max(repeatsRemaining - 1, 0);
					enumerator = Sequence.GetEnumerator();
					nextResult = enumerator.MoveNext();
					if (nextResult)
						return enumerator.Current;
					else
					{
						Close();
						return 0f;
					}
				}
				else
				{
					Close();
					return 0f;
				}
			}
			else
				return enumerator.Current;
		}

		public void Close()
		{
			if (RemoveOnCompletion)
			{
				this.RemovalRequested = true;
			}

			CompletionScript?.Invoke(this);
		}

		public Action<Component> CompletionScript { get; set; }

		public SequenceComponent(IEnumerable<float> sequence)
		{
			Sequence = sequence;
			RepeatForever = true;
			RepeatCount = 0;
			Scale = 1.0f;
			RemoveOnCompletion = false;

			repeatsRemaining = RepeatCount;
			enumerator = Sequence.GetEnumerator();
		}

		public SequenceComponent(IEnumerable<int> sequence)
			: this(sequence.Select(i => (float)i)) { }

		public override void Tick(GameTime now)
		{
			throw new NotImplementedException();
		}
	}
}
