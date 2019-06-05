using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum States { Menu, Sniper, Bullet}
    public States startState;
    public static States currentState;

    public GameObject HeadSet;

    [Space(10)]
    [Header("MenuStuff")]
    public List<GameObject> MenuObjects;

    [Space(10)]
    [Header("SniperStuff")]
    public List<GameObject> SniperObjects;
    public Transform tiltAmount;

    [Space(10)]
    [Header("BulletStuff")]
    public List<GameObject> BulletObjects;
    // Start is called before the first frame update
    void Start()
    {
        currentState = startState;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == States.Menu)
        {
            for (int i = 0; i < MenuObjects.Count; i++)
            {
                MenuObjects[i].SetActive(true);
            }
            for (int i = 0; i < SniperObjects.Count; i++)
            {
                SniperObjects[i].SetActive(false);
            }
            for (int i = 0; i < BulletObjects.Count; i++)
            {
                BulletObjects[i].SetActive(false);
            }
        }
        if (currentState == States.Sniper)
        {
            HeadSet.GetComponent<FollowPosition>().enabled = false;
            HeadSet.transform.position = Vector3.zero;
            for (int i = 0; i < MenuObjects.Count; i++)
            {
                MenuObjects[i].SetActive(false);
            }
            for (int i = 0; i < SniperObjects.Count; i++)
            {
                SniperObjects[i].SetActive(true);
            }
            for (int i = 0; i < BulletObjects.Count; i++)
            {
                BulletObjects[i].SetActive(false);
            }
            if (HeadSet.transform.eulerAngles.z <= -15)
            {
                if (Input.GetMouseButton(0))
                    Fire();
            }
            
        }
        if (currentState == States.Bullet)
        {
            for (int i = 0; i < MenuObjects.Count; i++)
            {
                MenuObjects[i].SetActive(false);
            }
            for (int i = 0; i < SniperObjects.Count; i++)
            {
                SniperObjects[i].SetActive(false);
            }
            for (int i = 0; i < BulletObjects.Count; i++)
            {
                BulletObjects[i].SetActive(true);
            }
            HeadSet.GetComponent<FollowPosition>().enabled = true;
        }
    }

    private void Fire()
    {
        currentState = States.Bullet;
    }
}
