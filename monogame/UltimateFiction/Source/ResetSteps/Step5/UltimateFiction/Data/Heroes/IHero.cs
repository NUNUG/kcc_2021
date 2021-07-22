using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Armors;
using UltimateFiction.Data.Weapons;

namespace UltimateFiction.Data.Heroes
{
	public interface IHero
	{
		HeroClass HeroClass { get; }
		string Name { get; set; }
		public Equipment Equipment { get; set; }

		public abstract WeaponType[] ValidWeapons { get; }
		public abstract ArmorType[] ValidShieldArmors { get; }
		public abstract ArmorType[] ValidBodyArmors { get; }
		public abstract ArmorType[] ValidHeadArmors { get; }
		public abstract ArmorType[] ValidGloveArmors { get; }

		int MaxHP { get; set; }
		int HP { get; set; }
		int MaxMP { get; set; }
		int MP { get; set; }

		int Level { get; set; }
		int Str { get; set; }
		int Agl { get; set; }
		int Dex { get; set; }
		int Mag { get; set; }
		int Luck { get; set; }

		IHero CalculateStats();
		IHero Initialize();
		IHero HealAll();
	}
}
