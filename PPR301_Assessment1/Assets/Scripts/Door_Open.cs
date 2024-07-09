using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour
{

    public Animator animator;
    public bool Action = false;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            Action = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Action = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                Action = false;
                animator.SetBool("Open", true);
                FMODUnity.RuntimeManager.PlayOneShot("event:/Interactables/DoorOpen", GetComponent<Transform>().position);
            }
        }

    }

    public void DoorOpen2()
    {
        if (this.transform.name == "DoorOpen2")
        {
            animator.SetBool("Open", true);
        }
    }
}
