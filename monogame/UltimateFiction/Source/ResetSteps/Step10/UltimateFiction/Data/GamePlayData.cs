using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data.Armors;
using UltimateFiction.Data.Heroes;
using UltimateFiction.Data.Items;
using UltimateFiction.Data.Relics;
using UltimateFiction.Data.Shops;
using UltimateFiction.Data.Spells;
using UltimateFiction.Data.Weapons;
using static UltimateFiction.Data.WorldData;

namespace UltimateFiction.Data
{
	public class GamePlayData
	{
		public int Gold { get; set; }
		public IHero Warrior { get; set; }
		public IHero BlackBelt { get; set; }
		public IHero BlackMage { get; set; }
		public IHero WhiteMage { get; set; }
		public List<IArmor> ArmorInventory { get; set; }
		public List<IItem> ItemInventory { get; set; }
		public List<IRelic> RelicInventory { get; set; }
		public List<IWeapon> WeaponInventory { get; set; }
		public ArmorTemplates ArmorTemplates { get; set; }
		public ItemTemplates ItemTemplates { get; set; }
		public RelicTemplates RelicTemplates { get; set; }
		public WeaponTemplates WeaponTemplates { get; set; }
		public SpellTemplates SpellTemplates { get; set; }
		public ShopTemplates ShopTemplates { get; set; }
		public List<MapCoord> VisitedTreasures { get; set; }
		public IEnumerable<IHero> Heroes
		{
			get
			{
				yield return Warrior;
				yield return BlackBelt;
				yield return BlackMage;
				yield return WhiteMage;
			}
		}


		public string CurrentMap { get; set; }
		public (int X, int Y) CurrentMapLocation { get; set; }
		public (int X, int Y) CurrentPlayerLocation
		{
			get => (CurrentMapLocation.X + 7, CurrentMapLocation.Y + 7);
			set => CurrentMapLocation = (value.X - 7, value.Y - 7);
		}

		public string ResumeMap { get; set; }
		public (int X, int Y) ResumeMapLocation { get; set; }

		// Flags
		public bool HasCanoe => RelicInventory.Any(r => r.Id == Relics.RelicTemplates.RELIC_CANOE);
		public bool HasAirship => RelicInventory.Any(r => r.Id == Relics.RelicTemplates.RELIC_AIRSHIP);
		public bool HasBoots => RelicInventory.Any(r => r.Id == Relics.RelicTemplates.RELIC_BOOTS);
		public bool HasShip => RelicInventory.Any(r => r.Id == Relics.RelicTemplates.RELIC_SHIP);
		public bool HasChocobo => RelicInventory.Any(r => r.Id == Relics.RelicTemplates.RELIC_CHOCOBO);

		public GamePlayData()
		{
			ArmorInventory = new List<IArmor>();
			ItemInventory = new List<IItem>();
			RelicInventory = new List<IRelic>();
			WeaponInventory = new List<IWeapon>();
			ArmorTemplates = new ArmorTemplates();
			ItemTemplates = new ItemTemplates();
			RelicTemplates = new RelicTemplates();
			WeaponTemplates = new WeaponTemplates();
			SpellTemplates = new SpellTemplates();
			VisitedTreasures = new List<MapCoord>();

			Warrior = new WarriorHero();
			BlackBelt = new BlackBeltHero();
			BlackMage = new BlackMageHero();
			WhiteMage = new WhiteMageHero();

			//ShopTemplates = new ShopTemplates(SpellTemplates, ItemTemplates, WeaponTemplates, ArmorTemplates);
		}
	}
}
