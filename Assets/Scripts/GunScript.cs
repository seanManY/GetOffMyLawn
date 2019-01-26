using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GunScript : MonoBehaviour

    
{
    public float damage = 10;
    public float range = 100f;

    private int itemSel = 0;

    public GameManager GM;

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

        if (Input.GetButtonDown("Fire2"))
        {
            
            Build();

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            itemSel = (itemSel +1) % 2;

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

    void Build()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            int num = 0;

            if (hit.transform.tag == "DDrop")
            {

                if (hit.transform.parent.name == "lane1")
                {
                    num = 1;
                }
                else if (hit.transform.parent.name == "lane2")
                {
                    num = 2;
                }
                else if (hit.transform.parent.name == "lane3")
                {
                    num = 3;
                }
                else if (hit.transform.parent.name == "lane4")
                {
                    num = 4;
                }
                else if (hit.transform.parent.name == "lane5")
                {
                    num = 5;
                }
                else if (hit.transform.parent.name == "lane6")
                {
                    num = 6;
                }
                else if (hit.transform.parent.name == "lane7")
                {
                    num = 7;
                }
                else if (hit.transform.parent.name == "lane8")
                {
                    num = 8;
                }
                else if (hit.transform.parent.name == "lane9")
                {
                    num = 9;
                }

                //function
                GM.BuildDefense(num-1, itemSel);
            }

            

        }
    }
}
