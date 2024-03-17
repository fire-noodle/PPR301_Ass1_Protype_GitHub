using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Spawner : MonoBehaviour
{
    public GameObject prefab; // The prefab you want to instantiate
    private GameObject spawnedObject; // Reference to the instantiated object
    public GameObject turorialSpawn1;
    public GameObject turorialSpawn2;

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
        spawnPosition = turorialSpawn1.transform.position;

        if (!isObjectSpawned)
        {
            // Instantiate the object at the spawn position
            spawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
            spawnedObject.GetComponent<Rigidbody>().isKinematic = true;
            isObjectSpawned = true; // Set the flag to true
        }
        else // If the object is spawned, respawn it
        {
            spawnedObject.SetActive(true);
            spawnedObject.transform.position = spawnPosition;

        }
    }

    public void Tutorial_Cube2()
    {
        spawnPosition = turorialSpawn2.transform.position;

        if (!isObjectSpawned)
        {
            // Instantiate the object at the spawn position
            spawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
            spawnedObject.GetComponent<Rigidbody>().isKinematic = true;
            isObjectSpawned = true; // Set the flag to true
        }
        else // If the object is spawned, respawn it
        {
            spawnedObject.SetActive(true);
            spawnedObject.transform.position = spawnPosition;
        }
    }
}
