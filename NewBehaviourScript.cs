using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviour : MonoBehaviour
{
    public Transform target; // The target GameObject to follow
    public float speed = 5f; // The speed at which the object follows the target

    void Update()
    {
        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 direction = target.position - transform.position;

            // Normalize the direction vector to keep the speed constant
            direction.Normalize();

            // Move towards the target
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}