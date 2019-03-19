using ManagersScripts;
using UnityEngine;

namespace Gameplay
{
    public class LevelObjectiveTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Managers.Mission.ReachObjective();
        }
    }
}
