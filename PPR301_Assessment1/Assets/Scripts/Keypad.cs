using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;

public class Keypad : MonoBehaviour
{

    public TMP_InputField characterHolder;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    public GameObject b5;
    public GameObject b6;
    public GameObject b7;
    public GameObject b8;
    public GameObject b9;
    public GameObject b0;
    public GameObject b_enter;
    public GameObject b_clear;
    public GameObject b_exit;

    public GameObject collectable1;

    public Canvas keypadCanvas;
    public FPS_Controller FPSC;

    public Door_Open_Conditional doc1;

    public bool failure = false;
    public bool success = false;
    public bool collected1 = false;

    void Update()
    {
        if (failure == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Interactables/KeypadError", GetComponent<Transform>().position);
            failure = false;
        }
        if (success == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Interactables/KeypadSuccess", GetComponent<Transform>().position);
            success = false;
        }
    }

    public void B1()
    {
        characterHolder.text = characterHolder.text + "1";
    }
    public void B2()
    {
        characterHolder.text = characterHolder.text + "2";
    }
    public void B3()
    {
        characterHolder.text = characterHolder.text + "3";
    }
    public void B4()
    {
        characterHolder.text = characterHolder.text + "4";

    }
    public void B5()
    {
        characterHolder.text = characterHolder.text + "5";
    }
    public void B6()
    {
        characterHolder.text = characterHolder.text + "6";
    }
    public void B7()
    {
        characterHolder.text = characterHolder.text + "7";
    }
    public void B8()
    {
        characterHolder.text = characterHolder.text + "8";
    }
    public void B9()
    {
        characterHolder.text = characterHolder.text + "9";
    }
    public void B0()
    {
        characterHolder.text = characterHolder.text + "0";
    }

    public void ClearPressed()
    {
        characterHolder.text = null;
    }

    public void EnterPressed()
    {

        if (characterHolder.text == "19" && this.transform.name == "keypad1")
        {
            //door open
            doc1.DoorOpen2();

            //reactivate player
            keypadCanvas.gameObject.SetActive(false);
            FPSC.canMove = true;
            FPSC.canZoom = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            success = true;
        }
        else if (characterHolder.text == "411" && this.transform.name == "keypad2")
        {
            //door open
            doc1.DoorOpen2();

            //reactivate player
            keypadCanvas.gameObject.SetActive(false);
            FPSC.canMove = true;
            FPSC.canZoom = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            success = true;
        }
        else if (characterHolder.text == "2784" && this.transform.name == "keypad3")
        {
            //door open
            doc1.DoorOpen2();

            //reactivate player
            keypadCanvas.gameObject.SetActive(false);
            FPSC.canMove = true;
            FPSC.canZoom = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            success = true;
        }
        //Level 2 keypads
        else if (characterHolder.text == "5297" && this.transform.name == "LV2keypad1")
        {
            if (collected1 == false)
            {
                //spawn collectable
                collectable1.SetActive(true);
                collected1 = true;
            }

            //reactivate player
            keypadCanvas.gameObject.SetActive(false);
            FPSC.canMove = true;
            FPSC.canZoom = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            success = true;
        }
        else if (characterHolder.text == "5041" && this.transform.name == "LV2keypad2")
        {
            //door open
            doc1.DoorOpen2();

            //reactivate player
            keypadCanvas.gameObject.SetActive(false);
            FPSC.canMove = true;
            FPSC.canZoom = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            success = true;
        }
        else
        {
            failure = true;
        }


    }

    public void ExitPressed()
    {

        //reactivate player
        keypadCanvas.gameObject.SetActive(false);
        FPSC.canMove = true;
        FPSC.canZoom = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame

}
