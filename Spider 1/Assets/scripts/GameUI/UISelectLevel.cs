using UnityEngine;
using UnityEngine.UI;

namespace GameUI
{
    public class UISelectLevel : MonoBehaviour
    {
        [SerializeField] private GameObject levelButtonPrefab;

        // Start is called before the first frame update
//        private void Start()
//        {
//            if (!Managers.Mission) return;
//            foreach (var levelName in Managers.Mission.LevelList)
//            {
//                var levelChooseButton = Instantiate(levelButtonPrefab, gameObject.transform, true);
//                levelChooseButton.GetComponentInChildren<Text>().text = levelName;
//                levelChooseButton.GetComponentInChildren<Button>().onClick.AddListener(() => LoadLevel(levelName));
//            }
//        }
//
//        private static void LoadLevel(string levelName)
//        {
//            Managers.Mission.LoadLevel(levelName);
//        }
    }
}
