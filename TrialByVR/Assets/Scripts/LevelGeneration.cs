using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public List<Transform> GridPlaces = new List<Transform>();
    public List<GameObject> GridPrefabs = new List<GameObject>();
    public List<GameObject> PossibleTargets = new List<GameObject>();

    public Transform targetPoster;

    private GameObject Target;
    private List<Transform> SpawnPoints = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GridPlaces.Count; i++)
        {
            GameObject GO = Instantiate(GridPrefabs[Random.Range(0, GridPrefabs.Count)], GridPlaces[i]);
            for (int j = 0; j < GO.transform.GetChild(0).childCount; j++)
            {
                SpawnPoints.Add(GO.transform.GetChild(0).GetChild(j));
            }
        }
        Target = PossibleTargets[Random.Range(0, PossibleTargets.Count)];
        PossibleTargets.Remove(Target);
        int TargetSpawn = Random.Range(0, SpawnPoints.Count);
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            if (i == TargetSpawn)
            {
                GameObject GO = Instantiate(Target, SpawnPoints[i]);
                GO.GetComponent<TargetColourManager>().target = true;
            }
            else
                Instantiate(PossibleTargets[Random.Range(0, PossibleTargets.Count)], SpawnPoints[i]);
        }
        GameObject GOSmall = Instantiate(Target, targetPoster);
        GOSmall.GetComponent<TargetColourManager>().target = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
