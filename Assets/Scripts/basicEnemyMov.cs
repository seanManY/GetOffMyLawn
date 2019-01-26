using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemyMov : MonoBehaviour
{

    public float speed = 1f;

    

    void Start()
    {
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
    }
}
