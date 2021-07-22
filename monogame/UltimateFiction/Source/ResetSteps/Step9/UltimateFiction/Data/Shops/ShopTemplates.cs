using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Armors;
using UltimateFiction.Data.Items;
using UltimateFiction.Data.Spells;
using UltimateFiction.Data.Weapons;

namespace UltimateFiction.Data.Shops
{
	public class ShopTemplates
	{
		public Shop<ISpell> ConeriaWhiteMagicShop { get; set; }
		public Shop<ISpell> ConeriaBlackMagicShop { get; set; }
		//public Shop<Weapon> ConeriaClinic { get; set; }
		public Shop<IItem> ConeriaItemShop { get; set; }
		public Shop<IWeapon> ConeriaWeaponShop { get; set; }
		public Shop<IArmor> ConeriaArmorShop { get; set; }
		//public Shop<Weapon> ConeriaInn { get; set; }

		public Shop<ISpell> MelmondWhiteMagicShop { get; set; }
		public Shop<ISpell> MelmondBlackMagicShop { get; set; }
		//public Shop<Weapon> MelmondClinic { get; set; }
		public Shop<IItem> MelmondItemShop { get; set; }
		public Shop<IWeapon> MelmondWeaponShop { get; set; }
		public Shop<IArmor> MelmondArmorShop { get; set; }
		//public Shop<Weapon> MelmondInn { get; set; }

		public Shop<ISpell> CrescentWhiteMagicShop { get; set; }
		public Shop<ISpell> CrescentBlackMagicShop { get; set; }
		//public Shop<Weapon> CrescentClinic { get; set; }
		public Shop<IItem> CrescentItemShop { get; set; }
		public Shop<IWeapon> CrescentWeaponShop { get; set; }
		public Shop<IArmor> CrescentArmorShop { get; set; }
		//public Shop<Weapon> CrescentInn { get; set; }

		public Shop<ISpell> SouthPortWhiteMagicShop { get; set; }
		public Shop<ISpell> SouthPortBlackMagicShop { get; set; }
		//public Shop<Weapon> SouthPortClinic { get; set; }
		public Shop<IItem> SouthPortItemShop { get; set; }
		public Shop<IWeapon> SouthPortWeaponShop { get; set; }
		public Shop<IArmor> SouthPortArmorShop { get; set; }
		//public Shop<Weapon> SouthPortInn { get; set; }

		public Shop<ISpell> GaiaWhiteMagicShop { get; set; }
		public Shop<ISpell> GaiaBlackMagicShop { get; set; }
		//public Shop<Weapon> GaiaClinic { get; set; }
		public Shop<IItem> GaiaItemShop { get; set; }
		public Shop<IWeapon> GaiaWeaponShop { get; set; }
		public Shop<IArmor> GaiaArmorShop { get; set; }
		//public Shop<Weapon> GaiaInn { get; set; }


		public ShopTemplates(
			SpellTemplates spellTemplates,
			ItemTemplates itemTemplates,
			WeaponTemplates weaponTemplates,
			ArmorTemplates armorTemplates
		)
		{
			CreateAllShops(spellTemplates, itemTemplates, weaponTemplates, armorTemplates);
		}

