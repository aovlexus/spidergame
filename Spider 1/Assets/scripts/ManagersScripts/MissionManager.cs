using System.Collections.Generic;
using Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ManagersScripts
{
	public class MissionManager : MonoBehaviour, IGameManager {
		public ManagerStatus status {get; private set;}

		[SerializeField] private List<string> levelList;

		public int CurLevel {get; private set;}
		public int MaxLevel {get; private set;}

		public List<string> LevelList => levelList;

		private NetworkService _network;
	
		public void Startup(NetworkService service) {
			Debug.Log("Mission manager starting...");
		
			_network = service;
		
			UpdateData(-1);
		
			// any long-running startup tasks go here, and set status to 'Initializing' until those tasks are complete
			status = ManagerStatus.Started;
		}

		public void UpdateData(int curLevel) {
			this.CurLevel = curLevel;
			this.MaxLevel = LevelList.Count;
		}

		public void ReachObjective() {
			// could have logic to handle multiple objectives
			Messenger.Broadcast(GameEvent.LEVEL_COMPLETE);
		}

		public void LoadLevel(string levelName)
		{
			CurLevel = levelList.IndexOf(levelName);
			SceneManager.LoadScene(levelName);
		}
		public void GoToNext() {
			if (CurLevel < MaxLevel) {
				CurLevel++;
				var levelName = LevelList[CurLevel];
				Debug.Log("Loading " + levelName);
				SceneManager.LoadScene(levelName);
			} else {
				Debug.Log("Last level");
				Messenger.Broadcast(GameEvent.GAME_COMPLETE);
			}
		}

		public void RestartCurrent() {
			var levelName = LevelList[CurLevel];
			Debug.Log("Loading " + levelName);
			SceneManager.LoadScene(levelName);
		}
	}
}
