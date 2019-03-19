using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Events;

public class MissionManager : MonoBehaviour, IGameManager {
	public ManagerStatus status {get; private set;}

    public List<string> levelList;

	public int curLevel {get; private set;}
	public int maxLevel {get; private set;}
	
	private NetworkService _network;
	
	public void Startup(NetworkService service) {
		Debug.Log("Mission manager starting...");
		
		_network = service;
		
		UpdateData(-1);
		
		// any long-running startup tasks go here, and set status to 'Initializing' until those tasks are complete
		status = ManagerStatus.Started;
	}

	public void UpdateData(int curLevel) {
		this.curLevel = curLevel;
		this.maxLevel = levelList.Count;
	}

	public void ReachObjective() {
		// could have logic to handle multiple objectives
        Messenger.Broadcast(GameEvent.LEVEL_COMPLETE);
	}

	public void GoToNext() {
		if (curLevel < maxLevel) {
			curLevel++;
			string level_name = levelList[curLevel];
			Debug.Log("Loading " + level_name);
			SceneManager.LoadScene(level_name);
		} else {
			Debug.Log("Last level");
			Messenger.Broadcast(GameEvent.GAME_COMPLETE);
		}
	}

	public void RestartCurrent() {
		string level_name = levelList[curLevel];
		Debug.Log("Loading " + level_name);
		SceneManager.LoadScene(level_name);
	}
}
