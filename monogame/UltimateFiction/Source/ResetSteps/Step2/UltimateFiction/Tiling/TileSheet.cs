using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateFiction.Tiling
{
	public class TileSheet
	{
		public string Name { get; }
		public Texture2D Texture { get; }
		public TileSheet(ContentManager contentManager, string name, Dictionary<string, Texture2D> textureTable)
		{
			if (!textureTable.ContainsKey(name))
				textureTable[name] = contentManager.Load<Texture2D>(name);

			Name = name;
			Texture = textureTable[name];
		}
	}
}
