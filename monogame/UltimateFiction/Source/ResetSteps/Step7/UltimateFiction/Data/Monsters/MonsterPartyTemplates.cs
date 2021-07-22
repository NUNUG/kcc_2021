using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Zones;

namespace UltimateFiction.Data.Enemies
{
	public class MonsterPartyTemplates
	{
		public List<MonsterParty> Templates { get; }
		private readonly MonsterTemplates EnemyTemplates;
		private readonly ZoneTemplates ZoneTemplates;

		public MonsterPartyTemplates(MonsterTemplates enemyTemplates, ZoneTemplates zoneTemplates)
		{
			Templates = new List<MonsterParty>();
			EnemyTemplates = enemyTemplates;
			ZoneTemplates = zoneTemplates;
			Templates.AddRange(CreateTemplates(enemyTemplates));
		}

		private IEnumerable<IMonster> PartyFrom(params string[] names )
		{
			return names.Select(n => EnemyTemplates[n].Clone());
		}
		private IEnumerable<Zone> ZonesFrom(params Zone[] zones)
		{
			return zones.Select(z => z);
		}

		// TODO: Finish adding monster parties to the template list.
		private IEnumerable<MonsterParty> CreateTemplates(MonsterTemplates enemyTemplates)
		{
			yield return new MonsterParty("",
				PartyFrom("Imp"),
				ZonesFrom(ZoneTemplates[ZoneColor.DarkGreen, 1]));
			yield return new MonsterParty("",
				PartyFrom("Imp", "Imp", "Imp", "Imp"),
				ZonesFrom(ZoneTemplates[ZoneColor.DarkGreen, 1]));
			yield return new MonsterParty("",
				PartyFrom("Imp", "Imp", "Imp", "Imp", "Imp", "Imp", "Imp", "Imp", "Imp"),
				ZonesFrom(ZoneTemplates[ZoneColor.DarkGreen, 1]));
			yield return new MonsterParty("",
				PartyFrom("Imp", "Imp", "Imp", "Wolf"),
				ZonesFrom(ZoneTemplates[ZoneColor.DarkGreen, 2]));
			yield return new MonsterParty("",
				PartyFrom("Wolf", "Wolf"),
				ZonesFrom(ZoneTemplates[ZoneColor.DarkGreen, 2]));
			yield return new MonsterParty("",
				PartyFrom("Wolf", "Wolf", "Wolf", "Wolf"),
				ZonesFrom(ZoneTemplates[ZoneColor.DarkGreen, 2], ZoneTemplates[ZoneColor.DarkGreen, 3]));
			yield return new MonsterParty("",
				PartyFrom("Wolf", "Wolf", "Wolf", "Wolf", "Wolf", "Wolf", "Wolf", "Wolf", "Wolf"),
				ZonesFrom(ZoneTemplates[ZoneColor.DarkGreen, 3]));
		}
	}
}
