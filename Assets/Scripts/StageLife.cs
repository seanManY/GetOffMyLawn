using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StageLife : MonoBehaviour
{
    public Image[] hearts;

    public int life = 3;

    void Update()
    {
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            life--;



            if (life <= 0)
            {
                Debug.Log("you are dead");
            }
        }
    }
}
