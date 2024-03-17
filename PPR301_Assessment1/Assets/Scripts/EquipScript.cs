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

    public Cube_Spawner cs;
    public Door_Open_Conditional doc1;
    public Door_Open_Conditional doc2;

    public TMP_Text currentCollectablesUI;
    public int collectableNum = 0;

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
            if (target != null && (hit.transform.CompareTag("equippable") || hit.transform.CompareTag("equippable_pressable")))
            {
                Item1 = hit.transform.gameObject;
                EquipObject();

                StartCoroutine(CubeTimer());
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
                    BigAssCube.SetActive(false);
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
                cs.Tutorial_Cube();
            }
            else if (target != null && hit.transform.name == "button4")
            {
                cs.Tutorial_Cube2();
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
}