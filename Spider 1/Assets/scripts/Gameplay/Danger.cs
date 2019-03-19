using UnityEngine;

namespace Gameplay
{
    public class Danger : MonoBehaviour
    {
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
//          TODO: Switch to interface usage 
            collision.SendMessage("OnDanger", SendMessageOptions.DontRequireReceiver);
        }
    }
}
