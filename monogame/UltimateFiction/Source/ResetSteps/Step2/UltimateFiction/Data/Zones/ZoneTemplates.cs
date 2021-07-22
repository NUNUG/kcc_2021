using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Data.Zones
{
	public class ZoneTemplates
	{
		public List<Zone> Zones { get; }
		public ZoneTemplates()
		{
			Zones = new List<Zone>();
			Zones.AddRange(CreateTemplates());
		}

		public Zone this[int zoneColor, int index] => Zones[zoneColor * 16 + index];

		// Read-only instances of all the zones.
		private IEnumerable<Zone> CreateTemplates()
		{
			yield return new Zone(ZoneColor.Black, 0);
			yield return new Zone(ZoneColor.Black, 1);
			yield return new Zone(ZoneColor.Black, 2);
			yield return new Zone(ZoneColor.Black, 3);
			yield return new Zone(ZoneColor.Black, 4);
			yield return new Zone(ZoneColor.Black, 5);
			yield return new Zone(ZoneColor.Black, 6);
			yield return new Zone(ZoneColor.Black, 7);
			yield return new Zone(ZoneColor.Black, 8);
			yield return new Zone(ZoneColor.Black, 9);
			yield return new Zone(ZoneColor.Black, 10);
			yield return new Zone(ZoneColor.Black, 11);
			yield return new Zone(ZoneColor.Black, 12);
			yield return new Zone(ZoneColor.Black, 13);
			yield return new Zone(ZoneColor.Black, 14);
			yield return new Zone(ZoneColor.Black, 15);
			yield return new Zone(ZoneColor.Navy, 0);
			yield return new Zone(ZoneColor.Navy, 1);
			yield return new Zone(ZoneColor.Navy, 2);
			yield return new Zone(ZoneColor.Navy, 3);
			yield return new Zone(ZoneColor.Navy, 4);
			yield return new Zone(ZoneColor.Navy, 5);
			yield return new Zone(ZoneColor.Navy, 6);
			yield return new Zone(ZoneColor.Navy, 7);
			yield return new Zone(ZoneColor.Navy, 8);
			yield return new Zone(ZoneColor.Navy, 9);
			yield return new Zone(ZoneColor.Navy, 10);
			yield return new Zone(ZoneColor.Navy, 11);
			yield return new Zone(ZoneColor.Navy, 12);
			yield return new Zone(ZoneColor.Navy, 13);
			yield return new Zone(ZoneColor.Navy, 14);
			yield return new Zone(ZoneColor.Navy, 15);
			yield return new Zone(ZoneColor.Plum, 0);
			yield return new Zone(ZoneColor.Plum, 1);
			yield return new Zone(ZoneColor.Plum, 2);
			yield return new Zone(ZoneColor.Plum, 3);
			yield return new Zone(ZoneColor.Plum, 4);
			yield return new Zone(ZoneColor.Plum, 5);
			yield return new Zone(ZoneColor.Plum, 6);
			yield return new Zone(ZoneColor.Plum, 7);
			yield return new Zone(ZoneColor.Plum, 8);
			yield return new Zone(ZoneColor.Plum, 9);
			yield return new Zone(ZoneColor.Plum, 10);
			yield return new Zone(ZoneColor.Plum, 11);
			yield return new Zone(ZoneColor.Plum, 12);
			yield return new Zone(ZoneColor.Plum, 13);
			yield return new Zone(ZoneColor.Plum, 14);
			yield return new Zone(ZoneColor.Plum, 15);
			yield return new Zone(ZoneColor.DarkGreen, 0);
			yield return new Zone(ZoneColor.DarkGreen, 1);
			yield return new Zone(ZoneColor.DarkGreen, 2);
			yield return new Zone(ZoneColor.DarkGreen, 3);
			yield return new Zone(ZoneColor.DarkGreen, 4);
			yield return new Zone(ZoneColor.DarkGreen, 5);
			yield return new Zone(ZoneColor.DarkGreen, 6);
			yield return new Zone(ZoneColor.DarkGreen, 7);
			yield return new Zone(ZoneColor.DarkGreen, 8);
			yield return new Zone(ZoneColor.DarkGreen, 9);
			yield return new Zone(ZoneColor.DarkGreen, 10);
			yield return new Zone(ZoneColor.DarkGreen, 11);
			yield return new Zone(ZoneColor.DarkGreen, 12);
			yield return new Zone(ZoneColor.DarkGreen, 13);
			yield return new Zone(ZoneColor.DarkGreen, 14);
			yield return new Zone(ZoneColor.DarkGreen, 15);
			yield return new Zone(ZoneColor.Brown, 0);
			yield return new Zone(ZoneColor.Brown, 1);
			yield return new Zone(ZoneColor.Brown, 2);
			yield return new Zone(ZoneColor.Brown, 3);
			yield return new Zone(ZoneColor.Brown, 4);
			yield return new Zone(ZoneColor.Brown, 5);
			yield return new Zone(ZoneColor.Brown, 6);
			yield return new Zone(ZoneColor.Brown, 7);
			yield return new Zone(ZoneColor.Brown, 8);
			yield return new Zone(ZoneColor.Brown, 9);
			yield return new Zone(ZoneColor.Brown, 10);
			yield return new Zone(ZoneColor.Brown, 11);
			yield return new Zone(ZoneColor.Brown, 12);
			yield return new Zone(ZoneColor.Brown, 13);
			yield return new Zone(ZoneColor.Brown, 14);
			yield return new Zone(ZoneColor.Brown, 15);
			yield return new Zone(ZoneColor.Charcoal, 0);
			yield return new Zone(ZoneColor.Charcoal, 1);
			yield return new Zone(ZoneColor.Charcoal, 2);
			yield return new Zone(ZoneColor.Charcoal, 3);
			yield return new Zone(ZoneColor.Charcoal, 4);
			yield return new Zone(ZoneColor.Charcoal, 5);
			yield return new Zone(ZoneColor.Charcoal, 6);
			yield return new Zone(ZoneColor.Charcoal, 7);
			yield return new Zone(ZoneColor.Charcoal, 8);
			yield return new Zone(ZoneColor.Charcoal, 9);
			yield return new Zone(ZoneColor.Charcoal, 10);
			yield return new Zone(ZoneColor.Charcoal, 11);
			yield return new Zone(ZoneColor.Charcoal, 12);
			yield return new Zone(ZoneColor.Charcoal, 13);
			yield return new Zone(ZoneColor.Charcoal, 14);
			yield return new Zone(ZoneColor.Charcoal, 15);
			yield return new Zone(ZoneColor.Gray, 0);
			yield return new Zone(ZoneColor.Gray, 1);
			yield return new Zone(ZoneColor.Gray, 2);
			yield return new Zone(ZoneColor.Gray, 3);
			yield return new Zone(ZoneColor.Gray, 4);
			yield return new Zone(ZoneColor.Gray, 5);
			yield return new Zone(ZoneColor.Gray, 6);
			yield return new Zone(ZoneColor.Gray, 7);
			yield return new Zone(ZoneColor.Gray, 8);
			yield return new Zone(ZoneColor.Gray, 9);
			yield return new Zone(ZoneColor.Gray, 10);
			yield return new Zone(ZoneColor.Gray, 11);
			yield return new Zone(ZoneColor.Gray, 12);
			yield return new Zone(ZoneColor.Gray, 13);
			yield return new Zone(ZoneColor.Gray, 14);
			yield return new Zone(ZoneColor.Gray, 15);
			yield return new Zone(ZoneColor.Cream, 0);
			yield return new Zone(ZoneColor.Cream, 1);
			yield return new Zone(ZoneColor.Cream, 2);
			yield return new Zone(ZoneColor.Cream, 3);
			yield return new Zone(ZoneColor.Cream, 4);
			yield return new Zone(ZoneColor.Cream, 5);
			yield return new Zone(ZoneColor.Cream, 6);
			yield return new Zone(ZoneColor.Cream, 7);
			yield return new Zone(ZoneColor.Cream, 8);
			yield return new Zone(ZoneColor.Cream, 9);
			yield return new Zone(ZoneColor.Cream, 10);
			yield return new Zone(ZoneColor.Cream, 11);
			yield return new Zone(ZoneColor.Cream, 12);
			yield return new Zone(ZoneColor.Cream, 13);
			yield return new Zone(ZoneColor.Cream, 14);
			yield return new Zone(ZoneColor.Cream, 15);
			yield return new Zone(ZoneColor.Red, 0);
			yield return new Zone(ZoneColor.Red, 1);
			yield return new Zone(ZoneColor.Red, 2);
			yield return new Zone(ZoneColor.Red, 3);
			yield return new Zone(ZoneColor.Red, 4);
			yield return new Zone(ZoneColor.Red, 5);
			yield return new Zone(ZoneColor.Red, 6);
			yield return new Zone(ZoneColor.Red, 7);
			yield return new Zone(ZoneColor.Red, 8);
			yield return new Zone(ZoneColor.Red, 9);
			yield return new Zone(ZoneColor.Red, 10);
			yield return new Zone(ZoneColor.Red, 11);
			yield return new Zone(ZoneColor.Red, 12);
			yield return new Zone(ZoneColor.Red, 13);
			yield return new Zone(ZoneColor.Red, 14);
			yield return new Zone(ZoneColor.Red, 15);
			yield return new Zone(ZoneColor.Orange, 0);
			yield return new Zone(ZoneColor.Orange, 1);
			yield return new Zone(ZoneColor.Orange, 2);
			yield return new Zone(ZoneColor.Orange, 3);
			yield return new Zone(ZoneColor.Orange, 4);
			yield return new Zone(ZoneColor.Orange, 5);
			yield return new Zone(ZoneColor.Orange, 6);
			yield return new Zone(ZoneColor.Orange, 7);
			yield return new Zone(ZoneColor.Orange, 8);
			yield return new Zone(ZoneColor.Orange, 9);
			yield return new Zone(ZoneColor.Orange, 10);
			yield return new Zone(ZoneColor.Orange, 11);
			yield return new Zone(ZoneColor.Orange, 12);
			yield return new Zone(ZoneColor.Orange, 13);
			yield return new Zone(ZoneColor.Orange, 14);
			yield return new Zone(ZoneColor.Orange, 15);
			yield return new Zone(ZoneColor.Yellow, 0);
			yield return new Zone(ZoneColor.Yellow, 1);
			yield return new Zone(ZoneColor.Yellow, 2);
			yield return new Zone(ZoneColor.Yellow, 3);
			yield return new Zone(ZoneColor.Yellow, 4);
			yield return new Zone(ZoneColor.Yellow, 5);
			yield return new Zone(ZoneColor.Yellow, 6);
			yield return new Zone(ZoneColor.Yellow, 7);
			yield return new Zone(ZoneColor.Yellow, 8);
			yield return new Zone(ZoneColor.Yellow, 9);
			yield return new Zone(ZoneColor.Yellow, 10);
			yield return new Zone(ZoneColor.Yellow, 11);
			yield return new Zone(ZoneColor.Yellow, 12);
			yield return new Zone(ZoneColor.Yellow, 13);
			yield return new Zone(ZoneColor.Yellow, 14);
			yield return new Zone(ZoneColor.Yellow, 15);
			yield return new Zone(ZoneColor.LightGreen, 0);
			yield return new Zone(ZoneColor.LightGreen, 1);
			yield return new Zone(ZoneColor.LightGreen, 2);
			yield return new Zone(ZoneColor.LightGreen, 3);
			yield return new Zone(ZoneColor.LightGreen, 4);
			yield return new Zone(ZoneColor.LightGreen, 5);
			yield return new Zone(ZoneColor.LightGreen, 6);
			yield return new Zone(ZoneColor.LightGreen, 7);
			yield return new Zone(ZoneColor.LightGreen, 8);
			yield return new Zone(ZoneColor.LightGreen, 9);
			yield return new Zone(ZoneColor.LightGreen, 10);
			yield return new Zone(ZoneColor.LightGreen, 11);
			yield return new Zone(ZoneColor.LightGreen, 12);
			yield return new Zone(ZoneColor.LightGreen, 13);
			yield return new Zone(ZoneColor.LightGreen, 14);
			yield return new Zone(ZoneColor.LightGreen, 15);
			yield return new Zone(ZoneColor.SkyBlue, 0);
			yield return new Zone(ZoneColor.SkyBlue, 1);
			yield return new Zone(ZoneColor.SkyBlue, 2);
			yield return new Zone(ZoneColor.SkyBlue, 3);
			yield return new Zone(ZoneColor.SkyBlue, 4);
			yield return new Zone(ZoneColor.SkyBlue, 5);
			yield return new Zone(ZoneColor.SkyBlue, 6);
			yield return new Zone(ZoneColor.SkyBlue, 7);
			yield return new Zone(ZoneColor.SkyBlue, 8);
			yield return new Zone(ZoneColor.SkyBlue, 9);
			yield return new Zone(ZoneColor.SkyBlue, 10);
			yield return new Zone(ZoneColor.SkyBlue, 11);
			yield return new Zone(ZoneColor.SkyBlue, 12);
			yield return new Zone(ZoneColor.SkyBlue, 13);
			yield return new Zone(ZoneColor.SkyBlue, 14);
			yield return new Zone(ZoneColor.SkyBlue, 15);
			yield return new Zone(ZoneColor.Mauve, 0);
			yield return new Zone(ZoneColor.Mauve, 1);
			yield return new Zone(ZoneColor.Mauve, 2);
			yield return new Zone(ZoneColor.Mauve, 3);
			yield return new Zone(ZoneColor.Mauve, 4);
			yield return new Zone(ZoneColor.Mauve, 5);
			yield return new Zone(ZoneColor.Mauve, 6);
			yield return new Zone(ZoneColor.Mauve, 7);
			yield return new Zone(ZoneColor.Mauve, 8);
			yield return new Zone(ZoneColor.Mauve, 9);
			yield return new Zone(ZoneColor.Mauve, 10);
			yield return new Zone(ZoneColor.Mauve, 11);
			yield return new Zone(ZoneColor.Mauve, 12);
			yield return new Zone(ZoneColor.Mauve, 13);
			yield return new Zone(ZoneColor.Mauve, 14);
			yield return new Zone(ZoneColor.Mauve, 15);
			yield return new Zone(ZoneColor.Pink, 0);
			yield return new Zone(ZoneColor.Pink, 1);
			yield return new Zone(ZoneColor.Pink, 2);
			yield return new Zone(ZoneColor.Pink, 3);
			yield return new Zone(ZoneColor.Pink, 4);
			yield return new Zone(ZoneColor.Pink, 5);
			yield return new Zone(ZoneColor.Pink, 6);
			yield return new Zone(ZoneColor.Pink, 7);
			yield return new Zone(ZoneColor.Pink, 8);
			yield return new Zone(ZoneColor.Pink, 9);
			yield return new Zone(ZoneColor.Pink, 10);
			yield return new Zone(ZoneColor.Pink, 11);
			yield return new Zone(ZoneColor.Pink, 12);
			yield return new Zone(ZoneColor.Pink, 13);
			yield return new Zone(ZoneColor.Pink, 14);
			yield return new Zone(ZoneColor.Pink, 15);
			yield return new Zone(ZoneColor.Peach, 0);
			yield return new Zone(ZoneColor.Peach, 1);
			yield return new Zone(ZoneColor.Peach, 2);
			yield return new Zone(ZoneColor.Peach, 3);
			yield return new Zone(ZoneColor.Peach, 4);
			yield return new Zone(ZoneColor.Peach, 5);
			yield return new Zone(ZoneColor.Peach, 6);
			yield return new Zone(ZoneColor.Peach, 7);
			yield return new Zone(ZoneColor.Peach, 8);
			yield return new Zone(ZoneColor.Peach, 9);
			yield return new Zone(ZoneColor.Peach, 10);
			yield return new Zone(ZoneColor.Peach, 11);
			yield return new Zone(ZoneColor.Peach, 12);
			yield return new Zone(ZoneColor.Peach, 13);
			yield return new Zone(ZoneColor.Peach, 14);
			yield return new Zone(ZoneColor.Peach, 15);
		}
	}
}