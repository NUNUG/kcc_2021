using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Reset
{
	class Program
	{
		static void Main(string[] args)
		{
			Program p = new Program();
			p.Execute();
		}

		public string StepsDirectory { get; set; }
		List<string> StepFiles { get; }
		public int StepCount => StepFiles.Count;

		public Program()
		{
			StepFiles = new();
		}

		protected void FindStepFiles()
		{
			StepsDirectory = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../../../../ResetSteps"));
			StepFiles.Clear();
			StepFiles.AddRange(Directory.GetDirectories(StepsDirectory));
		}

		protected void PromptForStepNumber()
		{
			if (StepCount > 0)
			{
				Console.WriteLine($"RESET!\r\nFound {StepCount} steps.  Enter the step you want to use (0 - {StepCount - 1}), then press ENTER:");
				string stepNumberText = Console.ReadLine();
				if (int.TryParse(stepNumberText, out int stepNumber))
				{
					if ((stepNumber >= 0) && (stepNumber <= StepCount - 1))
					{
						RestoreStep(stepNumber);
						Console.WriteLine("Restored step {stepNumber}.");
					}
					else
					{
						Console.WriteLine($"Step {stepNumber} not found!");
						Environment.Exit(1);
					}
				}
				else
				{
					Console.WriteLine("Invalid step number.");
					Environment.Exit(1);
				}
			}
			else
			{
				Console.WriteLine("No steps found!");
			}
		}

		protected void CopyDirectory(string source, string target)
		{
			// Get the subdirectories for the specified directory.
			DirectoryInfo dir = new DirectoryInfo(source);

			if (!dir.Exists)
			{
				throw new DirectoryNotFoundException(
					"Source directory does not exist or could not be found: "
					+ source);
			}

			DirectoryInfo[] dirs = dir.GetDirectories();

			// If the destination directory doesn't exist, create it.       
			Directory.CreateDirectory(target);

			// Get the files in the directory and copy them to the new location.
			FileInfo[] files = dir.GetFiles();
			foreach (FileInfo file in files)
			{
				string tempPath = Path.Combine(target, file.Name);
				file.CopyTo(tempPath, true);
			}

			// For subdirectories, copy them and their contents to new location.
			foreach (DirectoryInfo subdir in dirs)
			{
				string tempPath = Path.Combine(target, subdir.Name);
				CopyDirectory(subdir.FullName, tempPath);
			}
		}

		protected void RestoreStep(int stepNumber)
		{
			string source = Path.Combine(StepsDirectory, $"Step{stepNumber}/UltimateFiction");
			string target = Path.GetFullPath(Path.Combine(StepsDirectory, "..", "UltimateFiction"));

			CopyDirectory(source, target);
		}

		public void Execute()
		{
			FindStepFiles();
			PromptForStepNumber();
		}
	}
}
