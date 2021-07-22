using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace UltimateFiction.ContentPipelineExtensions
{
	public class TmxFileReader : ContentTypeReader<TmxMap>
	{
		protected override TmxMap Read(ContentReader input, TmxMap existingInstance)
		{
			int byteCount = input.ReadInt32();
			byte[] fileData = input.ReadBytes(byteCount);
			using MemoryStream inputStream = new MemoryStream(fileData);
			inputStream.Seek(0, SeekOrigin.Begin);
			TmxMap result = new TmxMap(inputStream);
			return result;
		}
	}
}
