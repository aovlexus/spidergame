using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class StartupController : MonoBehaviour
    {
        [SerializeField] private Text progresText;

        void Awake()
        {
//            Messenger<int, int>.AddListener(StartupEvent.MANAGERS_PROGRESS, OnManagersProgress);
//            Messenger.AddListener(StartupEvent.MANAGERS_STARTED, OnManagersStarted);
        }
        void OnDestroy()
        {
//            Messenger<int, int>.RemoveListener(StartupEvent.MANAGERS_PROGRESS, OnManagersProgress);
//            Messenger.RemoveListener(StartupEvent.MANAGERS_STARTED, OnManagersStarted);
        }

        private void OnManagersProgress(int numReady, int numModules)
        {
            float progress = (float)numReady / numModules;
            progresText.text = "Loading: " + progress.ToString(CultureInfo.InvariantCulture);
        }

        private void OnManagersStarted()
        {
//            Managers.Mission.GoToNext();
        }
    }
}
