using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateFiction.ContentPipelineExtensionsLib.ImageGridManifestPipeline
{
	public class ImageGridManifest
	{
		public class ImageGridCellSet
		{
			public string TextureContentName { get; set; }
			public string Name { get; set; }
			public int Row { get; set; }
			public int ColStart { get; set; }
			public int ColCount { get; set; }
			public int ColEnd => ColStart + ColCount - 1;
		}
		public List<ImageGridCellSet> CellSets { get; set; }

		public ImageGridManifest()
		{
			CellSets = new List<ImageGridCellSet>();
		}

		public string TextureContentName { get; set; }
		public string Name { get; set; }
		public int RowCount { get; set; }
		public int ColCount { get; set; }
		public int CellWidth { get; set; }
		public int CellHeight { get; set; }
	}
}