		public void CreateAllShops(
			SpellTemplates spellTemplates,
			ItemTemplates itemTemplates,
			WeaponTemplates weaponTemplates,
			ArmorTemplates armorTemplates
		)
		{
			ConeriaWhiteMagicShop = new("shop_coneria_whitemagic");
			ConeriaWhiteMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_cure1"), 50));
			ConeriaWhiteMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_life1"), 50));
			ConeriaWhiteMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_cureall1"), 50));
			ConeriaBlackMagicShop = new("shop_coneria_blackmagic");
			ConeriaBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_fire1"), 50));
			ConeriaBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_ice1"), 50));
			ConeriaBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_lightning1"), 50));
			ConeriaItemShop = new("shop_coneria_item");
			ConeriaItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure"), 20));
			ConeriaItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure2"), 50));
			ConeriaItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure3"), 200));
			ConeriaWeaponShop = new("shop_coneria_weapon");
			ConeriaWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_knife"), 100));
			ConeriaWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_warhammer"), 100));
			ConeriaWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_pinewand"), 100));
			ConeriaWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_gnarledstaff"), 100));
			ConeriaWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_foil"), 200));
			ConeriaWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_rapier"), 1000));
			ConeriaArmorShop = new("shop_coneria_armor");
			ConeriaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_whitecloth"), 10));
			ConeriaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_blackcloth"), 10));
			ConeriaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_leather"), 10));
			ConeriaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_chainmail"), 10));
			ConeriaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "gloves_wool"), 10));
			ConeriaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "gauntlet_leather"), 10));
			ConeriaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "headband_bandana"), 10));
			ConeriaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "helmet_cap"), 10));
			ConeriaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "shield_round"), 10));
			ConeriaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "smallshield_buckler"), 10));


			MelmondWhiteMagicShop = new("shop_melmond_whitemagic");
			MelmondWhiteMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_cure2"), 50));
			MelmondWhiteMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_cureall2"), 50));
			MelmondWhiteMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_life2"), 50));
			MelmondBlackMagicShop = new("shop_melmond_blackmagic");
			MelmondBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_fire2"), 50));
			MelmondBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_ice2"), 50));
			MelmondBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_lightning2"), 50));
			MelmondItemShop = new("shop_melmond_item");
			MelmondItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure"), 20));
			MelmondItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure2"), 50));
			MelmondItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure3"), 200));
			MelmondWeaponShop = new("shop_melmond_weapon");
			MelmondWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_dagger"), 400));
			MelmondWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_dwarfhammer"), 400));
			MelmondWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_tacticalwand"), 400));
			MelmondWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_havocstaff"), 400));
			MelmondWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_scimitar"), 2000));
			MelmondWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_cutlass"), 5000));
			MelmondArmorShop = new("shop_melmond_armor");
			MelmondArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_whiterobe"), 10));
			MelmondArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_blackrobe"), 10));
			MelmondArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_plate"), 10));
			MelmondArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_steel"), 10));
			MelmondArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "gloves_cotton"), 10));
			MelmondArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "gauntlet_bronze"), 10));
			MelmondArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "headband_leather"), 10));
			MelmondArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "helmet_viking"), 10));
			MelmondArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "shield_kite"), 10));
			MelmondArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "smallshield_guard"), 10));

			CrescentWhiteMagicShop = new("shop_crescent_whitemagic");
			CrescentWhiteMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_cure3"), 50));
			CrescentWhiteMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_cureall3"), 50));
			CrescentBlackMagicShop = new("shop_crescent_blackmagic");
			CrescentBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_fire3"), 50));
			CrescentBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_ice3"), 50));
			CrescentBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_lightning3"), 50));
			CrescentItemShop = new("shop_crescent_item");
			CrescentItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure"), 20));
			CrescentItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure2"), 50));
			CrescentItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure3"), 200));
			CrescentWeaponShop = new("shop_crescent_weapon");
			CrescentWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_Dirk"), 1000));
			CrescentWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_thorhammer"), 1000));
			CrescentWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_elderwand"), 1000));
			CrescentWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_staffofanor"), 1000));
			CrescentWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_saber"), 5000));
			CrescentWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_gladius"), 8000));
			CrescentArmorShop = new("shop_crescent_armor");
			CrescentArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_whitecloak"), 10));
			CrescentArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_blackcloak"), 10));
			CrescentArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_mithril"), 10));
			CrescentArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_dragon"), 10));
			CrescentArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "gloves_leather"), 10));
			CrescentArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "gauntlet_zeus"), 10));
			CrescentArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "headband_coif"), 10));
			CrescentArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "helmet_spartan"), 10));
			CrescentArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "shield_titanium"), 10));
			CrescentArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "smallshield_ninja"), 10));

			SouthPortWhiteMagicShop = new("shop_southport_whitemagic");
			SouthPortWhiteMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_cure4"), 50));
			SouthPortBlackMagicShop = new("shop_southport_blackmagic");
			SouthPortBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_fire4"), 50));
			SouthPortBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_ice4"), 50));
			SouthPortBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_lightning4"), 50));
			SouthPortItemShop = new("shop_southport_item");
			SouthPortItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure"), 20));
			SouthPortItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure2"), 50));
			SouthPortItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure3"), 200));
			SouthPortWeaponShop = new("shop_southport_weapon");
			SouthPortWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_Dirk"), 1500));
			SouthPortWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_thorhammer"), 1500));
			SouthPortWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_elderwand"), 1500));
			SouthPortWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_staffofanor"), 1500));
			SouthPortWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_saber"), 5000));
			SouthPortWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_gladius"), 10000));
			SouthPortArmorShop = new("shop_southport_armor");
			SouthPortArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_whitecloak"), 10));
			SouthPortArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_blackcloak"), 10));
			SouthPortArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_mithril"), 10));
			SouthPortArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_dragon"), 10));
			SouthPortArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "gloves_leather"), 10));
			SouthPortArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "gauntlet_zeus"), 10));
			SouthPortArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "headband_coif"), 10));
			SouthPortArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "helmet_spartan"), 10));
			SouthPortArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "shield_titanium"), 10));
			SouthPortArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "smallshield_ninja"), 10));

			GaiaWhiteMagicShop = new("shop_gaia_whitemagic");
			GaiaWhiteMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_cureall4"), 50));
			GaiaBlackMagicShop = new("shop_gaia_blackmagic");
			GaiaBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_suckerpunch"), 50));
			GaiaBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_highkick"), 50));
			GaiaBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_bite"), 50));
			GaiaBlackMagicShop.Inventory.Add(
				(spellTemplates.Templates.First(s => s.Name == "spell_pummel"), 50));
			GaiaItemShop = new("shop_gaia_item");
			GaiaItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure"), 20));
			GaiaItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure2"), 50));
			GaiaItemShop.Inventory.Add(
				(itemTemplates.Templates.First(i => i.Name == "item_cure3"), 200));
			GaiaWeaponShop = new("shop_gaia_weapon");
			GaiaWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_Dirk"), 2000));
			GaiaWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_thorhammer"), 2000));
			GaiaWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_elderwand"), 2000));
			GaiaWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_staffofanor"), 2000));
			GaiaWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_saber"), 7000));
			GaiaWeaponShop.Inventory.Add(
				(weaponTemplates.Templates.First(w => w.Name == "weapon_gladius"), 12000));
			GaiaArmorShop = new("shop_gaia_armor");
			GaiaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_whitecloak"), 10));
			GaiaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_blackcloak"), 10));
			GaiaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_mithril"), 10));
			GaiaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "armor_dragon"), 10));
			GaiaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "gloves_leather"), 10));
			GaiaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "gauntlet_zeus"), 10));
			GaiaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "headband_coif"), 10));
			GaiaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "helmet_spartan"), 10));
			GaiaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "shield_titanium"), 10));
			GaiaArmorShop.Inventory.Add(
				(armorTemplates.Templates.First(a => a.Name == "smallshield_ninja"), 10));
		}
	}
}
