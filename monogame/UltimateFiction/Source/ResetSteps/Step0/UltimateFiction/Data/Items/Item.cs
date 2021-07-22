using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Heroes;

namespace UltimateFiction.Data.Items
{
	public class Item : IItem
	{
		public string Id { get; }
		public string Name { get; }
		public string Description { get; }
		public Action<IHero> UseAction { get; }
		public bool UseInBattle { get; }

		public void Apply(IEnumerable<IHero> heroes)
		{
			if (UseAction != null)
				foreach(IHero hero in heroes)
					UseAction(hero);
		}

		public Item(string id, string name, string description, bool useInBattle, Action<IHero> useAction)
		{
			Id = id;
			Name = name;
			Description = description;
			UseInBattle = useInBattle;
			UseAction = useAction;
		}

		public IItem Clone()
		{
			return new Item(Id, Name, Description, UseInBattle, UseAction);
		}
	}
}
