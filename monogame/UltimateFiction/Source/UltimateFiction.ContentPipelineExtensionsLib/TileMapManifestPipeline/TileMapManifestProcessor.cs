using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFiction.ContentPipelineExtensionsLib.TileMapManifestPipeline
{
	[ContentProcessor(DisplayName = "TileMapManifest Processor - Ultimate Fiction")]
	public class TileMapManifestProcessor : ContentProcessor<TileMapManifest, TileMapManifest>
	{
		public override TileMapManifest Process(TileMapManifest input, ContentProcessorContext context)
		{
			context.Logger.LogMessage($"Processing TileMapManifest.");
			return input;
		}
	}
}
