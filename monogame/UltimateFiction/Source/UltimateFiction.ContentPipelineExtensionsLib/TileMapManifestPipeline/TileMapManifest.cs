using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFiction.ContentPipelineExtensionsLib.TileMapManifestPipeline
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

		public TileMapManifestEntry Digest(string manifestLine)
		{
			var parts = manifestLine.Split(',');
			if (parts.Length != 4)
				throw new Exception($"Unable to parse TileMapManifest line ({manifestLine}).");

			var entry = new TileMapManifestEntry()
			{
				Id = parts[0],
				ContentName = parts[1],
				MapFilename = parts[2],
				Description = parts[3]
			};

			Entries.Add(entry);
			return entry;
		}
	}
}
