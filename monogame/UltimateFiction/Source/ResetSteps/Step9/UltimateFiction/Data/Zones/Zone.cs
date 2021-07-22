using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Data.Zones
{
	public class Zone
	{
		public int ZoneColor { get; }
		public int Index { get; }

		public Zone(int zoneColor, int index)
		{
			this.ZoneColor = zoneColor;
			this.Index = index;
		}
	}
}
