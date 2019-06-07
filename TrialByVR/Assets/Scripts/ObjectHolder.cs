using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    public Transform Hand;

    private Transform childObject;
    public GameObject selectCircle;

    //public enum Object {Sniper, Binocular, Target }
    public StateManager.Object holding;
    public LineRenderer LineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        childObject = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (StateManager.currentState == StateManager.States.Sniper)
        {
            if (holding == StateManager.Object.Sniper)
            {
                if (holding == StateManager.holding)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                }
            }
            else if (holding != StateManager.Object.Nothing)
            {
                if (holding == StateManager.holding)
                {
                    childObject.parent = Hand;
                    childObject.localPosition = Vector3.zero;
                    childObject.localRotation = Quaternion.Euler(Vector3.zero);
                }
                else
                {
                    childObject.parent = this.gameObject.transform;
                    childObject.SetAsFirstSibling();
                    childObject.localPosition = Vector3.zero;
                    childObject.localRotation = Quaternion.Euler(Vector3.zero);
                }
            }

            if (StateManager.holding == StateManager.Object.Nothing)
            {
                RaycastHit hit;
                if (Physics.Raycast(Hand.position, Hand.forward, out hit, 100))
                {
                    if (hit.transform == transform.GetChild(0))
                    {
                        selectCircle.SetActive(true);
                        if (OVRInput.Get(OVRInput.Axis1D.Any) >= 0.5f)
                        {
                            StateManager.holding = holding;
                        }
                    }
                    else
                    {
                        selectCircle.SetActive(false);
                    }
                    if (LineRenderer != null)
                    {
                        LineRenderer.SetPosition(0, Hand.position);
                        LineRenderer.SetPosition(1, hit.point);
                    }
                }
                else if (LineRenderer != null)
                {
                    LineRenderer.SetPosition(1, LineRenderer.GetPosition(0));
                }
            }
            else
            {
                selectCircle.SetActive(false);
                LineRenderer.SetPosition(1, LineRenderer.GetPosition(0));
            }
        }
    }
}
