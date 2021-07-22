using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimateFiction.Data;
using UltimateFiction.Data.Armors;
using UltimateFiction.Data.Heroes;
using UltimateFiction.Data.Items;
using UltimateFiction.Data.Relics;
using UltimateFiction.Data.Weapons;
using static UltimateFiction.Data.WorldData;

namespace UltimateFiction.GameCode
{
	public class GameStorage
	{
		private readonly ArmorTemplates armorTemplates;
		private readonly ItemTemplates itemTemplates;
		private readonly RelicTemplates relicTemplates;
		private readonly WeaponTemplates weaponTemplates;

		public GameStorage()
		{
			this.armorTemplates = new ArmorTemplates();
			this.itemTemplates = new ItemTemplates();
			this.relicTemplates = new RelicTemplates();
			this.weaponTemplates = new WeaponTemplates();
		}

		/// <summary>Determines the directory where savegame data is stored.</summary>
		/// <returns></returns>
		protected string GameDataDirectory()
		{
			var rootDirectory = Environment.GetFolderPath(
				Environment.SpecialFolder.ApplicationData);
			if (!Directory.Exists(rootDirectory))
				throw new Exception($"Application directory ({rootDirectory}) not found.");
			var directory = Path.Combine(rootDirectory, "UltimateFiction");
			try
			{
				if (!Directory.Exists(directory))
					Directory.CreateDirectory(directory);
				return directory;
			}
			catch (Exception ex)
			{
				throw new Exception($"Unable to create application data directory ({directory}).", ex);
			}
		}

		protected string SaveGameFilename => Path.Combine(GameDataDirectory(), @"UltimateFiction.txt");

		public bool HasSaveGame()
		{
			return File.Exists(SaveGameFilename);
		}

		public GamePlayData ReadSaveGameData()
		{
			string filename = SaveGameFilename;
			var lines = File.ReadAllLines(filename);
			GamePlayData result = new GamePlayData();
			DeserializeGamePlayData(lines, result, result.ArmorTemplates, result.ItemTemplates, result.RelicTemplates, result.WeaponTemplates);

			return result;
		}

		public void WriteSaveGameData(GamePlayData gamePlayData)
		{
			var serialized = SerializeGamePlayData(gamePlayData);
			string filename = SaveGameFilename;
			File.WriteAllLines(filename, serialized);
		}

		public GamePlayData EraseAndCreateNewSaveGameData()
		{
			if (File.Exists(SaveGameFilename))
				File.Delete(SaveGameFilename);
			var newData = CreateNewSaveGameData();
			WriteSaveGameData(newData);
			return newData;
		}

		protected GamePlayData CreateNewSaveGameData()
		{
			return new GamePlayData()
			{
				Warrior = new WarriorHero().HealAll(),
				BlackBelt = new BlackBeltHero().HealAll(),
				BlackMage = new BlackMageHero().HealAll(),
				WhiteMage = new WhiteMageHero().HealAll(),
				ResumeMap = "OW",
				ResumeMapLocation = (38, 58),
				CurrentMap = "OW",
				CurrentMapLocation = (38, 58)
			};
		}

		private IEnumerable<string> SerializeHero(IHero hero)
		{
			yield return $"name={hero.Name}";
			yield return $"maxhp={hero.MaxHP}";
			yield return $"hp={hero.HP}";
			yield return $"maxhp={hero.MaxMP}";
			yield return $"mp={hero.MP}";
			yield return $"level={hero.Level}";
			yield return $"str={hero.Str}";
			yield return $"agl={hero.Agl}";
			yield return $"dex={hero.Dex}";
			yield return $"mag={hero.Mag}";
			yield return $"luck={hero.Luck}";
			yield return $"equipment_head={hero.Equipment.Head?.Id ?? string.Empty}";
			yield return $"equipment_body={hero.Equipment.Body?.Id ?? string.Empty}";
			yield return $"equipment_gloves={hero.Equipment.Gloves?.Id ?? string.Empty}";
			yield return $"equipment_shield={hero.Equipment.Shield?.Id ?? string.Empty}";
			yield return $"equipment_weapon={hero.Equipment.Weapon?.Id ?? string.Empty}";
		}

