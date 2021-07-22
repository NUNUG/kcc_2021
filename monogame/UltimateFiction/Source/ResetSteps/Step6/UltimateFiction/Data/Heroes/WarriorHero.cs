using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Armors;
using UltimateFiction.Data.Weapons;

namespace UltimateFiction.Data.Heroes
{
	public class WarriorHero : Hero
	{
		public override HeroClass HeroClass => HeroClass.Warrior;

		public override WeaponType[] ValidWeapons => new[] { WeaponType.Dagger, WeaponType.Sword, WeaponType.Hammer};
		public override ArmorType[] ValidShieldArmors => new[] { ArmorType.SmallShield, ArmorType.Shield, ArmorType.RelicShield };
		public override ArmorType[] ValidBodyArmors => new[] { ArmorType.Clothes, ArmorType.LightArmor, ArmorType.HeavyArmor };
		public override ArmorType[] ValidHeadArmors => new[] { ArmorType.Headband, ArmorType.Helmet };
		public override ArmorType[] ValidGloveArmors => new[] { ArmorType.Gloves, ArmorType.Gauntlets };

		protected override int InitialStr => 10;
		protected override int InitialAgl => 10;
		protected override int InitialDex => 10;
		protected override int InitialLuck => 3;
		protected override int InitialMag => 0;
		protected override int InitialMaxHP => 30;
		protected override int InitialMaxMP => 0;

		protected override void CalculateHeroStats()
		{
			this.Str = InitialStr + (Level * 3);
			this.Agl = InitialAgl + (Level * 2);
			this.Dex = InitialDex + (Level);
			this.Luck = InitialLuck + Level;
			this.Mag = 0;
			this.MaxHP = InitialMaxHP + (int)(Level * 5);
			this.MaxMP = 0;
		}
	}
}
