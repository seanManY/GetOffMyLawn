﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableWall : MonoBehaviour
{
    public int health = 300;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }

        Debug.Log(health);
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
