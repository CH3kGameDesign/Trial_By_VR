using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] spawns;
    [Header("enemy game object")]
    public GameObject enemy;

    private int pickedSpawn;
    // Start is called before the first frame update
    void Start()
    {
        pickedSpawn = Random.Range(0, spawns.Length);

        Instantiate(enemy, spawns[pickedSpawn].transform.position, spawns[pickedSpawn].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
