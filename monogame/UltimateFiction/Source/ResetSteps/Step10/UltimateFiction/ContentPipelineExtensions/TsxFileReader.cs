using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace UltimateFiction.ContentPipelineExtensions
{
	public class TsxFileReader : ContentTypeReader<byte[]>
	{
		protected override byte[] Read(ContentReader input, byte[] existingInstance)
		{
			int byteCount = input.ReadInt32();
			byte[] fileData = input.ReadBytes(byteCount);
			return fileData;
		}
	}
}
