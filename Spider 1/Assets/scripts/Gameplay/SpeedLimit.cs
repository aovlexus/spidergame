using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SpeedLimit : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float slowSpeed = 2f;
    public float flowFactor = 0.5f;

    private Rigidbody2D rigitbody;
    // Start is called before the first frame update
    void Start()
    {
        rigitbody = GetComponent<Rigidbody2D>();
    }

    private void Stabilize()
    {
        if (rigitbody.velocity.magnitude <= slowSpeed) {
            rigitbody.velocity *= flowFactor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rigitbody.velocity.magnitude > maxSpeed)
        {
            rigitbody.velocity = rigitbody.velocity.normalized * maxSpeed;
        }
        Stabilize();
    }
}
