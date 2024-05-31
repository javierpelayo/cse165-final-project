using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SelectItem;

public class RotateItem : MonoBehaviour
{
    public MoveItem moveItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectItem.selectedItem != null)
        {

            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                SelectItem.selectedItem.transform.Rotate(0, 2, 0);
            } else if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
            {
                SelectItem.selectedItem.transform.Rotate(2, 0, 0);
            }
            else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                SelectItem.selectedItem.transform.Rotate(0, 0, 2);
            }
        }
    }
}
