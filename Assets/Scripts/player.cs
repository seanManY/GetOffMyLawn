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

    public float rewardRate = 5f;
    private float nextReward;

    public TextMeshProUGUI TextPro;

    private void Start()
    {
        nextReward = 5;
        Cursor.visible = false;
        TextPro.text = "Shmeckles: " + funds;
    }

    void Update()
    {

        if (Time.time >= nextReward)
        {
            nextReward = Time.time + rewardRate;
            funds += 5;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < life)
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
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }

    public void SpendFunds(int item)
    {

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

    public void addFunds(int newFunds)
    {
        funds += newFunds;
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
