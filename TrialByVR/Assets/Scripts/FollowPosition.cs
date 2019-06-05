using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{

    public Transform tarPos;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = BulletVelocity.currentBullet.GetComponent<Rigidbody>().velocity.magnitude;
        //transform.position = Vector3.Lerp(transform.position, tarPos.position, Time.deltaTime * speed);
        transform.position = tarPos.position;
        transform.position -= tarPos.forward * speed/5;
    }
}
