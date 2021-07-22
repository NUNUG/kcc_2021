using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data;
using UltimateFiction.Data.Armors;
using UltimateFiction.Data.Items;
using UltimateFiction.Data.Relics;
using UltimateFiction.Data.Weapons;
using UltimateFiction.GameCode;

namespace UltimateFiction.Services
{
	public class DataService
	{
		public ArmorTemplates ArmorTemplates { get; set; }
		public ItemTemplates ItemTemplates { get; set; }
		public RelicTemplates RelicTemplates { get; set; }
		public WeaponTemplates WeaponTemplates { get; set; }
		public GameStorage GameStorage { get; set; }
		public GamePlayData GamePlayData { get; set; }

		public DataService()
		{
			ArmorTemplates = new ArmorTemplates();
			ItemTemplates = new ItemTemplates();
			RelicTemplates = new RelicTemplates();
			WeaponTemplates = new WeaponTemplates();
			GameStorage = new GameStorage();
		}
	}
}
