using UnityEngine;

namespace Level
{
    [RequireComponent(typeof(ParticleSystem))]
    public class FlowParticleControl : MonoBehaviour
    {
        private ParticleSystem _particleSystem;
        public float speed;
        public Vector3 direction;

        // Start is called before the first frame update
        void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            var particleSystemMain = _particleSystem.main;
            particleSystemMain.startSpeed = 0.5f * speed;
            var particleSystemShape = _particleSystem.shape;
            var angle = Mathf.Rad2Deg * Mathf.Atan2(direction.normalized.x, direction.normalized.y);
            print(angle);
            particleSystemShape.rotation =  new Vector3(-90 + angle, 90, 0);
            _particleSystem.Play();
        }
    }
}
