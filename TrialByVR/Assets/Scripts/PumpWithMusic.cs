using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpWithMusic : MonoBehaviour
{

    public float beatsPerMinute;

    private float beatsPerSecond;

    private float timer;
    public static float distanceToBeat;
    public static float distanceToBeatClamped;
    // Start is called before the first frame update
    void Start()
    {
        beatsPerSecond = beatsPerMinute / 60;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float beatNo = timer * beatsPerSecond;
        float beatNoRound = Mathf.Round(beatNo);
        distanceToBeat = Mathf.Abs(beatNo - beatNoRound);

        transform.localScale = Vector3.one + new Vector3(distanceToBeat/2, distanceToBeat/2, distanceToBeat/2);
    }
}
