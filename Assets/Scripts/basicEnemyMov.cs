using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemyMov : MonoBehaviour
{

    public float speed = 1f;
    int health;
    

    void Start()
    {
        health = 100;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            health = health-25;
            Debug.Log(health);
        }
    }
}
