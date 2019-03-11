using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 originPostion;
    // Start is called before the first frame update
    void Start()
    {
        originPostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDanger()
    {
        Managers.Player.Fail();
    }

}
