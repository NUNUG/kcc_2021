using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Tiling;

namespace UltimateFiction.ContentPipelineExtensions
{
	public class TileMapManifestReader : ContentTypeReader<TileMapManifest>
	{
		protected override TileMapManifest Read(ContentReader input, TileMapManifest existingInstance)
		{
			TileMapManifest result = new TileMapManifest();

			int mapCount = input.ReadInt32();
			for (int j = 0; j <= mapCount - 1; j++)
			{
				string id = input.ReadString();
				string contentName = input.ReadString();
				string filename = input.ReadString();
				string description = input.ReadString();

				var newEntry = new TileMapManifest.TileMapManifestEntry()
				{
					Id = id,
					ContentName = contentName,
					MapFilename = filename,
					Description = description
				};
				result.Entries.Add(newEntry);
			}

			return result;
		}
	}
}
