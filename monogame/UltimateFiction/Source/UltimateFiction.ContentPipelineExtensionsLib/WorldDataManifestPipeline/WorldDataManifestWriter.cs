using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace UltimateFiction.ContentPipelineExtensionsLib.WorldDataManifestPipeline
{
	[ContentTypeWriter]
	public class WorldDataManifestWriter : ContentTypeWriter<WorldDataManifest>
	{
		public override string GetRuntimeType(TargetPlatform targetPlatform)
		{
			return typeof(WorldDataManifest).AssemblyQualifiedName;
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return @"UltimateFiction.ContentPipelineExtensions.WorldDataManifestReader, UltimateFiction";
		}

		protected override void Write(ContentWriter output, WorldDataManifest value)
		{
			int count =
				value.Teleports.Count + 1
				+ value.NpcInteractions.Count + 1
				+ value.Ports.Count + 1
				+ value.Shops.Count + 1
				+ value.Triggers.Count + 1
				+ value.Treasures.Count + 1
				+ value.Battles.Count + 1
				+ value.ResumePoints.Count + 1;

			output.Write(count);
			output.Write("header_teleports");
			value.Teleports.ForEach(teleport => output.Write(teleport.ToString()));

			output.Write("header_npcinteractions");
			value.NpcInteractions.ForEach(npcinteraction => output.Write(npcinteraction.ToString()));

			output.Write("header_ports");
			value.Ports.ForEach(port => output.Write(port.ToString()));

			output.Write("header_shops");
			value.Shops.ForEach(shop => output.Write(shop.ToString()));

			output.Write("header_triggers");
			value.Triggers.ForEach(trigger => output.Write(trigger.ToString()));

			output.Write("header_treasures");
			value.Treasures.ForEach(treasure => output.Write(treasure.ToString()));

			output.Write("header_battles");
			value.Battles.ForEach(battle => output.Write(battle.ToString()));

			output.Write("header_resumepoints");
			value.ResumePoints.ForEach(resumePoint => output.Write(resumePoint.ToString()));
		}
	}
}
