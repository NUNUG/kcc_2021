using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFiction.ContentPipelineExtensionsLib.ImageGridManifestPipeline
{
	[ContentProcessor(DisplayName = "ImageGridManifest Processor - Ultimate Fiction")]
	public class ImageGridManifestProcessor : ContentProcessor<ImageGridManifest, ImageGridManifest>
	{
		public override ImageGridManifest Process(ImageGridManifest input, ContentProcessorContext context)
		{
			context.Logger.LogMessage($"Processing ImageGridManifest: {input.Name}");
			return input;
		}
	}
}
