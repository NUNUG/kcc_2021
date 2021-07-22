using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.ECS.Entities;

namespace UltimateFiction.ECS.Components
{
	public interface ISequenceComponent
	{
		string Id { get; set; }
		bool Active { get; set; }
		bool RepeatForever { get; set; }
		int RepeatCount { get; set; }
		float Scale { get; set; }
		bool RemoveOnCompletion { get; set; }
		float Advance();
		string TargetId { get; set; }
		Action<Component, float> Apply { get; set; }

		Action<Component> CompletionScript { get; set; }
	}
}
