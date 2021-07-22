using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Armors;

namespace UltimateFiction.Data.Weapons
{
	public class Weapon : IWeapon
	{
		public string Id { get; set; }
		public string Name { get; }
		public string Description { get; }
		public WeaponType WeaponType { get; }
		public int AttackRating { get; }

		public Weapon(string id, string name, string description, WeaponType weaponType, int attackRating)
		{
			Id = id;
			Name = name;
			Description = description;
			WeaponType = weaponType;
			AttackRating = attackRating;
		}

		public IWeapon Clone()
		{
			return new Weapon(this.Id, this.Name, this.Description, this.WeaponType, this.AttackRating);
		}

		public override string ToString()
		{
			return $"Weapon ({Id}: {Name})";
		}
	}
}
