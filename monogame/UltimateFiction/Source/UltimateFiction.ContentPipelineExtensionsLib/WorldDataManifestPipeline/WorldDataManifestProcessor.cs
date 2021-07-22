using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace UltimateFiction.ContentPipelineExtensionsLib.WorldDataManifestPipeline
{
	[ContentProcessor(DisplayName = "WorldDataManifest Processor - Ultimate Fiction")]
	public class WorldDataManifestProcessor : ContentProcessor<WorldDataManifest, WorldDataManifest>
	{
		public override WorldDataManifest Process(WorldDataManifest input, ContentProcessorContext context)
		{
			context.Logger.LogMessage($"Processing WorldDataManifest");
			return input;
		}
	}
}
