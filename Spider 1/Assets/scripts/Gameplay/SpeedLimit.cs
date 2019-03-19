using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SpeedLimit : MonoBehaviour
    {
        public float maxSpeed = 5f;
        public float slowSpeed = 2f;
        public float flowFactor = 0.5f;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private static readonly int Speed = Animator.StringToHash("Speed");
        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_rigidbody.velocity.magnitude > maxSpeed)
            {
                _rigidbody.velocity = _rigidbody.velocity.normalized * maxSpeed;
            }
            _animator.SetFloat(Speed, Mathf.Lerp(0, maxSpeed, _rigidbody.velocity.magnitude));
            Stabilize();
        }

        private void Stabilize()
        {
            if (_rigidbody.velocity.magnitude <= slowSpeed) {
                _rigidbody.velocity *= flowFactor;
            }
        }
    }
}
