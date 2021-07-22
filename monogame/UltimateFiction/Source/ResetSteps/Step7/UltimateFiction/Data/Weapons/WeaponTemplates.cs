using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Data.Weapons
{
	public class WeaponTemplates
	{
		public List<IWeapon> Templates { get; }

		public WeaponTemplates()
		{
			Templates = new List<IWeapon>();
			Templates.AddRange(CreateTemplates());
		}

		public static string NONE = "none";



		public static IEnumerable<IWeapon> CreateTemplates()
		{
			yield return new Weapon(NONE, "", "", WeaponType.None, 0);

			yield return new Weapon("weapon_knife", "Knife", "A short, dull blade.", WeaponType.Dagger, 3);
			yield return new Weapon("weapon_dagger", "Dagger", "A double-edged knife.", WeaponType.Dagger, 7);
			yield return new Weapon("weapon_dirk", "Dirk", " A long assassin's blade.", WeaponType.Dagger, 13);
			yield return new Weapon("weapon_sting", "Sting", "It's a giant's knife, so it feels like a sword to you.", WeaponType.Dagger, 20);

			yield return new Weapon("weapon_warhammer", "Warhammer", "A big, flat stone on the end of a stick.", WeaponType.Hammer, 1);
			yield return new Weapon("weapon_dwarfhammer", "Dwarf hammer", "A properly forged iron hammer.", WeaponType.Hammer, 1);
			yield return new Weapon("weapon_thorhammer", "Thor's hammer", "You can barely lift this.", WeaponType.Hammer, 1);

			yield return new Weapon("weapon_pinewand", "Pine wand", "Covered in sap and held together with duct tape.", WeaponType.Wand, 1);
			yield return new Weapon("weapon_tacticalwand", "Tactical wand", "Made of black plastic like all things tactical.", WeaponType.Wand, 1);
			yield return new Weapon("weapon_elderwand", "Elder wand", "Forever seeks the company of its fellow Hallows.", WeaponType.Wand, 1);

			yield return new Weapon("weapon_gnarledstaff", "Gnarled staff", "An ugly thing, if I do say so myself.", WeaponType.Staff, 1);
			yield return new Weapon("weapon_havocstaff", "Havoc staff", "Once wielded by a mystical skeletal fiend.", WeaponType.Staff, 1);
			yield return new Weapon("weapon_staffofanor", "Staff of Anor", "None shall pass without its permission.", WeaponType.Staff, 1);

			yield return new Weapon("weapon_foil", "Foil", "A slender fencing sword.", WeaponType.Sword, 5);
			yield return new Weapon("weapon_rapier", "Rapier", "A firm thrusting sword.", WeaponType.Sword, 7);
			yield return new Weapon("weapon_scimitar", "Scimitar", "A curved short sword.", WeaponType.Sword, 9);
			yield return new Weapon("weapon_cutlass", "Cutlass", "A curved long sword.", WeaponType.Sword, 13);
			yield return new Weapon("weapon_saber", "Saber", "A cavalry sword.", WeaponType.Sword, 17);
			yield return new Weapon("weapon_gladius", "Gladius", "A nimble Roman sword.", WeaponType.Sword, 23);
			yield return new Weapon("weapon_greatsword", "Greatsword", "An Anglican longsword", WeaponType.Sword, 27);
			yield return new Weapon("weapon_claymore", "Claymore",  "A Scottish longsword.", WeaponType.Sword, 29);
			yield return new Weapon("weapon_katana", "Katana", "A Japanese Samurai sword.", WeaponType.Sword, 35);
			yield return new Weapon("weapon_diamond", "Diamond sword", "A marvelous shimmering sword.", WeaponType.Sword, 38);
			yield return new Weapon("weapon_hrunting", "Hrunting", "The sword which slew Grendel's mother.", WeaponType.Sword, 45);
			yield return new Weapon("weapon_excalibur", "Excalibur", "A legendary sword which obeys one master.", WeaponType.Sword, 50);
		}
	}
}
