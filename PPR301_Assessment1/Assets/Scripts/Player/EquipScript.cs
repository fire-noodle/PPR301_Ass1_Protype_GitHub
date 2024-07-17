using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Item1;
    public GameObject Collectable;
    public GameObject BigAssCube;
    public GameObject Player;
    public Camera Camera;
    public float range = 2f;
    public float open = 100f;

    public float throwForce = 5f;
    public Vector3 throwDirection = Vector3.forward;
    public Vector3 Teleport;
    public bool canThrow = false;

    public Cube_Spawner cs1;
    public Cube_Spawner cs2;
    public Door_Open_Conditional doc1;
    public Door_Open_Conditional doc2;
    public Door_Open_Conditional doc3;
    public PlayerData PD;

    public GameObject Collectable_UI;
    public TMP_Text currentCollectablesUI;
    public int collectableNum = 0;

    public Repulsion_Cube RC;
    public bool boom = false;

    public Canvas keypadCanvas;
    public Canvas keypadCanvas2;
    public Canvas keypadCanvas3;
    public FPS_Controller FPSC;

    public bool log1 = false;
    public bool log1done = false;


    //public Vector3 playerPos;

    // Reference to the FMOD Studio Event Emitter component
    private FMODUnity.StudioEventEmitter eventEmitter;

    // Start is called before the first frame update
    void Start()
    {
        Item1.GetComponent<Rigidbody>().isKinematic = true;

        Collectable_UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UnequipObject();
            Shoot();
        }

        if (boom == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Interactables/ExpulsionCube", GetComponent<Transform>().position);
            boom = false;
        }

    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {

            Target target = hit.transform.GetComponent<Target>();
            if (target != null && (hit.transform.CompareTag("equippable") || hit.transform.CompareTag("equippable_pressable") || hit.transform.CompareTag("equippable_pressable_repulsable")))
            {
                Item1 = hit.transform.gameObject;
                EquipObject();

                if (target != null && (hit.transform.CompareTag("equippable") || hit.transform.CompareTag("equippable_pressable")))
                {
                    StartCoroutine(CubeTimer());
                }
                if (target != null && hit.transform.CompareTag("equippable_pressable_repulsable"))
                {
                    StartCoroutine(CubeTimerRepulser());
                }
            }
            else if (target != null && hit.transform.CompareTag("collectable"))
            {
                // save data testers
                if (hit.transform.name == "StarCollectable")
                {
                    PD.col1 = true;
                }
                else if (hit.transform.name == "StarCollectable (1)")
                {
                    PD.col2 = true;
                }
                else if (hit.transform.name == "StarCollectable (2)")
                {
                    PD.col3 = true;
                }
                else if (hit.transform.name == "StarCollectable (3)")
                {
                    PD.col4 = true;
                }
                else if (hit.transform.name == "StarCollectable (4)")
                {
                    PD.col5 = true;
                }
                else if (hit.transform.name == "StarCollectable (5)")
                {
                    PD.col6 = true;
                }
                else if (hit.transform.name == "StarCollectable (6)")
                {
                    PD.col7 = true;
                }
                else if (hit.transform.name == "StarCollectable (cubeSpawner)")
                {
                    PD.col8 = true;
                }
                else if (hit.transform.name == "StarCollectable (spawned)")
                {
                    PD.col9 = true;
                }
                else if (hit.transform.name == "StarCollectable (9)")
                {
                    PD.col10 = true;
                }
                Collectable = hit.transform.gameObject;
                collectableNum++;
                currentCollectablesUI.text = collectableNum.ToString();
                Collectable.SetActive(false);
                Collectable_UI.SetActive(true);
                StartCoroutine(UIText());

                if (collectableNum == 4)
                {
                    doc1.DoorOpen2();
                }
                if (collectableNum == 7)
                {
                    doc2.DoorOpen2();
                }
                if (collectableNum == 10)
                {
                    doc3.DoorOpen2();
                }
            }
            else if (target != null && hit.transform.name == "button1")
            {
                //do button thing
                Teleport = new Vector3(80.8949966f, -18.9099998f, -14.9770002f);
                Player.transform.position = Teleport;

            }
            else if (target != null && hit.transform.name == "button2")
            {
                //do button thing
                Teleport = new Vector3(-0.995f, 1.015f, -2.55f);
                Player.transform.position = Teleport;

            }
            else if (target != null && hit.transform.name == "button3")
            {
                cs1.Tutorial_Cube();
            }
            else if (target != null && hit.transform.name == "button4")
            {
                cs2.Tutorial_Cube2();
            }
            else if (target != null && hit.transform.name == "button5")
            {
                cs2.Tutorial_Cube3();
            }
            else if (hit.transform.name == "keypad1")
            {
                FPSC.canMove = false;
                FPSC.canZoom = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                keypadCanvas.gameObject.SetActive(true);
            }
            else if (hit.transform.name == "keypad2")
            {
                FPSC.canMove = false;
                FPSC.canZoom = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                keypadCanvas2.gameObject.SetActive(true);
            }
            else if (hit.transform.name == "keypad3")
            {
                FPSC.canMove = false;
                FPSC.canZoom = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                keypadCanvas3.gameObject.SetActive(true);
            }
            /*
            if ((hit.transform.gameObject.GetComponent("StudioEventEmitter")) != null && (hit.transform.CompareTag("AudioLog")))
            {
                eventEmitter = hit.transform.gameObject.GetComponent<FMODUnity.StudioEventEmitter>();
                eventEmitter.Play();

            }
            */

            if (hit.transform.CompareTag("AudioLog"))
			{
                eventEmitter = hit.transform.gameObject.GetComponent<FMODUnity.StudioEventEmitter>();
                eventEmitter.Play();
            }
        }
    }

    void UnequipObject()
    {
        PlayerTransform.DetachChildren();
        Item1.transform.eulerAngles = new Vector3(Item1.transform.eulerAngles.x, Item1.transform.eulerAngles.y, Item1.transform.eulerAngles.z);
        Item1.GetComponent<Rigidbody>().isKinematic = false;

        throwDirection = Item1.transform.forward;

        //throw
        if (canThrow)
        {
            Item1.GetComponent<Rigidbody>().AddForce(throwDirection * throwForce, ForceMode.Impulse);
            canThrow = false;
        }

    }

    void EquipObject()
    {
        Item1.GetComponent<Rigidbody>().isKinematic = true;
        Item1.transform.position = PlayerTransform.transform.position;
        Item1.transform.rotation = PlayerTransform.transform.rotation;
        Item1.transform.SetParent(PlayerTransform);

        eventEmitter = GetComponentInChildren<FMODUnity.StudioEventEmitter>();
        eventEmitter.Play();

        canThrow = true;
    }

    IEnumerator CubeTimer()
    {
        yield return new WaitForSeconds(5); // Wait for 5 seconds

        // Code to execute after 5 seconds
        Debug.Log("Cube despawned!");
        PlayerTransform.DetachChildren();
        Item1.SetActive(false);
    }
    IEnumerator CubeTimerRepulser()
    {
        yield return new WaitForSeconds(5); // Wait for 5 seconds

        // Code to execute after 5 seconds
        boom = true;
        PlayerTransform.DetachChildren();

        //repulsives start here
        RC.Repulse();
        Item1.SetActive(false);
    }
    IEnumerator UIText()
    {
        yield return new WaitForSeconds(5); // Wait for 5 seconds

        Collectable_UI.SetActive(false);
    }


    //public void SaveGame()
    //{
    //    SaveSystem.SavePlayer(this);
    //}
    //public void LoadGame()
    //{
    //    PlayerData data = SaveSystem.LoadPlayer();

    //    Vector3 position;
    //    position.x = data.position[0];
    //    position.y = data.position[1];
    //    position.z = data.position[2];

    //    Player.transform.position = position;

    //    collectableNum = data.collectables;

    //}
}