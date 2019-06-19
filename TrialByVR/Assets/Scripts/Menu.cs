using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Transform Hand;
    public GameObject selectCircle;
    public GameObject menuItems;
    public enum States { closed, open}
    public States currentState = States.closed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == States.open)
        {
            selectCircle.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(false);
            menuItems.SetActive(true);

            if (OVRInput.Get(OVRInput.Button.One) || StateManager.holding != StateManager.Object.Nothing)
                currentState = States.closed;
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
            menuItems.SetActive(false);
            if (StateManager.holding == StateManager.Object.Nothing)
            {
                RaycastHit hit;
                if (Physics.Raycast(Hand.position, Hand.forward, out hit, 100))
                {
                    if (hit.transform == transform.GetChild(0))
                    {
                        selectCircle.SetActive(true);
                        if (OVRInput.Get(OVRInput.Axis1D.Any) >= 0.5f)
                            currentState = States.open;
                    }
                    else
                    {
                        selectCircle.SetActive(false);
                    }
                }
            }
            else
            {
                selectCircle.SetActive(false);
            }
        }
    }

    public void LoadScene (int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }
}
