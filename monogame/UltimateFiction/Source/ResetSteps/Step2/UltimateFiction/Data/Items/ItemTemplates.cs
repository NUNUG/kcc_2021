using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Data.Items
{
	public class ItemTemplates
	{
		public List<IItem> Templates { get; }

		public ItemTemplates()
		{
			Templates = new List<IItem>();
			Templates.AddRange(CreateTemplates());
		}

		public static IEnumerable<IItem> CreateTemplates()
		{
			yield return new Item("item_cure", "Cure Potion", "Restores some  health.", true,
				hero => hero.HP = Math.Min(hero.HP + 30, hero.MaxHP));
			yield return new Item("item_cure2", "Cure2 Potion", "Restores more health.", true,
				hero => hero.HP = Math.Min(hero.HP + 150, hero.MaxHP));
			yield return new Item("item_cure3", "Cure3 Potion", "Restores full health.", true,
				hero => hero.HP = hero.MaxHP);
			yield return new Item("item_tonic", "Magic Tonic", "Restores some magic.", true,
				hero => hero.MP = Math.Min(hero.MP + 10, hero.MaxMP));
			yield return new Item("item_tonic2", "Magic Tonic2", "Restores more magic", true,
				hero => hero.MP = Math.Min(hero.MP + 50, hero.MaxMP));
			yield return new Item("item_tonic3", "Magic Tonic3", "Restores full magic", true,
				hero => hero.MP = hero.MaxMP);

			yield return new Item("item_tent", "Tent", "Restores some health and magic for all heroes.", false,
				hero => {
					hero.HP = Math.Min(hero.HP + 30, hero.MaxHP);
					hero.HP = Math.Min(hero.MP + 15, hero.MaxMP);
				});

			yield return new Item("item_cabin", "Cabin", "Restores more health and magic for all heroes.", false,
				hero => {
					hero.HP = Math.Min(hero.HP + 150, hero.MaxHP);
					hero.HP = Math.Min(hero.MP + 50, hero.MaxMP);
				});

			yield return new Item("item_house", "House", "Restores all health and magic for all heroes.", false,
				hero => {
					hero.HP = hero.MaxHP;
					hero.HP = hero.MaxMP;
					hero.MP = hero.MaxMP;
				});

			yield return new Item("item_miraclepill", "Miracle pill", "Chocolate coated pill revives a mostly-dead hero.", true,
				hero => hero.HP = Math.Max(hero.HP, 1));

			yield return new Item("item_phoenixdown", "Phoenix down", "Magic feather brings a dead hero to full life.", true,
				hero => hero.HP = Math.Max(hero.HP, 1));
		}
	}
}
