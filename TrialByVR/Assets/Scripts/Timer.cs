using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public int startMinutes;
    public int startSeconds;

    public static int currentMinutes;
    public static int currentSeconds;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        currentMinutes = startMinutes;
        currentSeconds = startSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 1)
        {
            currentSeconds--;
            if (currentSeconds < 0)
            {
                currentSeconds = 60;
                currentMinutes--;
            }
            timer = 0;
        }
        timer += Time.deltaTime;
        string Minutes = currentMinutes.ToString();
        string Seconds = currentSeconds.ToString();
        if (currentSeconds < 10)
            Seconds = "0" + Seconds;
        GetComponent<TextMeshPro>().text = "0" + Minutes + "-" + Seconds;
    }
}
