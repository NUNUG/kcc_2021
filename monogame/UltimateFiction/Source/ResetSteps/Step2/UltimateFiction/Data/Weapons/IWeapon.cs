using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Armors;

namespace UltimateFiction.Data.Weapons
{
	public interface IWeapon
	{
		string Id { get; }
		string Name { get; }
		string Description { get; }
		WeaponType WeaponType { get; }
		int AttackRating { get; }

		IWeapon Clone();
	}
}
