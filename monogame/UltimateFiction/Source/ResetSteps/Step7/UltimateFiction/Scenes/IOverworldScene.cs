using UltimateFiction.Data;

namespace UltimateFiction.Scenes
{
	public interface IOverworldScene
	{
		void TeleportToTile(string map, int x, int y);
		void SetGameData(GamePlayData gamePlayData);
	}
}
