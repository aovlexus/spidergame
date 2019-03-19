using UnityEngine;

namespace Gameplay
{
    public class NoTouch : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.GetComponent<Wave>() == null) return;
            Debug.Log(collision);
            Destroy(collision.gameObject);
        }

    }
}
