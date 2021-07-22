using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Spells;

namespace UltimateFiction.Data.Enemies
{
	public class Monster : IMonster
	{
		public string Name { get; set; }

		public (int Row, int Col) ImageRowCol { get; set; }

		public int ExpReward { get; set; }
		public int GoldReward { get; set; }
		public int MaxHP { get; set; }
		public int HP { get; set; }
		public int MaxMP { get; set; }
		public int MP { get; set; }
		public int Level { get; set; }
		public int Str { get; set; }
		public int Agl { get; set; }
		public int Dex { get; set; }
		public int Mag { get; set; }
		public int Luck { get; set; }

		public List<ISpell> Spells { get; }

		public Monster(string name, (int Row, int Col) imageRowCol, int expReward, int goldReward, int hp,
			int mp, int level, int str, int agl, int dex, int mag, int luck, params ISpell[] spells)
		{
			this.Name = name;
			this.ImageRowCol = imageRowCol;
			this.ExpReward = expReward * 4;	// There must be at least 1 point for each party member.  This makes it easier.
			this.GoldReward = goldReward;
			this.MaxHP = hp;
			this.HP = hp;
			this.MaxMP = mp;
			this.MP = mp;
			this.Level = level;
			this.Str = str;
			this.Agl = agl;
			this.Dex = dex;
			this.Mag = mag;
			this.Luck = luck;
			Spells = new List<ISpell>(spells);
		}

		public IMonster Clone()
		{
			return new Monster(Name, ImageRowCol, ExpReward, GoldReward, MaxHP, MaxMP, Level, Str, Agl, Dex, Mag, Luck, Spells.ToArray())
			{
				HP = this.HP,
				MP = this.MP
			};
		}
	}
}
