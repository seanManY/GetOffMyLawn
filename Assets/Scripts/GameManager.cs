﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject turret;
    public GameObject wall;
    public GameObject basicEnemy;

    public GameObject laneSpawns1;
    public GameObject laneSpawns2;
    public GameObject laneSpawns3;
    public GameObject laneSpawns4;
    public GameObject laneSpawns5;
    public GameObject laneSpawns6;
    public GameObject laneSpawns7;
    public GameObject laneSpawns8;
    public GameObject laneSpawns9;

    GameObject currentSpawn;

    int laneNum;

    GameObject[,] spawnGrid;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawn = laneSpawns5;
        laneNum = 4;

        spawnGrid = new GameObject[9, 4];

        //for (int j = 0; j < 8; j++)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        spawnGrid[i, j] = (GameObject)null;
        //    }
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            currentSpawn = laneSpawns1;
            laneNum = 0;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            currentSpawn = laneSpawns2;
            laneNum = 1;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            currentSpawn = laneSpawns3;
            laneNum = 2;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            currentSpawn = laneSpawns4;
            laneNum = 3;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            currentSpawn = laneSpawns5;
            laneNum = 4;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            currentSpawn = laneSpawns6;
            laneNum = 5;
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            currentSpawn = laneSpawns7;
            laneNum = 6;
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            currentSpawn = laneSpawns8;
            laneNum = 7;
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            currentSpawn = laneSpawns9;
            laneNum = 8;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (spawnGrid[laneNum, 3] != null)
            {
                Destroy(spawnGrid[laneNum, 3]);
            }
            if (spawnGrid[laneNum, 2] != null)
            {
                spawnGrid[laneNum, 3] = Instantiate(spawnGrid[laneNum, 2], currentSpawn.transform.GetChild(3));
                Destroy(spawnGrid[laneNum, 2]);
            }
            if (spawnGrid[laneNum, 1] != null)
            {
                spawnGrid[laneNum, 2] = Instantiate(spawnGrid[laneNum, 1], currentSpawn.transform.GetChild(2));
                Destroy(spawnGrid[laneNum, 1]);
            }
            if (spawnGrid[laneNum, 0] != null)
            {
                spawnGrid[laneNum, 1] = Instantiate(spawnGrid[laneNum, 0], currentSpawn.transform.GetChild(1));
                Destroy(spawnGrid[laneNum, 0]);
            }
            spawnGrid[laneNum, 0] = Instantiate(turret, currentSpawn.transform.GetChild(0));

            //if (spawnGrid[laneNum, 3] != (GameObject)null)
            //{

            //}
            //else if (spawnGrid[laneNum, 2] != (GameObject)null)
            //{
            //    spawnGrid[laneNum, 3] = Instantiate(spawnGrid[laneNum, 2], currentSpawn.transform.GetChild(3));
            //    Destroy(spawnGrid[laneNum, 2]);
            //    spawnGrid[laneNum, 2] = Instantiate(spawnGrid[laneNum, 1], currentSpawn.transform.GetChild(2));
            //    Destroy(spawnGrid[laneNum, 1]);
            //    spawnGrid[laneNum, 1] = Instantiate(spawnGrid[laneNum, 0], currentSpawn.transform.GetChild(1));
            //    Destroy(spawnGrid[laneNum, 0]);
            //    spawnGrid[laneNum, 0] = Instantiate(turret, currentSpawn.transform.GetChild(0));
            //}
            //else if (spawnGrid[laneNum, 1] != (GameObject)null)
            //{
            //    spawnGrid[laneNum, 2] = Instantiate(spawnGrid[laneNum, 1], currentSpawn.transform.GetChild(2));
            //    Destroy(spawnGrid[laneNum, 1]);
            //    spawnGrid[laneNum, 1] = Instantiate(spawnGrid[laneNum, 0], currentSpawn.transform.GetChild(1));
            //    Destroy(spawnGrid[laneNum, 0]);
            //    spawnGrid[laneNum, 0] = Instantiate(turret, currentSpawn.transform.GetChild(0));
            //}
            //else if (spawnGrid[laneNum, 0] != (GameObject)null)
            //{
            //    spawnGrid[laneNum, 1] = Instantiate(spawnGrid[laneNum, 0], currentSpawn.transform.GetChild(1));
            //    Destroy(spawnGrid[laneNum, 0]);
            //    spawnGrid[laneNum, 0] = Instantiate(turret, currentSpawn.transform.GetChild(0));
            //}
            //else
            //{
            //    spawnGrid[laneNum, 0] = Instantiate(turret, currentSpawn.transform.GetChild(0));
            //}
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (spawnGrid[laneNum, 3] != null)
            {
                Destroy(spawnGrid[laneNum, 3]);
            }
            if (spawnGrid[laneNum, 2] != null)
            {
                spawnGrid[laneNum, 3] = Instantiate(spawnGrid[laneNum, 2], currentSpawn.transform.GetChild(3));
                Destroy(spawnGrid[laneNum, 2]);
            }
            if (spawnGrid[laneNum, 1] != null)
            {
                spawnGrid[laneNum, 2] = Instantiate(spawnGrid[laneNum, 1], currentSpawn.transform.GetChild(2));
                Destroy(spawnGrid[laneNum, 1]);
            }
            if (spawnGrid[laneNum, 0] != null)
            {
                spawnGrid[laneNum, 1] = Instantiate(spawnGrid[laneNum, 0], currentSpawn.transform.GetChild(1));
                Destroy(spawnGrid[laneNum, 0]);
            }
            spawnGrid[laneNum, 0] = Instantiate(wall, currentSpawn.transform.GetChild(0));

            //if (spawnGrid[laneNum, 3] != (GameObject)null)
            //{

            //}
            //else if (spawnGrid[laneNum, 2] != (GameObject)null)
            //{
            //    spawnGrid[laneNum, 3] = Instantiate(spawnGrid[laneNum, 2], currentSpawn.transform.GetChild(3));
            //    Destroy(spawnGrid[laneNum, 2]);
            //    spawnGrid[laneNum, 2] = Instantiate(spawnGrid[laneNum, 1], currentSpawn.transform.GetChild(2));
            //    Destroy(spawnGrid[laneNum, 1]);
            //    spawnGrid[laneNum, 1] = Instantiate(spawnGrid[laneNum, 0], currentSpawn.transform.GetChild(1));
            //    Destroy(spawnGrid[laneNum, 0]);
            //    spawnGrid[laneNum, 0] = Instantiate(wall, currentSpawn.transform.GetChild(0));
            //}
            //else if (spawnGrid[laneNum, 1] != (GameObject)null)
            //{
            //    spawnGrid[laneNum, 2] = Instantiate(spawnGrid[laneNum, 1], currentSpawn.transform.GetChild(2));
            //    Destroy(spawnGrid[laneNum, 1]);
            //    spawnGrid[laneNum, 1] = Instantiate(spawnGrid[laneNum, 0], currentSpawn.transform.GetChild(1));
            //    Destroy(spawnGrid[laneNum, 0]);
            //    spawnGrid[laneNum, 0] = Instantiate(wall, currentSpawn.transform.GetChild(0));
            //}
            //else if (spawnGrid[laneNum, 0] != (GameObject)null)
            //{
            //    spawnGrid[laneNum, 1] = Instantiate(spawnGrid[laneNum, 0], currentSpawn.transform.GetChild(1));
            //    Destroy(spawnGrid[laneNum, 0]);
            //    spawnGrid[laneNum, 0] = Instantiate(wall, currentSpawn.transform.GetChild(0));
            //}
            //else
            //{
            //    spawnGrid[laneNum, 0] = Instantiate(wall, currentSpawn.transform.GetChild(0));
            //}
        }
    }
}
