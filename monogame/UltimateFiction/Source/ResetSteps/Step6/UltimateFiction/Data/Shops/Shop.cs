using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Data.Shops
{
	public class Shop<T>
	{
		public string Name { get; }
		public ShopType ShopType { get; set; }
		public List<(T Item, int Price)> Inventory { get; set; }
		public Shop(string shopName)
		{
			Name = shopName;
			Inventory = new();
		}
	}
}
