using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Door_Open_Conditional : MonoBehaviour
{

    public Animator animator;
    public bool Action = false;
    public bool opened = false;

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
        if (opened == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Interactables/DoorOpen", GetComponent<Transform>().position);
            opened = false;
        }

    }

    public void DoorOpen2()
    {
        opened = true;
        if (this.transform.name == "OpenDoor2")
        {
            animator.SetBool("Open", true);
        }
        if (this.transform.name == "OpenDoor3")
        {
            animator.SetBool("Open", true);
        }
        if (this.transform.name == "OpenDoor4")
        {
            animator.SetBool("Open", true);
        }
        if (this.transform.name == "OpenDoor5")
        {
            animator.SetBool("Open", true);
        }
        if (this.transform.name == "OpenDoor6")
        {
            animator.SetBool("Open", true);
        }
        if (this.transform.name == "OpenDoor7")
        {
            animator.SetBool("Open", true);
        }
    }

}
