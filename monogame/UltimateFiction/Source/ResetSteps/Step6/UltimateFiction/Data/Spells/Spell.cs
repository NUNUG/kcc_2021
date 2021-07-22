using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Enemies;
using UltimateFiction.Data.Heroes;

namespace UltimateFiction.Data.Spells
{
	public class Spell : ISpell
	{
		public string Id { get; set; }
		public string Name { get; }
		public string Description { get; }
		public MagicType Type { get; }
		public int Level { get; }
		public int Damage { get; }
		public int Cost { get; }
		public bool CastOnHero { get; }
		public bool CastOnAllHeroes { get; }
		public bool CastOnEnemy { get; set; }
		public bool CastOnAllEnemies { get; set; }
		public Action<IEnumerable<IHero>, IEnumerable<IMonster>> CastAction { get; }

		public Spell(string id, string name, string description, MagicType type, int level, int damage, int cost, bool castOnHero, bool castOnAllHeroes, bool castOnEnemy, bool castOnAllEnemies)
			//,Action<IEnumerable<IHero>, IEnumerable<IEnemy>> castAction)
		{
			this.Id = id;
			this.Name = name;
			this.Description = description;
			this.Type = type;
			this.Level = level;
			this.Damage = damage;
			this.Cost = cost;
			this.CastOnHero = castOnHero;
			this.CastOnAllHeroes = castOnAllHeroes;
			this.CastOnEnemy = castOnEnemy;
			this.CastOnAllEnemies = castOnAllEnemies;
			//this.CastAction = castAction;
		}

		public void Cast(IEnumerable<IHero> heroes, IEnumerable<IMonster> enemies)
		{
			CastAction?.Invoke(heroes, enemies);
		}

		public ISpell Clone(string id, string name, string description, MagicType type, int level, int damage, int cost, bool castOnHero, bool castOnAllHeroes, bool castOnEnemy, bool castOnAllEnemies)
		//,Action<IEnumerable<IHero>, IEnumerable<IEnemy>> castAction)
		{
			return new Spell(id, name, description, type, level, damage, cost, castOnHero, castOnAllHeroes, castOnEnemy, castOnAllEnemies /*, castAction*/);
		}
	}
}
