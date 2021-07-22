using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Armors;
using UltimateFiction.Data.Weapons;

namespace UltimateFiction.Data.Heroes
{
	public class Equipment
	{
		public IArmor Head { get; set; }
		public IArmor Body { get; set; }
		public IArmor Gloves { get; set; }
		public IArmor Shield { get; set; }

		public IWeapon Weapon { get; set; }
	}
}
