using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AFPC;
public class FollowPlayer : MonoBehaviour
{
    public Transform player;        
    public float moveSpeed = 5f;    
    public float stoppingDistance = 2f;  
    public int health = 10;
    public Lifecycle lifecycle;
    public Hero hero;
    void Update()
    {
        if (player == null) return;

       
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // Optional: Keep movement on the horizontal plane

        // Rotate to look at the player
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }

        
        float distance = direction.magnitude;
        /*
        if (distance > stoppingDistance)
        {
            Vector3 moveDir = direction.normalized;
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
        */
        Vector3 moveDir = direction.normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        if (health <= 0)
        {
            Destroy(gameObject);
            hero.cardboard = hero.cardboard + 15; 
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PB"))
        {
            health = health - 1;

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            lifecycle.Damage(1f);
            Debug.Log("damage");
        }
    }

}