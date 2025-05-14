using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
   public GameObject objectToSpawn; // The prefab to spawn
    public Transform spawnPoint; // Where the object will be spawned
    public float spawnInterval = 3f; // Time between spawns
    public int amount;
    void Start()
    {
        amount = 20;
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        if(amount > 0)
        {
            if (objectToSpawn != null && spawnPoint != null)
            {
                Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
                amount = amount - 1;
            }
            else
            {
                Debug.LogWarning("Spawner is missing an object or spawn point!");
            }
        }
        
    }
}
