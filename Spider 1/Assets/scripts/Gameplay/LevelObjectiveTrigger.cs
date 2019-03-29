using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class LevelObjectiveTrigger : MonoBehaviour
    {
        public UnityEvent onReachObjective = new UnityEvent();
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                onReachObjective.Invoke();
        }
    }
}
