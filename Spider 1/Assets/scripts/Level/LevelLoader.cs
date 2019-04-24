using System.Linq;
using Saves;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Level
{
    public sealed class LevelLoader : MonoBehaviour
    {
        [SerializeField] private SavePointsList savePointsList;
        [SerializeField] private GameObject character;

        private void Start()
        {
            var lines = savePointsList.savePoints.Select(kvp => kvp.Key + ": " + kvp.Value.ToString());
            Debug.Log(
                string.Join(
                    "   /   ",
                    lines
                )
            );
            if (savePointsList.GetCurrentSavePoint() != null)
            {
                character.transform.position = savePointsList.GetCurrentSavePoint().transform.position;
                
            }
            
        }

        public void RestartCurrent()
        {
            savePointsList.ResetSavePoints();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void RestartFromSavePoint()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}