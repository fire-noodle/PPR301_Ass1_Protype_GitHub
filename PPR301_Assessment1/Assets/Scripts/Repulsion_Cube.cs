using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulsion_Cube : MonoBehaviour
{

    public float repulseForce = 10000f; // The force of the blast
    public float repulseRadius = 50f; // The radius within which objects are affected

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Repulse()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, repulseRadius);

        foreach (Collider col in colliders)
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 direction = (col.transform.position - transform.position).normalized;
                rb.AddForce(direction * repulseForce, ForceMode.Impulse);

                Debug.Log("Repulsed!");
            }
        }
    }
}
