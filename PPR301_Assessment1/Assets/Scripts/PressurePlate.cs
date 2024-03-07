using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the other GameObject you're interested in
        if (collision.gameObject.CompareTag("PlayerFeet") || collision.gameObject.CompareTag("equippable_pressable"))
        {
            Debug.Log("Collision detected with " + collision.gameObject.name);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
