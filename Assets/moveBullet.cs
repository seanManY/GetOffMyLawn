using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBullet : MonoBehaviour
{
    public float speed = 1f;
    int trigger;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        trigger = 600;
        count = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        count++;
        if(count >= trigger)
        {
            Destroy(this.gameObject);
        }
    }
}
