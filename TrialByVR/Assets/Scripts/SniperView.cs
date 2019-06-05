using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperView : MonoBehaviour
{
    public static bool amSniping = false;

    public GameObject debug;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (amSniping == true)
        {
            debug.SetActive(true);
        }
        else
            debug.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            amSniping = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            amSniping = false;
    }

    private void OnDisable()
    {
        amSniping = false;
    }
}
