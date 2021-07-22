using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using UltimateFiction.Sprites;

namespace UltimateFiction.ContentPipelineExtensions
{
	public class ImageGridManifestReader : ContentTypeReader<SpriteSheet>
	{
		protected override SpriteSheet Read(ContentReader input, SpriteSheet existingInstance)
		{
			SpriteSheet result = new SpriteSheet();
			result.Name = input.ReadString();
			result.RowCount = input.ReadInt32();
			result.ColCount = input.ReadInt32();
			result.CellWidth = input.ReadInt32();
			result.CellHeight = input.ReadInt32();

			int directoryCount = input.ReadInt32();
			for (int j = 0; j <= directoryCount - 1; j++)
			{
				var cellSet = new FrameSet()
				{
					Name = input.ReadString(),
					Row = input.ReadInt32(),
					ColStart = input.ReadInt32(),
					ColCount = input.ReadInt32()
				};

				result.FrameSets.Add(cellSet);
			}

			return result;
		}
	}
}
