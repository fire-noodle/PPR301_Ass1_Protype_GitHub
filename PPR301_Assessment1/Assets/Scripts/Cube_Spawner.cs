using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Spawner : MonoBehaviour
{
    public GameObject prefab; // The prefab you want to instantiate
    private GameObject spawnedObject1; // Reference to the instantiated object
    private GameObject spawnedObject2;
    public GameObject turorialSpawn1;
    public GameObject turorialSpawn2;

    private bool isObject1Spawned = false; // Flag to track if the object is currently spawned
    private bool isObject2Spawned = false; // Flag to track if the object is currently spawned
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

        if (!isObject1Spawned)
        {
            // Instantiate the object at the spawn position
            spawnedObject1 = Instantiate(prefab, spawnPosition, Quaternion.identity);
            spawnedObject1.GetComponent<Rigidbody>().isKinematic = true;
            isObject1Spawned = true; // Set the flag to true
        }
        else // If the object is spawned, respawn it
        {
            spawnedObject1.SetActive(true);
            spawnedObject1.transform.position = spawnPosition;

        }
    }

    public void Tutorial_Cube2()
    {
        spawnPosition = turorialSpawn2.transform.position;

        if (!isObject2Spawned)
        {
            // Instantiate the object at the spawn position
            spawnedObject2 = Instantiate(prefab, spawnPosition, Quaternion.identity);
            spawnedObject2.GetComponent<Rigidbody>().isKinematic = true;
            isObject2Spawned = true; // Set the flag to true
        }
        else // If the object is spawned, respawn it
        {
            spawnedObject2.SetActive(true);
            spawnedObject2.transform.position = spawnPosition;
        }
    }
}
