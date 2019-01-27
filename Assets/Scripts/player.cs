using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public TextMeshProUGUI WaveCount;

    private void Start()
    {
        nextReward = 5;
        Cursor.visible = false;
        TextPro.text = "Shmeckles: " + funds;
        Debug.Log((SceneManager.GetActiveScene().name));
        switch ((SceneManager.GetActiveScene().name))
        {
            case ("Level 1"): WaveCount.text = "Wave: " + 1;
                break;
            case ("Level 2"):
                WaveCount.text = "Wave: " + 2;
                break;
            case ("Level 3"):
                WaveCount.text = "Wave: " + 3;
                break;
            case ("Level 4"):
                WaveCount.text = "Wave: " + 4;
                break;
            case ("Level 5"):
                WaveCount.text = "Wave: " + 5;
                break;
        }
    }

    void Update()
    {

        if(PauseMenu.GameIsPaused)
        {
            
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
        
        
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
