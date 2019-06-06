using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class Object_Patrol : MonoBehaviour
{
    [SerializeField, Tooltip("Speed of the patrolling object.")]
    private float moveForce = 100;
    [SerializeField, Tooltip("Object's rotation speed.")]
    private int rotationSpeed = 5;
    [SerializeField, Tooltip("The distance from its target node before it turns.")]
    private float arrival_distance = 0.5f;
    [SerializeField, Tooltip("Transforms of the points you want the object to follow.")]
    private Transform[] patrolPoints;

    private Rigidbody rigid_body = null;
    private int node_index = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (patrolPoints.Length <= 0)
            return;

        transform.position = patrolPoints[0].position;

        rigid_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (patrolPoints.Length < 2 || rigid_body == null)
            return;

        Vector3 direction = patrolPoints[node_index].position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

        rigid_body.velocity = transform.forward * moveForce * Time.deltaTime;

        if (Vector3.Distance(transform.position, patrolPoints[node_index].position) <= arrival_distance)
        {
            ++node_index;
            // Wrap array index once it goes out of range
            node_index = (node_index % patrolPoints.Length + patrolPoints.Length) % patrolPoints.Length;
        }
    }
}
