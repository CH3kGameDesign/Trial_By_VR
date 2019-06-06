using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public GameObject bullet;
    public GameObject cameraObj;

    public ParticleSystem particleToSeeEnemy;

    public float ammoCount;
    // Start is called before the first frame update
    void Start()
    {
        particleToSeeEnemy.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && GameObject.FindGameObjectsWithTag("Bullet").Length == 0 && ammoCount > 0)
        {
            Instantiate(bullet, this.transform.position, cameraObj.transform.rotation);
            ammoCount -= 1;
        }

        if (Input.anyKeyDown && GameObject.FindGameObjectsWithTag("Bullet").Length == 0)
        {
            Instantiate(bullet, this.transform.position, cameraObj.transform.rotation);
            ammoCount -= 1;
        }

        if(Input.GetKey(KeyCode.Y))
        {
            if (!particleToSeeEnemy.isPlaying)
            {
                particleToSeeEnemy.Play();
            }
        }
        else
        {
            particleToSeeEnemy.Stop();
        }
    }
}
