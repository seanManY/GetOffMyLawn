﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossEnemyMov : MonoBehaviour
{
    public float speed = 1f;
    public int health = 100;

    public player playaplay;
    public int awardPoints =10;


    public GameObject hitFX;
    public GameObject explodeFX;

    private Animator anime;

    Collider collides;
    float xPos;
    float yPos;
    bool isDead;

    void Start()
    {
        anime = GetComponentInChildren<Animator>();

        xPos = this.transform.localPosition.x;
        yPos = this.transform.localPosition.y;

        collides = GetComponent<Collider>();
        isDead = false;
    }

    void FixedUpdate()
    {
        if (isDead == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.localPosition = new Vector3(xPos, yPos, this.transform.localPosition.z);
        }

        if (health <= 0 && isDead == false)
        {
            isDead = true;
            playaplay.GetComponent<player>().addFunds(awardPoints);
            FindObjectOfType<GameManager>().CountDeath();
            collides.enabled = false;
            anime.SetTrigger("Death");
            Instantiate(explodeFX, this.transform);
            FindObjectOfType<AudioManage>().Play("EnemyDeath");
            Destroy(this.gameObject, 3);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            health = health - 25;
            FindObjectOfType<AudioManage>().Play("EnemyHit");
            Instantiate(hitFX, this.transform);
        }

        if(col.gameObject.tag == "Player")
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
