using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private float waveFactor;

    [SerializeField] private float maxWaveForce = 20f;
    [SerializeField] private float minWaveForce = 5f;
    [SerializeField] private float timeToLife = 4f;

    public float WaveFactor
    {
        get => waveFactor;
        set => waveFactor = Mathf.Clamp01(value);
    }

    private float lifeTime = 0f;
    private Vector3 ScaleFactor => new Vector3(WaveSpeed, WaveSpeed, WaveSpeed);

    private float TimeToLife => timeToLife * WaveFactor;
    private float WaveForceDelta => maxWaveForce - minWaveForce;
    private float WaveForce => minWaveForce + WaveForceDelta * WaveFactor;
    private float WaveSpeed => maxWaveForce / 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime <= TimeToLife)
        {
            transform.localScale = transform.localScale + ScaleFactor;
            lifeTime += Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 direction = (collision.transform.position - transform.position).normalized;
        collision.attachedRigidbody.AddForce(
            direction * WaveForce,
            ForceMode2D.Impulse
        );


    }
}
