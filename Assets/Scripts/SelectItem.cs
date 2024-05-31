using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static RenderRay;
using static ScaleItem;

public class SelectItem : MonoBehaviour
{

    public Material highlightMaterial;
    public static Material previousMaterial;
    public MenuItems menuItems;

    public static GameObject selectedItem;
    public ScaleItem scaleItem;
    // Start is called before the first frame update
    void Start()
    {
        selectedItem = null;
    }

    // Update is called once per frame
    void Update()
    {
        bool rightGripDown = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);

        if (RenderRay.rayHitsCollider && rightGripDown) {
            GameObject objectCollided = RenderRay.isectInfo.collider.gameObject;

            //bool instanceOfPrefab1 = PrefabUtility.GetPrefabInstanceHandle(objectCollided) == PrefabUtility.GetPrefabInstanceHandle(menuItems.itemPrefab1);
            //bool instanceOfPrefab2 = PrefabUtility.GetPrefabInstanceHandle(objectCollided) == PrefabUtility.GetPrefabInstanceHandle(menuItems.itemPrefab2);

            if (objectCollided.tag == "Grabbable" && selectedItem == null)
            {
                Debug.Log("Item Selected!");
                selectedItem = RenderRay.isectInfo.collider.gameObject;
                ScaleItem.startPosLeft = scaleItem.leftController.transform.position;
                ScaleItem.startPosRight = scaleItem.rightController.transform.position;
                ScaleItem.startDistanceBetween = (startPosLeft - startPosRight).magnitude;
                HighlightItem();
            }
        }        

    }
    public static void UnhighlightItem()
    {
        if (selectedItem != null)
        {
            Renderer r = selectedItem.GetComponent<Renderer>();
            if (r != null && previousMaterial != null)
            {
                r.material = previousMaterial;
            }
        }

    }


    void HighlightItem()
    {
        Renderer r = selectedItem.GetComponent<Renderer>();
        if (r != null)
        {
            previousMaterial = r.material;
            r.material = highlightMaterial;
        }
    }
}
