using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.CompareTag("enemy1"))
        {
            Debug.Log($"{gameObject.name} collided with Enemy1 and got destroyed.");
            Destroy(gameObject);
        }
    }
}
