using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Spawner : MonoBehaviour
{
    public GameObject prefab; // The prefab you want to instantiate
    private GameObject spawnedObject; // Reference to the instantiated object
    public GameObject turorialSpawn;

    private bool isObjectSpawned = false; // Flag to track if the object is currently spawned
    private Vector3 spawnPosition;// Position to spawn the object initially

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tutorial_Cube()
    {
        spawnPosition = turorialSpawn.transform.position;

        if (!isObjectSpawned)
        {
            // Instantiate the object at the spawn position
            spawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
            spawnedObject.GetComponent<Rigidbody>().isKinematic = true;
            isObjectSpawned = true; // Set the flag to true
        }
        //else // If the object is spawned, delete it
        //{
        //    // Destroy the spawned object
        //    Destroy(spawnedObject);
        //    isObjectSpawned = false; // Set the flag to false

        //    // Instantiate the object at the spawn position
        //    spawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
        //    isObjectSpawned = true; // Set the flag to true
        //}
    }
}
