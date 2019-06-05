using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugRotationText : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GetComponent<TextMeshPro>().text = OVRInput.Get(OVRInput.Axis1D.Any).ToString();
    }
}
