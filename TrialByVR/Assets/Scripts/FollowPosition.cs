using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPosition : MonoBehaviour
{

    public Transform tarPos;
    public float speed;

    public bool followBullet = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (followBullet)
        {
            speed = BulletVelocity.currentBullet.GetComponent<Rigidbody>().velocity.magnitude;
            
            transform.position = tarPos.position;
            transform.position -= tarPos.forward * speed / 5;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, tarPos.position, Time.deltaTime * speed);
        }
    }
}
