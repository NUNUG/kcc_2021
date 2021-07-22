using System;
using UltimateFiction.Data.Heroes;

namespace UltimateFiction.Data.Armors
{
	public class Armor : IArmor
	{
		public string Id { get; set; }
		public string Name { get; }
		public string Description { get; }
		public ArmorType ArmorType { get; }
		public int DefenseRating { get; }

		public Armor(string id, string name, string description, ArmorType armorType, int defenseRating)
		{
			Id = id;
			Name = name;
			Description = description;
			ArmorType = armorType;
			DefenseRating = defenseRating;
		}

		public IArmor Clone()
		{
			return new Armor(this.Id, this.Name, this.Description, this.ArmorType, this.DefenseRating);
		}
	}
}
