using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Spells;

namespace UltimateFiction.Data.Enemies
{
	public class MonsterTemplates
	{
		public List<IMonster> Templates { get; }

		public MonsterTemplates()
		{
			Templates = new List<IMonster>();
			Templates.AddRange(CreateTemplates());
		}

		public IMonster this[string name] => Templates.FirstOrDefault(t => t.Name == name);

		// TODO: Go through and give these guys valid stats.  They are all just cut and pasted right now.   The Name and ImageIndex should already be correct though.
		public static IEnumerable<IMonster> CreateTemplates()
		{
			yield return new Monster("Wolf", (0, 8), 1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("GrayWolf", (0, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("ArcticWolf", (0, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("WereWolf", (0, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Clifford", (0, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Clifette", (0, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Rabid Dog", (0, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Albino Wolf", (0, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Brown Bear", (1, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Black Bear", (1, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Arctic Bear", (1, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Mutant Bear", (1, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Kodiak Bear", (1, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Domesticated Bear", (1, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Grizzly Bear", (1, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Polar Bear", (1, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Imp", (2 ,8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Bandit", (2, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Brigand", (2, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Leprechaun", (2, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Robber", (2, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Burglar", (2, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Henchman", (2, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Soldier", (2, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Shrimp", (3, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Crawdad", (3, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Crawfish", (3, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Crayfish", (3, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Lobster", (3, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Hermit Crab", (3, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Beach Crab", (3, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("King Crab", (3, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Dirt Lizard", (4, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Dark Lizard", (4, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Ice Newt", (4, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Poison Lizard", (4, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Fire Gecko", (4, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Salamander", (4, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Sun Crawler", (4, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Ghost Gecko", (4, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Earthworm Jim", (5, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Black Mamba", (5, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Tapeworm", (5, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Python", (5, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Coral Snake", (5, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Blood serpent", (5, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Copperhead", (5, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Albino Cobra", (5, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Moai", (6, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Ash Skeleton", (6, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Ice Bones", (6, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Poisoned Remains", (6, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Lava Guardian", (6, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Stalker", (6, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Sand Skeleton", (6, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Bleached Bones", (6, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Earth Bat", (7, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Pygmy Bat", (7, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Ice Bat", (7, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Poison Bat", (7, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Vampire Bat", (7, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Baseball Bat", (7, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Citrus Bat", (7, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Albino Bat", (7, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Earth Demon", (8, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Gargoyle", (8, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Ice Demon", (8, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Venomous Demon", (8, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("HellBoy", (8, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Cherry Demon", (8, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Scorpan", (8, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Ozian Monkey", (8, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Starling", (9, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Magpie", (9, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Evil Jay", (9, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Vomit Vulture", (9, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Feral Cardinal", (9, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Zombie Robin", (9, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Angry Kiwi", (9, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Seagull", (9, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Panfish", (10, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Trout", (10, 9), 8, 1, 50, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Bluegill", (10, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Catfish", (10, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Salmon", (10, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Coi", (10, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Goldfish", (10, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Carp", (10, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Peekaboo", (11, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Violet Voyeur", (11, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Scandinavian Spy", (11, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Emerald Observer", (11, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Sore Spectator", (11, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Powderpuff Peeper", (11, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("James Bond", (11, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Soulpiercer", (11, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Bumblebee", (12, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Nectar Drone", (12, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Honeybee", (12, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Plague Wasp", (12, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Mud Dawber", (12, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Murder Hornet", (12, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("YellowJacket", (12, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Killer Bee", (12, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Earth Dragon", (13, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Night Fury", (13, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Sky Wyvern", (13, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Elliot", (13, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Smaug", (13, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Madame Mim", (13, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Son of Beowulf", (13, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Snow Dragon", (13, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Apprentice", (14, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Warlock", (14, 9),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Mage", (14, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Spellcaster", (14, 11),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Sorceror", (14, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Shaman", (14, 13),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Sage", (14, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Wizard", (14, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Pirate", (15, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Captain", (15, 15),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);

			yield return new Monster("Lich", (49, 8),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Kary", (49, 10),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Kraken", (49, 12),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
			yield return new Monster("Tiamat", (49, 14),1, 50, 30, 0, 1, 1, 1, 1, 1, 1);
		}
	}
}
