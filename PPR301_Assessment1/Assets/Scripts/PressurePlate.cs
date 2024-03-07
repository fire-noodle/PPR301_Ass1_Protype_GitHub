using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the other GameObject you're interested in
        if (collision.gameObject.CompareTag("PlayerFeet"))
        {
            Debug.Log("Collision detected with " + collision.gameObject.name);

            // Do something when the collision occurs, such as destroy the object
            // Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
