using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveShooter : MonoBehaviour
{
    [SerializeField] private GameObject wavePrefab;
    private Camera _camera;
    private GameObject wave;

    private float pressureTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            pressureTime += Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(0))
        {
            pressureTime += Time.deltaTime;
            CreateWave(pressureTime);
            pressureTime = 0;
        }
    }

    private void CreateWave(float factor)
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        wave = Instantiate(wavePrefab) as GameObject;
        wave.transform.position = new Vector3(ray.origin.x, ray.origin.y, 0);
        wave.GetComponent<Wave>().WaveFactor = factor;
    }

}
