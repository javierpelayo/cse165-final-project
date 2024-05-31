using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrabMechanic : MonoBehaviour
{
    private GameObject heldObject = null;
    private CustomHandCollider handCollider;

    void Start()
    {
        handCollider = GetComponent<CustomHandCollider>();
    }

    void Update()
    {
        // Check for grab input
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) || OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            if (handCollider.currentGrabbableObject != null)
            {
                GrabObject(handCollider.currentGrabbableObject);
            }
        }
        
        // Check for release input
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch) || OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
        {
            if (heldObject != null)
            {
                ReleaseObject();
            }
        }
    }

    void GrabObject(GameObject obj)
    {
        // Parent it to the hand anchor
        heldObject = obj;
        heldObject.transform.SetParent(transform);
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.transform.localRotation = Quaternion.identity;

        // Disable physics while holding the object
        var rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    void ReleaseObject()
    {
        // Re-enable physics on release
        var rb = heldObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.velocity = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch); // Apply velocity based on controller movement
        }
        
        // Unparent the object
        heldObject.transform.SetParent(null);
        heldObject = null;
    }
}