		public IEnumerable<string> SerializeGamePlayData(GamePlayData gamePlayData)
		{
			yield return "[LocationData]";
			// We save "current" location with "resume" location so that we teleport to the resume location when we reload the save game.
			//yield return $"CurrentMap={gamePlayData.CurrentMap}";
			//yield return $"CurrentMapLocation={gamePlayData.CurrentMapLocation}";
			yield return $"CurrentMap={gamePlayData.ResumeMap}";
			yield return $"CurrentMapLocation={gamePlayData.ResumeMapLocation}";
			yield return $"ResumeMap={gamePlayData.ResumeMap}";
			yield return $"ResumeMapLocation={gamePlayData.ResumeMapLocation}";

			yield return "[gold]";
			yield return gamePlayData.Gold.ToString();

			yield return "[armorinventory]";
			foreach (var armor in gamePlayData.ArmorInventory)
				yield return $"armor={armor.Id}";

			yield return "[iteminventory]";
			foreach (var item in gamePlayData.ItemInventory)
				yield return $"item={item.Id}";

			yield return "[relicinventory]";
			foreach (var relic in gamePlayData.RelicInventory)
				yield return $"relic={relic.Id}";

			yield return "[weaponinventory]";
			foreach (var weapon in gamePlayData.WeaponInventory)
				yield return $"weapon={weapon.Id}";

			yield return "[visitedtreasures]";
			foreach (var mc in gamePlayData.VisitedTreasures)
				yield return $"mapcoord={mc}";

			yield return "[warrior]";
			foreach (string s in SerializeHero(gamePlayData.Warrior))
				yield return s;

			yield return "[blackbelt]";
			foreach (string s in SerializeHero(gamePlayData.BlackBelt))
				yield return s;

			yield return "[blackmage]";
			foreach (string s in SerializeHero(gamePlayData.BlackMage))
				yield return s;

			yield return "[whitemage]";
			foreach (string s in SerializeHero(gamePlayData.WhiteMage))
				yield return s;
		}

		private IEnumerable<string> ReadSection(string sectionName, IEnumerable<string> saveGameData)
		{
			string toFind = $"[{sectionName}]";
			bool foundHeader = false;
			var enumer = saveGameData.GetEnumerator();
			foreach (string line in saveGameData.Select(s => s.Trim()))
			{
				if (!foundHeader && line.Equals(toFind))
				{
					foundHeader = true;
				}
				else if (foundHeader)
				{
					if (line.StartsWith("[") && line.EndsWith("]"))
						yield break;
					yield return line;
				}
				else
				{
					// Skip this line.
				}
			}
		}

		private string GetValue(string line)
		{
			var parts = line.Split("=");
			if (parts.Length == 2)
				return parts[1];
			else
				throw new ArgumentException($"Error parsing save game data line ({line}).");
		}

		private void DeserializeHero(IHero hero, IEnumerable<string> lines, ArmorTemplates armorTemplates, ItemTemplates itemTemplates, RelicTemplates relicTemplates, WeaponTemplates weaponTemplates)
		{
			var sublines = lines.Take(16)
				.Select(s => GetValue(s))
				.ToList();
			hero.Name = sublines[0];
			hero.MaxHP = int.Parse(sublines[1]);
			hero.HP = int.Parse(sublines[2]);
			hero.MaxMP = int.Parse(sublines[3]);
			hero.MP = int.Parse(sublines[4]);
			hero.Level = int.Parse(sublines[5]);
			hero.Str = int.Parse(sublines[6]);
			hero.Agl = int.Parse(sublines[7]);
			hero.Dex = int.Parse(sublines[8]);
			hero.Mag = int.Parse(sublines[9]);
			hero.Luck = int.Parse(sublines[10]);
			hero.Equipment.Head = armorTemplates.Templates.FirstOrDefault(a => a.Id == sublines[11])?.Clone() ?? armorTemplates.Templates.FirstOrDefault(a => a.Id == ArmorTemplates.NONE).Clone();
			hero.Equipment.Body = armorTemplates.Templates.FirstOrDefault(a => a.Id == sublines[12])?.Clone() ?? armorTemplates.Templates.FirstOrDefault(a => a.Id == ArmorTemplates.NONE).Clone();
			hero.Equipment.Gloves = armorTemplates.Templates.FirstOrDefault(a => a.Id == sublines[13])?.Clone() ?? armorTemplates.Templates.FirstOrDefault(a => a.Id == ArmorTemplates.NONE).Clone();
			hero.Equipment.Shield = armorTemplates.Templates.FirstOrDefault(a => a.Id == sublines[14])?.Clone() ?? armorTemplates.Templates.FirstOrDefault(a => a.Id == ArmorTemplates.NONE).Clone();
			hero.Equipment.Weapon = weaponTemplates.Templates.FirstOrDefault(a => a.Id == sublines[15])?.Clone() ?? weaponTemplates.Templates.FirstOrDefault(w => w.Id == WeaponTemplates.NONE).Clone();
		}

