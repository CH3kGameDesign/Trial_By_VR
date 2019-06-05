using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class Object_Patrol : MonoBehaviour
{
    [SerializeField] private float patrolSpeed;
    [SerializeField] private Transform[] patrolPoints;

    private float arrival_distance = 0.5f;
    private float lerp_time = 0.5f;

    private Rigidbody rigid_body = null;
    private int node_index = 0;

    private Vector3 start_velocity;
    private float lerp_timer;

    // Start is called before the first frame update
    void Start()
    {
        if (patrolPoints.Length <= 0)
            return;

        transform.position = patrolPoints[0].position;

        rigid_body = GetComponent<Rigidbody>();

        lerp_timer = lerp_time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (patrolPoints.Length <= 0 || rigid_body == null)
            return;

        Vector3 directional_force = (patrolPoints[node_index].position - transform.position).normalized;
        directional_force *= patrolSpeed + Time.deltaTime;

        if (lerp_timer < lerp_time)
        {
            rigid_body.velocity = Vector3.Slerp(start_velocity, directional_force, lerp_timer / lerp_time);
        }


        rigid_body.velocity = directional_force;

        if (Vector3.Distance(transform.position, patrolPoints[node_index].position) <= arrival_distance)
        {
            ++node_index;
            // Wrap array index once it goes out of range
            node_index = (node_index % patrolPoints.Length + patrolPoints.Length) % patrolPoints.Length;

            start_velocity = rigid_body.velocity;
            lerp_timer = 0;
        }
    }
}
