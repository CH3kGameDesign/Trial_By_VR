using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaycastEnable : MonoBehaviour
{
    public Transform originTransform;
    public List<GameObject> GO = new List<GameObject>();
    public List<GameObject> GODisable = new List<GameObject>();

    [Space(10)]

    public List<GameObject> Collider = new List<GameObject>();
    public List<GameObject> ColliderDisable = new List<GameObject>();

    public UnityEvent activateEvent;

    public float Timer;

    public bool throughObjects = false;
    public bool onClick = false;
    public bool disableOnLookAway = false;
    
    public Transform MoveToHitPoint;

    // Use this for initialization
    void Start()
    {
        if (activateEvent == null)
            activateEvent = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        if (onClick == false)
            RaycastyGoodness();
        else
        {
            if (Input.GetMouseButtonDown(0))
                RaycastyGoodness();
        }
    }

    void RaycastyGoodness()
    {
        RaycastHit hit;
        if (throughObjects == false)
        {
            //if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane)), out hit, 100))
            if (Physics.Raycast(originTransform.position, originTransform.forward, out hit, 100))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    if (MoveToHitPoint != null)
                    {
                        MoveToHitPoint.gameObject.SetActive(true);
                        MoveToHitPoint.position = hit.point;
                    }
                    Invoke("EnableObjects", Timer);
                    activateEvent.Invoke();
                }
                else
                {
                    if (MoveToHitPoint != null)
                        MoveToHitPoint.gameObject.SetActive(false);
                }
            }
            else
            {
                if (MoveToHitPoint != null)
                    MoveToHitPoint.gameObject.SetActive(false);
                if (disableOnLookAway == true)
                {
                    DisableObjects();
                }
            }
        }
        else
        {
            //if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane)), out hit, 100, 1 << this.gameObject.layer))
            if (Physics.Raycast(originTransform.position, originTransform.forward, out hit, 100, 1 << this.gameObject.layer))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    if (MoveToHitPoint != null)
                    {
                        MoveToHitPoint.gameObject.SetActive(true);
                        MoveToHitPoint.position = hit.point;
                    }
                    Invoke("EnableObjects", Timer);
                    activateEvent.Invoke();
                }
                else
                {
                    if (MoveToHitPoint != null)
                        MoveToHitPoint.gameObject.SetActive(false);
                }
            }
            else
            {
                if (MoveToHitPoint != null)
                    MoveToHitPoint.gameObject.SetActive(false);
                if (disableOnLookAway == true)
                {
                    DisableObjects();
                }
            }
        }
    }

    private void EnableObjects()
    {
        for (int i = 0; i < GO.Count; i++)
        {
            GO[i].SetActive(true);
        }
        for (int i = 0; i < GODisable.Count; i++)
        {
            GODisable[i].SetActive(false);
        }

        for (int i = 0; i < Collider.Count; i++)
        {
            for (int j = 0; j < Collider[i].GetComponentsInChildren<Collider>().Length; j++)
            {
                Collider[i].GetComponentsInChildren<Collider>()[j].enabled = true;
            }

        }
        for (int i = 0; i < ColliderDisable.Count; i++)
        {
            for (int j = 0; j < ColliderDisable[i].GetComponentsInChildren<Collider>().Length; j++)
            {
                ColliderDisable[i].GetComponentsInChildren<Collider>()[j].enabled = false;
            }
        }
    }
    private void DisableObjects()
    {
        for (int i = 0; i < GO.Count; i++)
        {
            GO[i].SetActive(false);
        }
        for (int i = 0; i < GODisable.Count; i++)
        {
            GODisable[i].SetActive(true);
        }

        for (int i = 0; i < Collider.Count; i++)
        {
            for (int j = 0; j < Collider[i].GetComponentsInChildren<Collider>().Length; j++)
            {
                Collider[i].GetComponentsInChildren<Collider>()[j].enabled = false;
            }

        }
        for (int i = 0; i < ColliderDisable.Count; i++)
        {
            for (int j = 0; j < ColliderDisable[i].GetComponentsInChildren<Collider>().Length; j++)
            {
                ColliderDisable[i].GetComponentsInChildren<Collider>()[j].enabled = true;
            }
        }
    }
}