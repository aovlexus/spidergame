using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Events;

public class PlayerManager : MonoBehaviour, IGameManager {
	public ManagerStatus status {get; private set;}

	public int health {get; private set;}
	public int maxHealth {get; private set;}

	private NetworkService _network;

	public void Startup(NetworkService service) {
		Debug.Log("Player manager starting...");

		_network = service;

		// any long-running startup tasks go here, and set status to 'Initializing' until those tasks are complete
		status = ManagerStatus.Started;
	}

	public void UpdateData(int health, int maxHealth) {
		this.health = health;
		this.maxHealth = maxHealth;
	}

	public void Fail() {
		Messenger.Broadcast(GameEvent.LEVEL_FAILED);
	}
}
