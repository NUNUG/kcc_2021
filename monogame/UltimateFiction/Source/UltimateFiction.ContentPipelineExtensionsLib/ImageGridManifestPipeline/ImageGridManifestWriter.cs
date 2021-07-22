using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFiction.ContentPipelineExtensionsLib.ImageGridManifestPipeline
{
	[ContentTypeWriter]
	public class ImageGridManifestWriter : ContentTypeWriter<ImageGridManifest>
	{
		public override string GetRuntimeType(TargetPlatform targetPlatform)
		{
			return typeof(ImageGridManifest).AssemblyQualifiedName;
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return @"UltimateFiction.ContentPipelineExtensions.ImageGridManifestReader, UltimateFiction";
		}

		protected override void Write(ContentWriter output, ImageGridManifest value)
		{
			output.Write(value.Name);
			output.Write(value.RowCount);
			output.Write(value.ColCount);
			output.Write(value.CellWidth);
			output.Write(value.CellHeight);

			output.Write(value.CellSets.Count);

			foreach (var cellSet in value.CellSets)
			{
				output.Write(cellSet.Name);
				output.Write(cellSet.Row);
				output.Write(cellSet.ColStart);
				output.Write(cellSet.ColCount);
			}
		}
	}
}
