using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVelocity : MonoBehaviour
{
    public float maxVelocity;
    public float acceleration;

    private Rigidbody rb;

    public static GameObject currentBullet;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        currentBullet = this.gameObject;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * acceleration, ForceMode.Acceleration);

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = startPos;
        StateManager.currentState = StateManager.States.Sniper;
    }
}
