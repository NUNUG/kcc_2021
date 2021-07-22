using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Zones;

namespace UltimateFiction.Data.Enemies
{
	public class MonsterParty
	{
		public string Name { get; set; }
		public List<IMonster> Monsters { get; }
		public List<Zone> Zones { get; }

		public MonsterParty(string name, IEnumerable<IMonster> monsters, IEnumerable<Zone> zones)
		{
			this.Name = name;
			Monsters = new List<IMonster>(monsters);
			Zones = new List<Zone>(zones);
		}
	}
}
