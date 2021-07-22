using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Spells;

namespace UltimateFiction.Data.Enemies
{
	public interface IMonster
	{
		string Name { get; }
		(int Row, int Col) ImageRowCol { get; }

		int ExpReward { get; }
		int GoldReward { get; }
		int MaxHP { get; }
		int HP { get; }
		int MaxMP { get; }
		int MP { get; }

		int Level { get; }
		int Str { get; }
		int Agl { get; }
		int Dex { get; }
		int Mag { get; }
		int Luck { get; }
		List<ISpell> Spells { get; }
		IMonster Clone();
	}
}
