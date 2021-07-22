using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Data.Relics
{
	public class RelicTemplates
	{
		public static string RELIC_AIRSHIP = "relic_airship";
		public static string RELIC_SHIP = "relic_ship";
		public static string RELIC_BOOTS = "relic_boots";
		public static string RELIC_CANOE = "relic_canoe";
		public static string RELIC_CHOCOBO = "relic_chocobo";
		public static string RELIC_FLOATER = "relic_floater";

		public List<IRelic> Templates { get; }

		public RelicTemplates()
		{
			Templates = new List<IRelic>();
			foreach (var relic in CreateTemplates()) Templates.Add(relic);
		}

		public static IEnumerable<IRelic> CreateTemplates()
		{
			yield return new Relic(RELIC_AIRSHIP, "Airship", "Your own personal aircraft.");
			yield return new Relic(RELIC_SHIP, "Ship", "A might craft for sailing the ocean. Use it at any port.");
			yield return new Relic(RELIC_BOOTS, "Lava Boots", "These allow you to walk in the volcano.");
			yield return new Relic(RELIC_CANOE, "Canoe", "A small, nimble craft for traversing rivers.");
			yield return new Relic(RELIC_CHOCOBO, "Chocobo", "You will not encounter enemies when you ride this bird.");
			yield return new Relic(RELIC_FLOATER, "Floater", "This odd stone hovers above your hand.");
		}
	}
}
