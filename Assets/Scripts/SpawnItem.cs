using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RenderRay;
using static MenuItems;

public class SpawnItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Grabbable") != null) {
        #if UNITY_EDITOR
            UnityEditorInternal.InternalEditorUtility.AddTag("Grabbable");
        #endif
        }
    }

    // Update is called once per frame
    void Update()
    {

        bool rightTriggerDown = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);
        
        if (rightTriggerDown && MenuItems.chosenObject != null)
        {
            // If the ray hits, spawn the item at the hit point
            Vector3 spawnPoint = new Vector3(rayEndPosition.x, rayEndPosition.y + 1.0f, rayEndPosition.z);
            GameObject inst = Instantiate(chosenObject, spawnPoint, Quaternion.identity);
            Rigidbody rb = inst.AddComponent<Rigidbody>();
            BoxCollider bc = inst.AddComponent<BoxCollider>();
            inst.tag = "Grabbable";

            bc.isTrigger = false;
            bc.size = new Vector3(inst.GetComponent<Renderer>().bounds.size.x, inst.GetComponent<Renderer>().bounds.size.y, inst.GetComponent<Renderer>().bounds.size.z);
            rb.useGravity = true;
            rb.mass = 1.0f;
        }

    }
}
