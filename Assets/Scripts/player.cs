using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{


    public Image[] hearts;

    public int life = 3;

    public int funds = 100;
    public int towerCost = 25;
    public int wallCost = 15;

    public TextMeshProUGUI TextPro;

    private void Start()
    {
        Cursor.visible = false;
        TextPro.text = "Shmeckles: " + funds;
    }

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < life)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        TextPro.text = "Shmeckles: " + funds;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            life--;

            

            if(life <= 0)
            {
                Debug.Log("you are dead");
            }
        }
    }

    public void SpendFunds(int item)
    {
        Debug.Log("IM BEING CALLED");
        switch (item)
        {
            case 0: funds -= towerCost;
                break;
            case 1: funds -= wallCost;
                break;
        }
    }

    public int getFunds()
    {
        return funds;
    }

    public int getTowerCost()
    {
        return towerCost;
    }

    public int getWallCost()
    {
        return wallCost;
    }
}
