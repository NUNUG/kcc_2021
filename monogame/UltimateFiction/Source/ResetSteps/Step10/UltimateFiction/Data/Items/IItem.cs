using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Heroes;

namespace UltimateFiction.Data.Items
{
	public interface IItem
	{
		string Id { get; }
		string Name { get; }
		string Description { get; }
		Action<IHero> UseAction { get; }
		public bool UseInBattle { get; }

		void Apply(IEnumerable<IHero> hero);
		IItem Clone();
	}
}
