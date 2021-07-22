using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Data.Relics
{
	public interface IRelic
	{
		/// <summary> A value to compare Relics when searching a list.</summary>
		string Id { get; }

		/// <summary>The name that is displayed in the game.</summary>
		string Name { get; }

		/// <summary>The long description which is diplayed in the game.</summary>
		string Description { get; }
	}
}