		private (int left, int right) ParseCoords(string text)
		{
			var parts = text.Replace(" ", "")
				.Replace("(", "")
				.Replace(")", "")
				.Split(",");
			return (int.Parse(parts[0]), int.Parse(parts[1]));
		}

		public void DeserializeGamePlayData(IEnumerable<string> saveGameData, GamePlayData gamePlayData, ArmorTemplates armorTemplates, ItemTemplates itemTemplates, RelicTemplates relicTemplates, WeaponTemplates weaponTemplates)
		{
			var locationData = ReadSection("LocationData", saveGameData).ToList();
			gamePlayData.CurrentMap = GetValue(locationData[0]);
			gamePlayData.CurrentPlayerLocation = ParseCoords(GetValue(locationData[1]));
			gamePlayData.ResumeMap = GetValue(locationData[2]);
			gamePlayData.ResumeMapLocation = ParseCoords(GetValue(locationData[3]));

			var goldData = ReadSection("gold", saveGameData).ToList();
			gamePlayData.Gold = int.Parse(goldData[0].Trim());

			var sectionData = ReadSection("armorinventory", saveGameData);
			var armorIds = sectionData.Select(line => GetValue(line));
			var armors = armorIds.Select(armorId => armorTemplates.Templates.Single(a => a.Id.Equals(armorId)));

			gamePlayData.ArmorInventory.AddRange(
				ReadSection("armorinventory", saveGameData)
					.Select(line => GetValue(line))
					.Select(armorid => armorTemplates.Templates.Single(a => a.Id.Equals(armorid)))
			);

			gamePlayData.ItemInventory.AddRange(
				ReadSection("iteminventory", saveGameData)
					.Select(line => GetValue(line))
					.Select(itemid => itemTemplates.Templates.Single(i => i.Id.Equals(itemid)))
			);

			gamePlayData.RelicInventory.AddRange(
				ReadSection("relicinventory", saveGameData)
					.Select(line => GetValue(line))
					.Select(relicid => relicTemplates.Templates.Single(i => i.Id.Equals(relicid)))
			);

			gamePlayData.WeaponInventory.AddRange(
				ReadSection("weaponinventory", saveGameData)
					.Select(line => GetValue(line))
					.Select(weaponid => weaponTemplates.Templates.Single(w => w.Id.Equals(weaponid)))
			);

			gamePlayData.VisitedTreasures.AddRange(
				ReadSection("visitedtreasures", saveGameData)
					.Select(line => GetValue(line))
					.Select(mapcoord => MapCoord.Parse(mapcoord))
			);

			var warriorLines = ReadSection("warrior", saveGameData).ToList();
			DeserializeHero(gamePlayData.Warrior, warriorLines, armorTemplates, itemTemplates, relicTemplates, weaponTemplates);

			var blackBeltLines= ReadSection("blackbelt", saveGameData);
			DeserializeHero(gamePlayData.BlackBelt, blackBeltLines, armorTemplates, itemTemplates, relicTemplates, weaponTemplates);

			var blackMageLines = ReadSection("blackmage", saveGameData);
			DeserializeHero(gamePlayData.BlackMage, blackMageLines, armorTemplates, itemTemplates, relicTemplates, weaponTemplates);

			var whiteMageLines = ReadSection("whitemage", saveGameData);
			DeserializeHero(gamePlayData.WhiteMage, whiteMageLines, armorTemplates, itemTemplates, relicTemplates, weaponTemplates);
		}
	}
}
