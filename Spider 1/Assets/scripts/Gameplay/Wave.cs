using UnityEngine;

namespace Gameplay
{
    public class Wave : MonoBehaviour
    {
        private float _waveFactor;

        [SerializeField] private float maxWaveForce = 20f;
        [SerializeField] private float minWaveForce = 5f;
        [SerializeField] private float timeToLife = 4f;

        public float WaveFactor
        {
            private get => _waveFactor;
            set => _waveFactor = Mathf.Clamp01(value);
        }

        private float _lifeTime = 0f;
        private static Vector3 ScaleFactor => new Vector3(WaveSpeed, WaveSpeed, WaveSpeed);

        private float TimeToLife => timeToLife * WaveFactor;
        private float WaveForceDelta => maxWaveForce - minWaveForce;
        private float WaveForce => minWaveForce + WaveForceDelta * WaveFactor;
        private static float WaveSpeed => 0.1f;

        // Start is called before the first frame update
        private void Start()
        {
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            if (_lifeTime <= TimeToLife)
            {
                var transform1 = transform;
                transform1.localScale = transform1.localScale + ScaleFactor;
                _lifeTime += Time.deltaTime;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var direction = (collision.transform.position - transform.position).normalized;
            collision.attachedRigidbody.AddForce(
                direction * WaveForce,
                ForceMode2D.Impulse
            );


        }

        public void Release()
        {
            throw new System.NotImplementedException();
        }
    }
}
