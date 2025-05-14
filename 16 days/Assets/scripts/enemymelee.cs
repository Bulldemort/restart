using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = .0000001f; // Speed at which the object moves
    public float rotationSpeed = 5f; // Speed at which the object rotates
    public float stopDistance = 3f; // Distance at which the object stops moving
    public float health = 10f;
    
    private float initialYPosition; // Stores the object's starting Y position
    public Animator anim; 
    void Start()
    {
        // Store the initial Y position to prevent vertical movement
        initialYPosition = transform.position.y;
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference is missing!");
            return;
        }

        // Calculate direction towards the player, ignoring Y-axis movement
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Prevent looking up or down

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Rotate towards the player while keeping upright
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move towards the player while keeping the original Y position
        if (distanceToPlayer > stopDistance)
        {
            Vector3 newPosition = transform.position + direction * moveSpeed * Time.deltaTime;
            newPosition.y = initialYPosition; // Maintain original Y position
            transform.position = newPosition;
        }
         if (distanceToPlayer <= stopDistance)
        {
            
        }
        if(health <= 0)
        {
          Destroy(gameObject);
        }
    }
        void OnCollisionEnter(Collision collision)
        {
            // Check if the collided object has the tag "PB"
            if (collision.gameObject.CompareTag("PB"))
            {
                health = health - 1f;
            }
        }
    
}
