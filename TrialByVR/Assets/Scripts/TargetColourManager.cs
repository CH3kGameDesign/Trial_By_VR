using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetColourManager : MonoBehaviour
{

    public List<Renderer> MatSet1;
    public List<Renderer> MatSet2;
    public List<Renderer> MatSet3;

    [HideInInspector]
    public bool target = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LateStart", 0.0001f);
    }
    void LateStart ()
    {
        if (target == true)
        {
            if (MatSet1.Count != 0)
            {
                for (int i = 0; i < MatSet1.Count; i++)
                {
                    MatSet1[i].material.color = ColourManager.TargetColours[0];
                }
            }
            if (MatSet2.Count != 0)
            {
                for (int i = 0; i < MatSet2.Count; i++)
                {
                    MatSet2[i].material.color = ColourManager.TargetColours[1];
                }
            }
            if (MatSet3.Count != 0)
            {
                for (int i = 0; i < MatSet3.Count; i++)
                {
                    MatSet3[i].material.color = ColourManager.TargetColours[2];
                }
            }
        }
        else
        {
            if (MatSet1.Count != 0)
            {
                Color ranColor = ColourManager.Colours[Random.Range(0, ColourManager.Colours.Count)];
                for (int i = 0; i < MatSet1.Count; i++)
                {
                    MatSet1[i].material.color = ranColor;
                }
            }
            if (MatSet2.Count != 0)
            {
                Color ranColor = ColourManager.Colours[Random.Range(0, ColourManager.Colours.Count)];
                for (int i = 0; i < MatSet2.Count; i++)
                {
                    MatSet2[i].material.color = ranColor;
                }
            }
            if (MatSet3.Count != 0)
            {
                Color ranColor = ColourManager.Colours[Random.Range(0, ColourManager.Colours.Count)];
                for (int i = 0; i < MatSet3.Count; i++)
                {
                    MatSet3[i].material.color = ranColor;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
