using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open_Conditional : MonoBehaviour
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
        // No open with E because is conditional

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    if (Action == true)
        //    {
        //        Action = false;
        //        animator.SetBool("Open", true);
        //    }
        //}

    }

    public void DoorOpen2()
    {
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
    }

}
