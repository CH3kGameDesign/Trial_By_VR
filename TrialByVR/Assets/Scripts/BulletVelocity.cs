using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletVelocity : MonoBehaviour
{
    public float maxVelocity;
    private float curMaxVelocity;
    public float maxMaxVelocity;
    public float acceleration;

    public Transform matchTar;
    private Rigidbody rb;

    public static GameObject currentBullet;
    
    private float rotCount;
    private float timeCount;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        curMaxVelocity = maxVelocity;
        transform.rotation = matchTar.rotation;
        currentBullet = this.gameObject;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 100, ForceMode.Impulse);
    }

    /*
    private void Awake()
    {
        
    }
    */

    // Update is called once per frame
    void Update()
    {
        rotCount += Mathf.Abs(Quaternion.Angle(transform.rotation, matchTar.rotation));
        timeCount += Time.deltaTime;

        float tempRotCount = Mathf.Round(rotCount * 100) / 100;
        float tempTimeCount = Mathf.Round(timeCount * 100) / 100;

        StateManager.rotCountTextStatic.text = tempRotCount.ToString();
        StateManager.timeCountTextStatic.text = tempTimeCount.ToString();
        transform.rotation = matchTar.rotation;
        rb.AddForce(transform.forward * acceleration, ForceMode.Acceleration);

        if (rb.velocity.magnitude > curMaxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, curMaxVelocity);
        }

        if (OVRInput.Get(OVRInput.Axis1D.Any) >= 0.5f)
            curMaxVelocity = Mathf.Lerp(curMaxVelocity, maxMaxVelocity, Time.deltaTime * 10);
        else
            curMaxVelocity = Mathf.Lerp(curMaxVelocity, maxVelocity, Time.deltaTime * 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        rb.velocity = Vector3.zero;
        StateManager.currentState = StateManager.States.Sniper;
        Destroy(this.gameObject);
        if (other.transform.parent.tag == "Target")
            StateManager.win = true;
    }
}
