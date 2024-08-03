using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV2_Cube_Spawner : MonoBehaviour
{
    public GameObject prefab; // cube
    public GameObject prefab_repulse; //repulsion cube
    private GameObject spawnedObject1; // Reference to the instantiated object
    public GameObject turorialSpawn1;

    private bool isObject1Spawned = false; // Flag to track if the object is currently spawned
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
        else // If the object is spawned, destroy it
        {
            if (spawnedObject1 != null)
            {
                Destroy(spawnedObject1);
                spawnedObject1 = Instantiate(prefab, spawnPosition, Quaternion.identity);
                spawnedObject1.GetComponent<Rigidbody>().isKinematic = true;
            }
            else
            {
                spawnedObject1 = Instantiate(prefab, spawnPosition, Quaternion.identity);
                spawnedObject1.GetComponent<Rigidbody>().isKinematic = true;

            }
        }
    }

}
