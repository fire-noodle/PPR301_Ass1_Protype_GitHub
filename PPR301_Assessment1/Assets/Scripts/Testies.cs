using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;

public class Testies : MonoBehaviour
{

    public bool failure;


    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Interactables/CubeTimer", GetComponent<Transform>().position);
            failure = false;
        }
    }
}
