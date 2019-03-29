using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public sealed class LevelLoader : MonoBehaviour
    {
        public void RestartCurrent() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}