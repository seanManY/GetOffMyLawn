using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GunScript : MonoBehaviour

    
{
    public float damage = 10;
    public float range = 100f;

    
    private int itemSel = 0;

    private GameManager GM;
    public player player;
    int playerFunds;
    int towerCost;
    int wallCost;

    public Image[] ammo;

    public Camera fpsCam;

    public Image[] icon;

    public GameObject muzzleFX;

    int bullets = 6;
    // Start is called before the first frame update
    void Start()
    {
        playerFunds = player.GetComponent<player>().getFunds();
        towerCost = player.GetComponent<player>().getTowerCost();
        wallCost = player.GetComponent<player>().getWallCost();
        icon[1].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerFunds = player.GetComponent<player>().getFunds();
        if (Input.GetButtonDown("Fire1") && bullets > 0 && !PauseMenu.GameIsPaused)
        {
            bullets--;
            Instantiate(muzzleFX, this.transform);
            FindObjectOfType<AudioManage>().Play("Revolver");
            Shoot();

        }

        if (Input.GetButtonDown("Fire2"))
        {
            
            if((itemSel == 0 && playerFunds >= towerCost) || (itemSel == 1 && playerFunds >= wallCost))
            {
                
                Build(itemSel);
            }


        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            icon[itemSel].enabled = false;
            itemSel = (itemSel +1) % 2;
            icon[itemSel].enabled = true;

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


            basicEnemyMov target = hit.transform.GetComponent<basicEnemyMov>();
            if(target != null)
            {
                
                target.TakeDamage(100);
            }


        }
    }

    void Build(int item)
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range) 
            && hit.transform.tag != "Enemy")
        {
            int num = 0;

            

            if (hit.transform.tag == "DDrop")
            {
                player.GetComponent<player>().SpendFunds(item);
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

    public void setGM(GameManager _GM)
    {
        GM = _GM;
    }
}
