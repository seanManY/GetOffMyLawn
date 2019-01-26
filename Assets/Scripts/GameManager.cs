using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject lane1Spawn;
    public GameObject lane2Spawn;
    public GameObject lane3Spawn;
    public GameObject lane4Spawn;
    public GameObject lane5Spawn;
    public GameObject lane6Spawn;
    public GameObject lane7Spawn;
    public GameObject lane8Spawn;
    public GameObject lane9Spawn;

    public GameObject basicEnemy;

    // Start is called before the first frame update
    void Start()
    {
        //lane1Spawn.transform.localPosition = new Vector3(0, 0, 0);
        Instantiate(basicEnemy, lane1Spawn.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
