using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObstacleSpawn : MonoBehaviour
{
    public GameObject[] spawnLocations;
    [Header("objects")]
    public GameObject[] flyingObjects;
    [Range(0,100)]
    public int chanceToSpawn;

    private int randomNum;
    private int chosenObj;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < spawnLocations.Length; i++)
        {
            randomNum = Random.Range(0, 100);
            chosenObj = Random.Range(0, flyingObjects.Length);
            if (chanceToSpawn > randomNum)
            {
                Instantiate(flyingObjects[chosenObj], spawnLocations[i].transform.position, spawnLocations[i].transform.rotation);
            }
            else
            {
                continue;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
