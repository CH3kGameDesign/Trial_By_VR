using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class worldUI : MonoBehaviour
{
    public float timerLength;
    public Text timer;
    public Text ammoCount;

    public Sniper ammo;

    private float maxAmmo;

    // Start is called before the first frame update
    void Start()
    {
        timer.text = timerLength.ToString();
        maxAmmo = ammo.ammoCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerLength > 0)
        {
            timerLength -= Time.deltaTime;
        }
        else
        {
            timerLength = 0;
        }
        timer.text = timerLength.ToString("f2");
        
        ammoCount.text = ammo.ammoCount.ToString() + " / " + maxAmmo;
    }
}
