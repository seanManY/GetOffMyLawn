using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GunScript : MonoBehaviour

    
{
    public float damage = 10;
    public float range = 100f;

    public Image[] ammo;

    public Camera fpsCam;

    int bullets = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && bullets > 0)
        {
            bullets--;
            Shoot();

        }

        for (int i = 0; i < ammo.Length; i++)
        {
            if (i < bullets)
            {
                ammo[i].enabled = true;
            }
            else
            {
                ammo[i].enabled = false;
            }
        }

    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            basicEnemyMov target = hit.transform.GetComponent<basicEnemyMov>();
            if(target != null)
            {
                target.TakeDamage(100);
            }

        }
    }
}
