using System;
using System.Reflection;

namespace UltimateFiction
{
	public static class Program
	{
		[STAThread]
		static void Main()
		{
			var x = typeof(ContentPipelineExtensions.ImageGridManifestReader).AssemblyQualifiedName ?? "Unknown";
			Console.WriteLine(x);
			using (var game = new Game1())
				game.Run();
		}
	}
}
