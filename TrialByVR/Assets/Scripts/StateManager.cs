using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public enum States { Menu, Sniper, Bullet}
    public States startState;
    public enum Object { Nothing, Sniper, Binocular, Target}
    public static Object holding;

    public static States currentState;

    public GameObject HeadSet;
    public Transform Controller;
    public Transform Hand;

    public GameObject bullet;
    public Transform BulletHolder;

    public GameObject controllerObject;
    public GameObject SniperObject;

    public Transform snipingHandPos;
    [Space(10)]
    [Header("MenuStuff")]
    public List<GameObject> MenuObjects;

    [Space(10)]
    [Header("SniperStuff")]
    public List<GameObject> SniperObjects;
    public List<GameObject> winObjects;
    public TextMeshPro rotCountText;
    public TextMeshPro timeCountText;
    public static TextMeshPro rotCountTextStatic;
    public static TextMeshPro timeCountTextStatic;
    public static bool win;
    private bool triggerPress;

    [Space(10)]
    [Header("BulletStuff")]
    public List<GameObject> BulletObjects;
    // Start is called before the first frame update
    void Start()
    {
        win = false;
        rotCountTextStatic = rotCountText;
        timeCountTextStatic = timeCountText;
        holding = Object.Nothing;
        currentState = startState;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Fire();
        if (currentState == States.Menu)
        {
            holding = Object.Nothing;
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
            if (holding == Object.Sniper)
            {
                controllerObject.SetActive(false);
                SniperObject.SetActive(true);
                if (SniperView.amSniping == true)
                {
                    if (OVRInput.Get(OVRInput.Axis1D.Any) >= 0.5f && win == false && triggerPress == false)
                        Fire();
                    Hand.GetComponent<FollowPosition>().tarPos = snipingHandPos;
                }
                else
                    Hand.GetComponent<FollowPosition>().tarPos = Controller;
            }
            if (holding == Object.Binocular)
            {
                controllerObject.SetActive(false);
                SniperObject.SetActive(false);
                Hand.GetComponent<FollowPosition>().tarPos = snipingHandPos;
            }
            if (holding == Object.Target)
            {
                controllerObject.SetActive(false);
                SniperObject.SetActive(false);
                Hand.GetComponent<FollowPosition>().tarPos = Controller;
            }
            if (holding == Object.Nothing)
            {
                controllerObject.SetActive(true);
                SniperObject.SetActive(false);
                Hand.GetComponent<FollowPosition>().tarPos = Controller;
            }
            if (OVRInput.Get(OVRInput.Button.One))
                holding = Object.Nothing;

            if (win == true)
            {
                for (int i = 0; i < winObjects.Count; i++)
                {
                    winObjects[i].SetActive(true);
                }
            }

            if (OVRInput.Get(OVRInput.Axis1D.Any) >= 0.5f && win == true && triggerPress == false)
                SceneManager.LoadScene(0);

            if (OVRInput.Get(OVRInput.Axis1D.Any) >= 0.5f)
                triggerPress = true;
            else
                triggerPress = false;
        }
        if (currentState == States.Bullet)
        {
            holding = Object.Nothing;
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
            HeadSet.GetComponent<FollowPosition>().tarPos = BulletHolder.GetChild(0);
            if (OVRInput.Get(OVRInput.Button.One))
            {
                currentState = States.Sniper;
                Destroy(BulletHolder.GetChild(0).gameObject);
            }
        }
    }

    private void Fire()
    {
        GameObject GO = Instantiate(bullet, BulletHolder);
        GO.GetComponent<BulletVelocity>().matchTar = Controller;
        currentState = States.Bullet;
    }
}
