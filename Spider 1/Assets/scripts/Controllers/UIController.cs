using System.Collections;
using Events;
using ManagersScripts;
using UnityEngine;

namespace Controllers
{
	public class UIController : MonoBehaviour {
		private void Awake() {
			DontDestroyOnLoad(gameObject);
			Messenger.AddListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
			Messenger.AddListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
			Messenger.AddListener(GameEvent.GAME_COMPLETE, OnGameComplete);
		}

		private void OnDestroy() {
			Messenger.RemoveListener(GameEvent.LEVEL_FAILED, OnLevelFailed);
			Messenger.RemoveListener(GameEvent.LEVEL_COMPLETE, OnLevelComplete);
			Messenger.RemoveListener(GameEvent.GAME_COMPLETE, OnGameComplete);
		}

		void Start() {
			//levelEnding.gameObject.SetActive(false);
			//popup.gameObject.SetActive(false);
		}

		private void Update() {
			if (Input.GetKeyDown(KeyCode.M)) {
				//bool isShowing = popup.gameObject.activeSelf;
				//popup.gameObject.SetActive(!isShowing);
				//popup.Refresh();
			}
		}


		private void OnLevelFailed() {
			StartCoroutine(FailLevel());
		}
		private IEnumerator FailLevel() {
			//levelEnding.gameObject.SetActive(true);
			//levelEnding.text = "Level Failed";
		
			yield return new WaitForSeconds(0);
			Managers.Mission.RestartCurrent();
		}

		private void OnLevelComplete() {
			StartCoroutine(CompleteLevel());
		}
		private IEnumerator CompleteLevel() {
			//levelEnding.gameObject.SetActive(true);
			//levelEnding.text = "Level Complete!";

			yield return new WaitForSeconds(0);

			Managers.Mission.GoToNext();
		}

		private void OnGameComplete() {
			//levelEnding.gameObject.SetActive(true);
			//levelEnding.text = "You Finished the Game!";
		}

		public void SaveGame() {
			Managers.Data.SaveGameState();
		}

		public void LoadGame() {
			Managers.Data.LoadGameState();
		}
	}
}
