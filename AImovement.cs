using UnityEngine;

public class AImovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float initialSpeed = 3f;
    public float maxSpeed = 8f;
    public float accelerationRate = 1f;
    public float rotationSpeed = 2f;

    private float currentSpeed;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        currentSpeed = initialSpeed;
    }

    private void Update()
    {
        MoveTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("No waypoints assigned to the AI Racer.");
            return;
        }

        // Accelerate the AI
        currentSpeed = Mathf.Clamp(currentSpeed + accelerationRate * Time.deltaTime, initialSpeed, maxSpeed);

        // Calculate direction to the current waypoint
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        direction.Normalize();

        // Move towards the waypoint with current speed
        transform.Translate(direction * currentSpeed * Time.deltaTime, Space.World);

        // Rotate towards the waypoint
        RotateTowardsWaypoint(direction);

        // Check if the AI has reached the current waypoint
        float distance = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);
        if (distance < 0.5f)
        {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }

    void RotateTowardsWaypoint(Vector3 direction)
    {
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}
