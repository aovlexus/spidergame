using UnityEngine;

namespace Gameplay
{
    public class WaveShooter : MonoBehaviour
    {
        [SerializeField] private GameObject wavePrefab;
        private Camera _camera;
        private GameObject _wave;

        private float _pressureTime = 0f;

        // Start is called before the first frame update
        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        // Update is called once per frame
        private void Update()
        {
            
            if (Input.GetMouseButton(0))
            {
                // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
                _pressureTime += Time.deltaTime;
            }

            if (!Input.GetMouseButtonUp(0)) return;
            _pressureTime += Time.deltaTime;
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            CreateWave(_pressureTime);
            _pressureTime = 0;
        }

        private void CreateWave(float factor)
        {
            var clickPosition = _camera.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z)
            );
            
            RaycastHit2D collision = Physics2D.Raycast(
                new Vector2(
                    clickPosition.x,
                    clickPosition.y
                ),
                Vector2.zero,
                0f
            );

            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            // ReSharper disable once Unity.PerformanceCriticalCodeNullComparison
            if (collision.collider != null && collision.collider.gameObject.GetComponent<NoTouch>() != null) return;

            _wave = Instantiate(wavePrefab);
            _wave.transform.position = new Vector3(clickPosition.x, clickPosition.y, 0);
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            _wave.GetComponent<Wave>().WaveFactor = factor;
        }
    }
}
