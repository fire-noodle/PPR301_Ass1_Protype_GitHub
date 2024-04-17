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

    public TMP_Text currentCollectablesUI;
    public int collectableNum = 0;

    public Repulsion_Cube RC;

    public Canvas keypadCanvas;
    public FPS_Controller FPSC;

    // Reference to the FMOD Studio Event Emitter component
    private FMODUnity.StudioEventEmitter eventEmitter;

    // Start is called before the first frame update
    void Start()
    {
        Item1.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            UnequipObject();
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

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
                Collectable = hit.transform.gameObject;
                collectableNum ++;
                currentCollectablesUI.text = collectableNum.ToString();
                Collectable.SetActive(false);

                if (collectableNum == 4)
                {
                    doc1.DoorOpen2();
                }
                if (collectableNum == 7)
                {
                    doc2.DoorOpen2();
                }
            }
            else if (target != null && hit.transform.name == "button1" )
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
            else if (hit.transform.name == "keypad1")
            {
                FPSC.canMove = false;
                FPSC.canZoom = false;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                keypadCanvas.gameObject.SetActive(true);
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
        PlayerTransform.DetachChildren();

        //repulsives start here
        RC.Repulse();
        Item1.SetActive(false);
    }
}