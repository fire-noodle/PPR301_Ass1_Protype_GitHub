using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Item1;
    public GameObject Collectable;
    public Camera Camera;
    public float range = 2f;
    public float open = 100f;

    public float throwForce = 5f;
    public Vector3 throwDirection = Vector3.forward;
    public bool canThrow = false;

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
            }
            else if (target != null && hit.transform.CompareTag("collectable"))
            {
                Collectable = hit.transform.gameObject;
                Collectable.SetActive(false);
            }
            else if (target != null && hit.transform.name == "button1" )
            {
                //do button thing
                Collectable.SetActive(false);
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
}