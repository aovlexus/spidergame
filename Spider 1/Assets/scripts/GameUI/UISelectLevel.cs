using Level;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameUI
{
    public class UISelectLevel : MonoBehaviour
    {
        [SerializeField] private GameObject levelButtonPrefab;
        [SerializeField] private LevelsList levelsList;
        [SerializeField] private LevelLoader levelLoader;

        private void Start()
        {
            foreach (var levelName in levelsList.Levels)
            {
                var levelChooseButton = Instantiate(levelButtonPrefab, gameObject.transform, true);
                levelChooseButton.GetComponentInChildren<Text>().text = levelName;
                levelChooseButton.GetComponentInChildren<Button>().onClick.AddListener(() => LoadLevel(levelName));
            }
        }

        private static void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
