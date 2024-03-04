using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipScript : MonoBehaviour
{
    public Transform PlayerTransform;
    public GameObject Item;
    public Camera Camera;
    public float range = 2f;
    public float open = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Item.GetComponent<Rigidbody>().isKinematic = true;
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
            if (target != null)
            {
                EquipObject();
            }
        }
    }

    void UnequipObject()
    {
        PlayerTransform.DetachChildren();
        Item.transform.eulerAngles = new Vector3(Item.transform.eulerAngles.x, Item.transform.eulerAngles.y, Item.transform.eulerAngles.z);
        Item.GetComponent<Rigidbody>().isKinematic = false;
    }

    void EquipObject()
    {
        Item.GetComponent<Rigidbody>().isKinematic = true;
        Item.transform.position = PlayerTransform.transform.position;
        Item.transform.rotation = PlayerTransform.transform.rotation;
        Item.transform.SetParent(PlayerTransform);
    }
}