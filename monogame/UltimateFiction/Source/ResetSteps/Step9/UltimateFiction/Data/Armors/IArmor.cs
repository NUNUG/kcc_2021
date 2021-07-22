using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Data.Armors
{
	public interface IArmor
	{
		string Id { get; }
		string Name { get; }
		string Description { get; }
		ArmorType ArmorType { get; }
		int DefenseRating { get; }

		IArmor Clone();
	}
}
