using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugRotationText : MonoBehaviour
{

    public Transform HeadSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GetComponent<TextMeshPro>().text = HeadSet.transform.rotation.ToString();
    }
}
