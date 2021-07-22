using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Data.Armors
{
	public class ArmorTemplates
	{
		public List<IArmor> Templates { get; }

		public ArmorTemplates()
		{
			Templates = new List<IArmor>();
			Templates.AddRange(CreateTemplates());
		}

		public static string NONE = "armor_none";

		public static IEnumerable<IArmor> CreateTemplates()
		{
			yield return new Armor(NONE, "", "", ArmorType.None, 0);

			yield return new Armor("armor_whitecloth", "White cloth", "A light cotton cloth.", ArmorType.Clothes, 3);
			yield return new Armor("armor_whiterobe", "White robe", "A light cotton cloth.", ArmorType.Clothes, 9);
			yield return new Armor("armor_whitecloak", "White cloak", "A light cotton cloth.", ArmorType.Clothes, 15);

			yield return new Armor("armor_blackcloth", "Black cloth", "A light cotton cloth.", ArmorType.Clothes, 3);
			yield return new Armor("armor_blackrobe", "Black robe", "A light cotton cloth.", ArmorType.Clothes, 9);
			yield return new Armor("armor_blackcloak", "Black cloak", "A light cotton cloth.", ArmorType.Clothes, 15);

			yield return new Armor("armor_leather", "Leather armor", "Leather armor", ArmorType.LightArmor, 3);
			yield return new Armor("armor_plate", "Plate armor", "Plate armor", ArmorType.LightArmor, 8);
			yield return new Armor("armor_mithril", "Mithril shirt", "A light but very tough armor.", ArmorType.LightArmor, 20);

			yield return new Armor("armor_chainmail", "Chainmail", "Chainmail", ArmorType.HeavyArmor, 5);
			yield return new Armor("armor_steel", "Steel armor", "Steel Armor", ArmorType.HeavyArmor, 15);
			yield return new Armor("armor_dragon", "Dragon scale", "Armor plated with dragon scales", ArmorType.HeavyArmor, 25);

			yield return new Armor("gloves_wool", "Wool gloves", "Wool gloves.", ArmorType.Gloves, 1);
			yield return new Armor("gloves_cotton", "Cotton gloves", "Cotton gloves.", ArmorType.Gloves, 2);
			yield return new Armor("gloves_leather", "Leather gloves", "Leather gloves.", ArmorType.Gloves, 3);

			yield return new Armor("gauntlet_leather", "Leather gauntlet", "Leather gauntlet", ArmorType.Gauntlets, 2);
			yield return new Armor("gauntlet_bronze", "Bronze gauntlet", "Bronze gauntlet", ArmorType.Gauntlets, 4);
			yield return new Armor("gauntlet_zeus", "Zeus gauntlet", "A gauntlet powered by lightning.", ArmorType.Gauntlets, 6);

			yield return new Armor("headband_bandana", "Bandana", "A kerchief to tie around your head.", ArmorType.Headband, 1);
			yield return new Armor("headband_leather", "Leather headband", "Leather headband.", ArmorType.Headband, 2);
			yield return new Armor("headband_coif", "Coif", "Fitted chainmail headgear.", ArmorType.Headband, 3);

			yield return new Armor("helmet_cap", "Steel cap", "A steel cap.", ArmorType.Helmet, 2);
			yield return new Armor("helmet_viking", "Viking helm", "A helmet with horns.", ArmorType.Helmet, 4);
			yield return new Armor("helmet_spartan", "Spartan helm", "A protective helmet with a large plume on top.", ArmorType.Helmet, 6);

			yield return new Armor("shield_round", "Round shield", "A simple round shield.", ArmorType.Shield, 5);
			yield return new Armor("shield_kite", "Kite shield", "A large, tough kite shield.", ArmorType.Shield, 15);
			yield return new Armor("shield_titanium", "Titanium shield", "This shield is a masterpiece of craftsmanship.", ArmorType.Shield, 25);

			yield return new Armor("smallshield_buckler", "Buckler", "A small shield strapped to your lowerarm.", ArmorType.SmallShield, 3);
			yield return new Armor("smallshield_guard", "Guard", "A long brace to cover your entire arm.", ArmorType.SmallShield, 8);
			yield return new Armor("smallshield_ninja", "Ninja brace", "A long brace with barbs.", ArmorType.SmallShield, 12);
		}
	}
}
