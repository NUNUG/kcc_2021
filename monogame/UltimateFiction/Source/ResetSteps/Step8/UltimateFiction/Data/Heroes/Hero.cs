using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Armors;
using UltimateFiction.Data.Spells;
using UltimateFiction.Data.Weapons;

namespace UltimateFiction.Data.Heroes
{
	public abstract class Hero : IHero
	{
		protected int InitialExp => 0;
		protected abstract int InitialStr { get; }
		protected abstract int InitialAgl { get; }
		protected abstract int InitialDex { get; }
		protected abstract int InitialLuck { get; }
		protected abstract int InitialMag { get; }
		protected abstract int InitialMaxHP { get; }
		protected abstract int InitialMaxMP { get; }


		public abstract HeroClass HeroClass { get; }
		public string Name { get; set; }
		public Equipment Equipment { get; set; }
		public bool IsDead { get; set; }

		public abstract WeaponType[] ValidWeapons { get; }
		public abstract ArmorType[] ValidShieldArmors { get; }
		public abstract ArmorType[] ValidBodyArmors { get; }
		public abstract ArmorType[] ValidHeadArmors { get; }
		public abstract ArmorType[] ValidGloveArmors { get; }

		public int Exp { get; set; }
		public int Level { get; set; }
		public int Str { get; set; }
		public int Agl { get; set; }
		public int Dex { get; set; }
		public int Mag { get; set; }
		public int Luck { get; set; }

		public int Attack { get; set; }
		public int Defense { get; set; }

		public int MaxHP { get; set; }
		public int HP { get; set; }
		public int MaxMP { get; set; }
		public int MP { get; set; }

		public List<ISpell> Spells {get;set; }

		public virtual IHero Initialize()
		{
			this.IsDead = false;
			this.Exp = InitialExp;
			this.Str = InitialStr;
			this.Agl = InitialAgl;
			this.Dex = InitialDex;
			this.Luck = InitialLuck;
			this.Mag = InitialMag;
			this.MaxHP = InitialMaxHP;
			this.MaxMP = InitialMaxMP;
			this.HP = this.MaxHP;
			this.MP = this.MaxMP;
			return this;
		}

		public Hero()
		{
			this.Spells = new List<ISpell>();
			this.Equipment = new Equipment();
			this.Exp = 0;
			this.Level = 1;
			this.Str = InitialStr;
			this.Agl = InitialAgl;
			this.Dex = InitialDex;
			this.Mag = InitialMag;
			this.Luck = InitialLuck;
			this.MaxHP = InitialMaxHP;
			this.HP = InitialMaxHP;
			this.MaxMP = InitialMaxMP;
			this.MP = InitialMaxMP;
			CalculateStats();
		}

		protected abstract void CalculateHeroStats();

		protected virtual IHero ApplyEquipmentStats()
		{
			Defense += Equipment.Head?.DefenseRating ?? 0;
			Defense += Equipment.Body?.DefenseRating ?? 0;
			Defense += Equipment.Gloves?.DefenseRating ?? 0;
			Defense += Equipment.Shield?.DefenseRating ?? 0;
			//Equipment.Head?.Apply(this);
			//Equipment.Body?.Apply(this);
			//Equipment.Gloves?.Apply(this);
			//Equipment.Shield?.Apply(this);

			Attack += Equipment.Weapon?.AttackRating ?? 0;
			//Equipment.Weapon?.Apply(this);
			return this;
		}

		public IHero CalculateStats()
		{
			CalculateHeroStats();
			ApplyEquipmentStats();
			return  this;
		}

		public IHero HealAll()
		{
			HP = MaxHP;
			MP = MaxMP;
			return this;
		}
	}
}
