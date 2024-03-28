using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Cube_Spawner cs;
    public GameObject collectible1;

    public bool spawnedCollectible1 = false;

    private Change_Emission_Colour CEC;

    void Start()
    {
        CEC = GetComponentInChildren<Change_Emission_Colour>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the other GameObject you're interested in
        if (collision.gameObject.CompareTag("PlayerFeet") || collision.gameObject.CompareTag("equippable_pressable"))
        {
            Debug.Log("Collision detected with " + collision.gameObject.name);

            if (/*this.transform.name == "Pressure_Plate" &&*/ spawnedCollectible1 == false)
            {
                collectible1.SetActive(true);
                spawnedCollectible1 = true;
            }

            CEC.ChangeEmission(Color.green);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
