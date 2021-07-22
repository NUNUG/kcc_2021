using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Armors;
using UltimateFiction.Data.Weapons;

namespace UltimateFiction.Data.Heroes
{
	public class BlackBeltHero : Hero
	{
		public override HeroClass HeroClass => throw new NotImplementedException();
		public override WeaponType[] ValidWeapons => new WeaponType[] { };
		public override ArmorType[] ValidShieldArmors => new ArmorType[] { };
		public override ArmorType[] ValidBodyArmors => new[] { ArmorType.LightArmor, ArmorType.Clothes };
		public override ArmorType[] ValidHeadArmors => new[] { ArmorType.Headband };
		public override ArmorType[] ValidGloveArmors => new[] { ArmorType.Gauntlets, ArmorType.Gloves };
		protected override int InitialStr => 10;
		protected override int InitialAgl => 10;
		protected override int InitialDex => 10;
		protected override int InitialLuck => 3;
		protected override int InitialMag => 0;
		protected override int InitialMaxHP => 30;
		protected override int InitialMaxMP => 0;

		protected override void CalculateHeroStats()
		{
			Str = InitialStr + (int)(Level * 2);
			Agl = InitialAgl + (int)(Level * 3);
			Dex = InitialDex + (int)(Level * 4);
			Luck = InitialLuck + (int)(Level * 2);
			Mag = 0;
			MaxHP = InitialMaxHP + (int)(Level * 5);
			MaxMP = 0;
		}
	}
}
