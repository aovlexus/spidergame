using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SpeedLimit : MonoBehaviour
    {
        public float maxSpeed = 5f;
        public float slowSpeed = 2f;
        public float flowFactor = 0.5f;

        private Rigidbody2D _rigidBody;
        private Animator _animator;
        private static readonly int Speed = Animator.StringToHash("Speed");
        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_rigidBody.velocity.magnitude > maxSpeed)
            {
                _rigidBody.velocity = _rigidBody.velocity.normalized * maxSpeed;
            }
            _animator.SetFloat(Speed, Mathf.Lerp(0, maxSpeed, _rigidBody.velocity.magnitude));
            Stabilize();
        }

        private void Stabilize()
        {
            if (_rigidBody.velocity.sqrMagnitude <= slowSpeed * slowSpeed) {
                _rigidBody.velocity *= flowFactor;
            }
        }
    }
}
