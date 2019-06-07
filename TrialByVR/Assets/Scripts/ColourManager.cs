using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour
{
    public List<Color> possibleColours = new List<Color>();
    public static List<Color> Colours = new List<Color>();
    public static List<Color> TargetColours = new List<Color>();
    // Start is called before the first frame update
    void Start()
    {
        Colours = possibleColours;
        Color tarCol1 = possibleColours[Random.Range(0, possibleColours.Count)];
        Color tarCol2 = possibleColours[Random.Range(0, possibleColours.Count)];
        Color tarCol3 = possibleColours[Random.Range(0, possibleColours.Count)];
        TargetColours = new List<Color>();
        TargetColours.Add(tarCol1);
        TargetColours.Add(tarCol2);
        TargetColours.Add(tarCol3);
        Colours.Remove(tarCol1);
        if (tarCol1 != tarCol2)
            Colours.Remove(tarCol2);
        if (tarCol1 != tarCol3 && tarCol2 != tarCol3)
            Colours.Remove(tarCol3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
