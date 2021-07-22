using System;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace UltimateFiction.ContentPipelineExtensionsLib.ImageGridManifestPipeline
{
	[ContentImporter(".txt", DefaultProcessor = "ImageGridManifestProcessor", DisplayName = "ImageGrid Manifest Importer - Ultimate Fiction")]
	public class ImageGridManifestImporter : ContentImporter<ImageGridManifest>
	{
		public override ImageGridManifest Import(string filename, ContentImporterContext context)
		{
			var lines = File.ReadAllLines(filename)
				.Select(line => line.Trim())
				.Where(line => !string.IsNullOrEmpty(line))
				.Where(line => !line.StartsWith("#"))
				.ToList();

			ImageGridManifest result = new ImageGridManifest();
			int beginHeaderIndex = lines.IndexOf("BeginHeader"); // 0
			int endHeaderIndex = lines.IndexOf("EndHeader");  // 6
			context.Logger.LogImportantMessage($"beginHeaderIndex: {beginHeaderIndex}");
			context.Logger.LogImportantMessage($"endHeaderIndex: {endHeaderIndex}");
			var header = lines
				.Skip(beginHeaderIndex + 1)
				.Take(endHeaderIndex - beginHeaderIndex - 1)
				.ToDictionary(
					line => line.Split(':').FirstOrDefault() ?? string.Empty,
					line => line.Split(':').LastOrDefault() ?? string.Empty);


			int beginDirectoryIndex = lines.IndexOf("BeginDirectory");
			int endDirectoryIndex = lines.IndexOf("EndDirectory");
			var directory = lines.Skip(beginDirectoryIndex + 1).Take(endDirectoryIndex - beginDirectoryIndex - 1)
				.ToDictionary(line => line.Split(',')[0], line => line.Split(',').ToList());

			result.Name = header["Name"];
			result.CellWidth = int.Parse(header["CellWidth"]);
			result.CellHeight = int.Parse(header["CellHeight"]);
			result.RowCount = int.Parse(header["RowCount"]);
			result.ColCount = int.Parse(header["ColCount"]);

			result.CellSets = directory.Select(
				pair => new ImageGridManifest.ImageGridCellSet()
				{
					Name = pair.Key,
					Row = int.Parse(pair.Value[1]),
					ColStart = int.Parse(pair.Value[2]),
					ColCount = int.Parse(pair.Value[3])
				})
				.ToList();

			return result;
		}
	}
}
