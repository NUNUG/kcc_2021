using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Tiling
{
	public class TileMapManifest
	{
		public class TileMapManifestEntry
		{
			public string Id { get; set; }
			public string ContentName { get; set; }
			public string MapFilename { get; set; }
			public string Description { get; set; }
		}

		public List<TileMapManifestEntry> Entries { get; set; }
		public TileMapManifest()
		{
			Entries = new List<TileMapManifestEntry>();
		}
	}
}
