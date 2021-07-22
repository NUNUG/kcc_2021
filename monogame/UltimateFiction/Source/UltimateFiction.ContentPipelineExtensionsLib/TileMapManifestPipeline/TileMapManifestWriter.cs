using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFiction.ContentPipelineExtensionsLib.TileMapManifestPipeline
{
	[ContentTypeWriter]
	public class TileMapManifestWriter : ContentTypeWriter<TileMapManifest>
	{
		public override string GetRuntimeType(TargetPlatform targetPlatform)
		{
			return typeof(TileMapManifestWriter).AssemblyQualifiedName;
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return @"UltimateFiction.ContentPipelineExtensions.TileMapManifestReader, UltimateFiction";
		}

		protected override void Write(ContentWriter output, TileMapManifest value)
		{
			output.Write(value.Entries.Count);
			for (int j = 0; j <= value.Entries.Count - 1; j++)
			{
				var entry = value.Entries[j];
				output.Write(entry.Id);
				output.Write(entry.ContentName);
				output.Write(entry.MapFilename);
				output.Write(entry.Description);
			};
		}
	}
}
