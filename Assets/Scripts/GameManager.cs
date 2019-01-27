using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject turret;
    public GameObject wall;
    public GameObject fastEnemy;
    public GameObject normEnemy;
    public GameObject slowEnemy;

    public GameObject level;
    //public GameObject laneSpawns1;
    //public GameObject laneSpawns2;
    //public GameObject laneSpawns3;
    //public GameObject laneSpawns4;
    //public GameObject laneSpawns5;
    //public GameObject laneSpawns6;
    //public GameObject laneSpawns7;
    //public GameObject laneSpawns8;
    //public GameObject laneSpawns9;

    public player player;
    private player play;

    public int fastEnemyCount = 0;
    public int normEnemyCount = 0;
    public int slowEnemyCount = 0;
    public int spawnRate = 0;

    GameObject[] enemyList;

    int spawnCount;
    int spawnNum;

    Transform currentSpawn;
    GameObject[,] spawnGrid;

    //int laneNum;

    // Start is called before the first frame update
    void Start()
    {
        spawnCount = 0;
        spawnNum = 0;

        play = Instantiate(player);
        play.GetComponentInChildren<GunScript>().setGM(this);

        currentSpawn = level.transform.GetChild(4);
        //laneNum = 4;

        spawnGrid = new GameObject[9, 4];
        
        enemyList = new GameObject[fastEnemyCount + normEnemyCount + slowEnemyCount];
        for (int i = 0; i < fastEnemyCount; i++)
        {
            enemyList[i] = fastEnemy;
        }
        for (int i = fastEnemyCount; i < fastEnemyCount + normEnemyCount; i++)
        {
            enemyList[i] = normEnemy;
        }
        for (int i = fastEnemyCount + normEnemyCount; i < fastEnemyCount + normEnemyCount + slowEnemyCount; i++)
        {
            enemyList[i] = slowEnemy;
        }

        for (int i = 0; i < enemyList.Length; i++)
        {
            int rand = Random.Range(0, enemyList.Length);
            GameObject temp = enemyList[rand];
            enemyList[rand] = enemyList[i];
            enemyList[i] = temp;
        }
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
        spawnCount++;
        if (spawnCount >= spawnRate*10 && spawnNum < enemyList.Length)
        {
            GameObject enemy = Instantiate(enemyList[spawnNum], level.transform.GetChild(Random.Range(0,8)).GetChild(4));
            enemy.GetComponent<basicEnemyMov>().setPlayer(play);
            spawnNum++;
            spawnCount = 0;
        }
    }

    public void BuildDefense(int padNum, int buildType)
    {
        currentSpawn = level.transform.GetChild(padNum);

        //switch(padNum)
        //{
        //    case 0: currentSpawn = laneSpawns1;
        //        break;
        //    case 1:
        //        currentSpawn = laneSpawns2;
        //        break;
        //    case 2:
        //        currentSpawn = laneSpawns3;
        //        break;
        //    case 3:
        //        currentSpawn = laneSpawns4;
        //        break;
        //    case 4:
        //        currentSpawn = laneSpawns5;
        //        break;
        //    case 5:
        //        currentSpawn = laneSpawns6;
        //        break;
        //    case 6:
        //        currentSpawn = laneSpawns7;
        //        break;
        //    case 7:
        //        currentSpawn = laneSpawns8;
        //        break;
        //    case 8:
        //        currentSpawn = laneSpawns9;
        //        break;
        //}

        if (spawnGrid[padNum, 3] != null)
        {
            Destroy(spawnGrid[padNum, 3]);
        }
        if (spawnGrid[padNum, 2] != null)
        {
            if (spawnGrid[padNum, 2].tag == "Turret")
            {
                spawnGrid[padNum, 3] = Instantiate(spawnGrid[padNum, 2], currentSpawn.GetChild(3));
                spawnGrid[padNum, 3].GetComponent<fireBullet>().SetHealth(spawnGrid[padNum, 2].GetComponent<fireBullet>().GetHealth());
                Destroy(spawnGrid[padNum, 2]);
            }
            if (spawnGrid[padNum, 2].tag == "Wall")
            {
                spawnGrid[padNum, 3] = Instantiate(spawnGrid[padNum, 2], currentSpawn.GetChild(3));
                spawnGrid[padNum, 3].GetComponent<breakableWall>().SetHealth(spawnGrid[padNum, 2].GetComponent<breakableWall>().GetHealth());
                Destroy(spawnGrid[padNum, 2]);
            }
        }
        if (spawnGrid[padNum, 1] != null)
        {
            if (spawnGrid[padNum, 1].tag == "Turret")
            {
                spawnGrid[padNum, 2] = Instantiate(spawnGrid[padNum, 1], currentSpawn.GetChild(2));
                spawnGrid[padNum, 2].GetComponent<fireBullet>().SetHealth(spawnGrid[padNum, 1].GetComponent<fireBullet>().GetHealth());
                Destroy(spawnGrid[padNum, 1]);
            }
            if (spawnGrid[padNum, 1].tag == "Wall")
            {
                spawnGrid[padNum, 2] = Instantiate(spawnGrid[padNum, 1], currentSpawn.GetChild(2));
                spawnGrid[padNum, 2].GetComponent<breakableWall>().SetHealth(spawnGrid[padNum, 1].GetComponent<breakableWall>().GetHealth());
                Destroy(spawnGrid[padNum, 1]);
            }
        }
        if (spawnGrid[padNum, 0] != null)
        {
            if (spawnGrid[padNum, 0].tag == "Turret")
            {
                spawnGrid[padNum, 1] = Instantiate(spawnGrid[padNum, 0], currentSpawn.GetChild(1));
                spawnGrid[padNum, 1].GetComponent<fireBullet>().SetHealth(spawnGrid[padNum, 0].GetComponent<fireBullet>().GetHealth());
                Destroy(spawnGrid[padNum, 0]);
            }
            if (spawnGrid[padNum, 0].tag == "Wall")
            {
                spawnGrid[padNum, 1] = Instantiate(spawnGrid[padNum, 0], currentSpawn.GetChild(1));
                spawnGrid[padNum, 1].GetComponent<breakableWall>().SetHealth(spawnGrid[padNum, 0].GetComponent<breakableWall>().GetHealth());
                Destroy(spawnGrid[padNum, 0]);
            }
        }

        switch (buildType)
        {
            case 0:
                spawnGrid[padNum, 0] = Instantiate(turret, currentSpawn.GetChild(0));
                break;
            case 1:
                spawnGrid[padNum, 0] = Instantiate(wall, currentSpawn.GetChild(0));
                break;
        }
    }



    //if (Input.GetKeyDown(KeyCode.Keypad1))
    //{
    //    currentSpawn = laneSpawns1;
    //    laneNum = 0;
    //}
    //if (Input.GetKeyDown(KeyCode.Keypad2))
    //{
    //    currentSpawn = laneSpawns2;
    //    laneNum = 1;
    //}
    //if (Input.GetKeyDown(KeyCode.Keypad3))
    //{
    //    currentSpawn = laneSpawns3;
    //    laneNum = 2;
    //}
    //if (Input.GetKeyDown(KeyCode.Keypad4))
    //{
    //    currentSpawn = laneSpawns4;
    //    laneNum = 3;
    //}
    //if (Input.GetKeyDown(KeyCode.Keypad5))
    //{
    //    currentSpawn = laneSpawns5;
    //    laneNum = 4;
    //}
    //if (Input.GetKeyDown(KeyCode.Keypad6))
    //{
    //    currentSpawn = laneSpawns6;
    //    laneNum = 5;
    //}
    //if (Input.GetKeyDown(KeyCode.Keypad7))
    //{
    //    currentSpawn = laneSpawns7;
    //    laneNum = 6;
    //}
    //if (Input.GetKeyDown(KeyCode.Keypad8))
    //{
    //    currentSpawn = laneSpawns8;
    //    laneNum = 7;
    //}
    //if (Input.GetKeyDown(KeyCode.Keypad9))
    //{
    //    currentSpawn = laneSpawns9;
    //    laneNum = 8;
    //}

    //if (Input.GetKeyDown(KeyCode.LeftShift))
    //{
    //    if (spawnGrid[laneNum, 3] != null)
    //    {
    //        Destroy(spawnGrid[laneNum, 3]);
    //    }
    //    if (spawnGrid[laneNum, 2] != null)
    //    {
    //        if (spawnGrid[laneNum, 2].tag == "Turret")
    //        {
    //            spawnGrid[laneNum, 3] = Instantiate(spawnGrid[laneNum, 2], currentSpawn.transform.GetChild(3));
    //            spawnGrid[laneNum, 3].GetComponent<fireBullet>().SetHealth(spawnGrid[laneNum, 2].GetComponent<fireBullet>().GetHealth());
    //            Destroy(spawnGrid[laneNum, 2]);
    //        }
    //        if (spawnGrid[laneNum, 2].tag == "Wall")
    //        {
    //            spawnGrid[laneNum, 3] = Instantiate(spawnGrid[laneNum, 2], currentSpawn.transform.GetChild(3));
    //            spawnGrid[laneNum, 3].GetComponent<breakableWall>().SetHealth(spawnGrid[laneNum, 2].GetComponent<breakableWall>().GetHealth());
    //            Destroy(spawnGrid[laneNum, 2]);
    //        }
    //    }
    //    if (spawnGrid[laneNum, 1] != null)
    //    {
    //        if (spawnGrid[laneNum, 1].tag == "Turret")
    //        {
    //            spawnGrid[laneNum, 2] = Instantiate(spawnGrid[laneNum, 1], currentSpawn.transform.GetChild(2));
    //            spawnGrid[laneNum, 2].GetComponent<fireBullet>().SetHealth(spawnGrid[laneNum, 1].GetComponent<fireBullet>().GetHealth());
    //            Destroy(spawnGrid[laneNum, 1]);
    //        }
    //        if (spawnGrid[laneNum, 1].tag == "Wall")
    //        {
    //            spawnGrid[laneNum, 2] = Instantiate(spawnGrid[laneNum, 1], currentSpawn.transform.GetChild(2));
    //            spawnGrid[laneNum, 2].GetComponent<breakableWall>().SetHealth(spawnGrid[laneNum, 1].GetComponent<breakableWall>().GetHealth());
    //            Destroy(spawnGrid[laneNum, 1]);
    //        }
    //    }
    //    if (spawnGrid[laneNum, 0] != null)
    //    {
    //        if (spawnGrid[laneNum, 0].tag == "Turret")
    //        {
    //            spawnGrid[laneNum, 1] = Instantiate(spawnGrid[laneNum, 0], currentSpawn.transform.GetChild(1));
    //            spawnGrid[laneNum, 1].GetComponent<fireBullet>().SetHealth(spawnGrid[laneNum, 0].GetComponent<fireBullet>().GetHealth());
    //            Destroy(spawnGrid[laneNum, 0]);
    //        }
    //        if (spawnGrid[laneNum, 0].tag == "Wall")
    //        {
    //            spawnGrid[laneNum, 1] = Instantiate(spawnGrid[laneNum, 0], currentSpawn.transform.GetChild(1));
    //            spawnGrid[laneNum, 1].GetComponent<breakableWall>().SetHealth(spawnGrid[laneNum, 0].GetComponent<breakableWall>().GetHealth());
    //            Destroy(spawnGrid[laneNum, 0]);
    //        }
    //    }
    //    spawnGrid[laneNum, 0] = Instantiate(turret, currentSpawn.transform.GetChild(0));

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
    //}
    //if (Input.GetKeyDown(KeyCode.LeftControl))
    //{
    //    if (spawnGrid[laneNum, 3] != null)
    //    {
    //        Destroy(spawnGrid[laneNum, 3]);
    //    }
    //    if (spawnGrid[laneNum, 2] != null)
    //    {
    //        if (spawnGrid[laneNum, 2].tag == "Turret")
    //        {
    //            spawnGrid[laneNum, 3] = Instantiate(spawnGrid[laneNum, 2], currentSpawn.transform.GetChild(3));
    //            spawnGrid[laneNum, 3].GetComponent<fireBullet>().SetHealth(spawnGrid[laneNum, 2].GetComponent<fireBullet>().GetHealth());
    //            Destroy(spawnGrid[laneNum, 2]);
    //        }
    //        if (spawnGrid[laneNum, 2].tag == "Wall")
    //        {
    //            spawnGrid[laneNum, 3] = Instantiate(spawnGrid[laneNum, 2], currentSpawn.transform.GetChild(3));
    //            spawnGrid[laneNum, 3].GetComponent<breakableWall>().SetHealth(spawnGrid[laneNum, 2].GetComponent<breakableWall>().GetHealth());
    //            Destroy(spawnGrid[laneNum, 2]);
    //        }
    //    }
    //    if (spawnGrid[laneNum, 1] != null)
    //    {
    //        if (spawnGrid[laneNum, 1].tag == "Turret")
    //        {
    //            spawnGrid[laneNum, 2] = Instantiate(spawnGrid[laneNum, 1], currentSpawn.transform.GetChild(2));
    //            spawnGrid[laneNum, 2].GetComponent<fireBullet>().SetHealth(spawnGrid[laneNum, 1].GetComponent<fireBullet>().GetHealth());
    //            Destroy(spawnGrid[laneNum, 1]);
    //        }
    //        if (spawnGrid[laneNum, 1].tag == "Wall")
    //        {
    //            spawnGrid[laneNum, 2] = Instantiate(spawnGrid[laneNum, 1], currentSpawn.transform.GetChild(2));
    //            spawnGrid[laneNum, 2].GetComponent<breakableWall>().SetHealth(spawnGrid[laneNum, 1].GetComponent<breakableWall>().GetHealth());
    //            Destroy(spawnGrid[laneNum, 1]);
    //        }
    //    }
    //    if (spawnGrid[laneNum, 0] != null)
    //    {
    //        if (spawnGrid[laneNum, 0].tag == "Turret")
    //        {
    //            spawnGrid[laneNum, 1] = Instantiate(spawnGrid[laneNum, 0], currentSpawn.transform.GetChild(1));
    //            spawnGrid[laneNum, 1].GetComponent<fireBullet>().SetHealth(spawnGrid[laneNum, 0].GetComponent<fireBullet>().GetHealth());
    //            Destroy(spawnGrid[laneNum, 0]);
    //        }
    //        if (spawnGrid[laneNum, 0].tag == "Wall")
    //        {
    //            spawnGrid[laneNum, 1] = Instantiate(spawnGrid[laneNum, 0], currentSpawn.transform.GetChild(1));
    //            spawnGrid[laneNum, 1].GetComponent<breakableWall>().SetHealth(spawnGrid[laneNum, 0].GetComponent<breakableWall>().GetHealth());
    //            Destroy(spawnGrid[laneNum, 0]);
    //        }
    //    }
    //    spawnGrid[laneNum, 0] = Instantiate(wall, currentSpawn.transform.GetChild(0));

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
    //}
}
