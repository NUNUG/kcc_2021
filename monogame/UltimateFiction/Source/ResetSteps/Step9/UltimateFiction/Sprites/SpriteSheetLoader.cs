using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using UltimateFiction.ECS;

namespace UltimateFiction.Sprites
{
	public class SpriteSheetLoader
	{
		public static SpriteSheet Load(ContentManager contentManager, string assetName)
		{
			string imageAssetName = string.Concat(assetName, "_texture");
			string manifestAssetName = string.Concat(assetName, "_manifest");

			Texture2D texture = contentManager.Load<Texture2D>(imageAssetName);
			SpriteSheet manifest = contentManager.Load<SpriteSheet>(manifestAssetName);
			manifest.Texture = texture;

			return manifest;
		}
	}
}
