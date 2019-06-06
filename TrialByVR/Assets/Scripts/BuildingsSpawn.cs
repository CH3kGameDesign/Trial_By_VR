using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsSpawn : MonoBehaviour
{

    public GameObject[] buildingSpawnLocations;
    [Header("buildings")]
    public GameObject[] buildingPrefabs;

    private int chosenBuilding;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < buildingSpawnLocations.Length; i++)
        {
            chosenBuilding = Random.Range(0, buildingPrefabs.Length);
            Instantiate(buildingPrefabs[chosenBuilding], buildingSpawnLocations[i].transform.position, buildingSpawnLocations[i].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
