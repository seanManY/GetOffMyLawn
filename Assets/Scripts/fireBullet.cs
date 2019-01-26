using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public int trigger = 10;
    public int health = 100;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = trigger/2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if(count >= trigger)
        {
            Instantiate(bullet, parent);
            count = 0;
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            health--;
        }
    }

    public int getHealth()
    {
        return health;
    }

     public void setHealth(int t)
    {
        health = t;
    }
}
