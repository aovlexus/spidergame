using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerWatchCamera : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        var position = _camera.transform.position;
        var cameraProjection = new Vector3(position.x, position.y, 0);
        var dif = cameraProjection - player.transform.position;
        if (!(dif.sqrMagnitude >= maxDistance)) return;

        var newPosition = player.transform.position + Vector3.ClampMagnitude(dif, maxDistance);
        var transform1 = _camera.transform;
        transform1.position = new Vector3(newPosition.x, newPosition.y, transform1.position.z);
    }
}
