using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Enemies;
using UltimateFiction.Data.Heroes;

namespace UltimateFiction.Data.Spells
{
	public interface ISpell
	{
		string Id { get; }
		string Name { get; }
		string Description { get; }
		MagicType Type { get; }
		int Level { get; }
		int Cost { get; }
		int Damage { get; }
		bool CastOnHero { get; }
		bool CastOnAllHeroes { get; }
		bool CastOnEnemy { get; set; }
		bool CastOnAllEnemies { get; set; }
		//Action<IEnumerable<IHero>, IEnumerable<IEnemy>> CastAction { get; }

		//void Cast(IEnumerable<IHero> heroes, IEnumerable<IEnemy> enemies);

		ISpell Clone(string id, string name, string description, MagicType type, int level, int damage, int cost, bool castOnHero, bool castOnAllHeroes, bool castOnEnemy, bool castOnAllEnemies);
		//,Action<IEnumerable<IHero>, IEnumerable<IEnemy>> castAction);
	}
}
