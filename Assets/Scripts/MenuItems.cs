using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItems : MonoBehaviour
{

    public GameObject itemPrefab1;
    public GameObject itemPrefab2;
    public static GameObject chosenObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool rightTriggerDown = OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger);

        if (RenderRay.rayHitsCollider && RenderRay.isectInfo.collider.gameObject == GameObject.Find("ButtonTool1") && rightTriggerDown) {
            chosenObject = itemPrefab1;
        } else if (RenderRay.rayHitsCollider && RenderRay.isectInfo.collider.gameObject == GameObject.Find("ButtonTool2") && rightTriggerDown) {
            chosenObject = itemPrefab2;
        } else {
            // If the ray does not hit, spawn the item at the maximum ray length
            //Instantiate(itemPrefab, transform.position + transform.forward * rayLength, Quaternion.identity);
        }
   
    }
}
