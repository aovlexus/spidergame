using System.Collections;
using Events;
using UnityEngine;

namespace Controllers
{
	public class UIController : MonoBehaviour {

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
//			//levelEnding.gameObject.SetActive(true);
//			//levelEnding.text = "Level Failed";
//		
			yield return new WaitForSeconds(0);
//			Managers.Mission.RestartCurrent();
		}

		private void OnLevelComplete() {
			StartCoroutine(CompleteLevel());
		}
		private IEnumerator CompleteLevel() {
			//levelEnding.gameObject.SetActive(true);
			//levelEnding.text = "Level Complete!";

			yield return new WaitForSeconds(0);

//			Managers.Mission.GoToNext();
		}
	}
}
