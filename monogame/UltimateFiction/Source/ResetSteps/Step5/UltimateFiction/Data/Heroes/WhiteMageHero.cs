using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Armors;
using UltimateFiction.Data.Weapons;

namespace UltimateFiction.Data.Heroes
{
	public class WhiteMageHero : Hero
	{
		public override HeroClass HeroClass => HeroClass.WhiteMage;
		protected override int InitialStr => 3;
		protected override int InitialAgl => 3;
		protected override int InitialDex => 3;
		protected override int InitialLuck => 5;
		protected override int InitialMag => 5;
		protected override int InitialMaxHP => 20;
		protected override int InitialMaxMP => 30;

		public override WeaponType[] ValidWeapons => new[] { WeaponType.Hammer, WeaponType.Staff };
		public override ArmorType[] ValidShieldArmors => new[] { ArmorType.RelicShield };
		public override ArmorType[] ValidBodyArmors => new[] { ArmorType.Clothes };
		public override ArmorType[] ValidHeadArmors => new[] { ArmorType.Headband };
		public override ArmorType[] ValidGloveArmors => new[] { ArmorType.Gloves };

		protected override void CalculateHeroStats()
		{
			Str = InitialStr + (int)(Level * 0.5);
			Agl = InitialAgl + (int)(Level * 0.5);
			Dex = InitialDex + (int)(Level * 0.5);
			Luck = InitialLuck + (int)(Level * 1.5);
			Mag = InitialMag + (int)(Level * 3);
			MaxHP = InitialMaxHP + (int)(Level * 3);
			MaxMP = InitialMaxMP + (int)(Level * 3);
		}
	}
}
