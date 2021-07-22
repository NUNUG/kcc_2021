using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UltimateFiction.ContentPipelineExtensionsLib.TileMapManifestPipeline
{
	[ContentImporter(".txt", DefaultProcessor = "TileMapManifestProcessor", DisplayName = "TileMap Manifest Importer - Ultimate Fiction")]
	public class TileMapManifestImporter : ContentImporter<TileMapManifest>
	{
		public override TileMapManifest Import(string filename, ContentImporterContext context)
		{
			var lines = File.ReadAllLines(filename)
				.Select(line => line.Trim())
				.Where(line => !string.IsNullOrEmpty(line))
				.Where(line => !line.StartsWith("#"))
				.ToList();

			var result = new TileMapManifest();

			foreach (var line in lines)
				result.Digest(line);

			return result;
		}
	}
}
