using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum States { Menu, Sniper, Bullet}
    public States startState;
    public static States currentState;

    public GameObject HeadSet;
    public Transform Controller;
    public Transform Hand;
    public Transform snipingHandPos;
    [Space(10)]
    [Header("MenuStuff")]
    public List<GameObject> MenuObjects;

    [Space(10)]
    [Header("SniperStuff")]
    public List<GameObject> SniperObjects;

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
            if (SniperView.amSniping == true)
            {
                if (OVRInput.Get(OVRInput.Axis1D.Any) >= 0.5f)
                    Fire();
                Hand.GetComponent<FollowPosition>().tarPos = snipingHandPos;
            }
            else
                Hand.GetComponent<FollowPosition>().tarPos = Controller;

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
