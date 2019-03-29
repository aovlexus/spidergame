using System.Collections.Generic;
using Events;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay
{
    public class PlayerEnterTrigger : MonoBehaviour
    {
        public UnityEvent onPlayerEnter = new UnityEvent();
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                onPlayerEnter.Invoke();
        }
    }
}
