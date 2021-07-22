using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace UltimateFiction.ContentPipelineExtensionsLib.TmxFilePipeline
{
	//[ContentTypeWriter]
	//public class TmxFileWriter : ContentTypeWriter<TmxFileData>
	//{
	//	public override string GetRuntimeType(TargetPlatform targetPlatform)
	//	{
	//		return typeof(TmxFileData).AssemblyQualifiedName;
	//	}

	//	public override string GetRuntimeReader(TargetPlatform targetPlatform)
	//	{
	//		return @"UltimateFiction.ContentPipelineExtensions.TmxFileReader, UltimateFiction";
	//	}

	//	protected override void Write(ContentWriter output, TmxFileData value)
	//	{
	//		output.Write(value.Data.Length);
	//		output.Write(value.Data);
	//	}
	//}
}
