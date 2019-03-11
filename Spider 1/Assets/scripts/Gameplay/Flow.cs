using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow : MonoBehaviour
{
    public float flowSpeed = 4f;
    public Vector3 flowDirection = new Vector3(1, 0, 0);
    public float stabiltyForceFactor = 1f;

    public float StabiltyForce { get => stabiltyForceFactor; set => stabiltyForceFactor = Mathf.Clamp01(value); }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Stabilize(Collider2D collision)
    {
        float stablityForce =(1 - Mathf.Abs(
            Vector3.Dot(
                collision.attachedRigidbody.velocity.normalized,
                flowDirection.normalized
            )
        )) * stabiltyForceFactor;

        collision.attachedRigidbody.AddForce(
            -collision.attachedRigidbody.velocity * stablityForce,
            ForceMode2D.Force
        );

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Stabilize(collision);
        collision.attachedRigidbody.AddForce(
            flowDirection * flowSpeed,
            ForceMode2D.Force
        );
    }
}
