using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform parent;
    public int trigger = 10;
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
    }
}
