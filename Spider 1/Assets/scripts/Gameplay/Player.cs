using ManagersScripts;
using UnityEngine;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        private Vector3 _originPosition;

        // Start is called before the first frame update
        void Start()
        {
            _originPosition = transform.position;
        }

        void OnDanger()
        {
            Managers.Player.Fail();
        }

    }
}
