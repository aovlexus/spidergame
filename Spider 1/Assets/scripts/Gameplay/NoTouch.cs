using UnityEngine;

namespace Gameplay
{
    public class NoTouch : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D collision)
        {
            Debug.Log(collision);
            if (collision.GetComponent<Wave>() != null)
            {
                Debug.Log(collision);
                Destroy(collision.gameObject);
            }   
        }

    }
}
