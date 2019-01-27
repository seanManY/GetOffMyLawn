using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicEnemyMov : MonoBehaviour
{
    public float speed = 1f;
    public int health = 100;

    public player playaplay;
    public int awardPoints =10;

    float xPos;
    float yPos;
    
    void Start()
    {
        

        xPos = this.transform.localPosition.x;
        yPos = this.transform.localPosition.y;
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        transform.localPosition = new Vector3(xPos, yPos, this.transform.localPosition.z);

        if (health <= 0)
        {
            Debug.Log("here");
            playaplay.GetComponent<player>().addFunds(awardPoints);
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            health = health - 25;
        }

        if(col.gameObject.tag == "Stage")
        {
            health = 0;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public void setPlayer(player player)
    {
        playaplay = player;
    }
}
