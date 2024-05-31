using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomHandCollider : MonoBehaviour
{
    public GameObject currentGrabbableObject = null;

    void OnTriggerEnter(Collider other)
    {
        // Check if the object is grabbable and not already being held
        if (other.CompareTag("Grabbable") && currentGrabbableObject == null)
        {
            currentGrabbableObject = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentGrabbableObject)
        {
            currentGrabbableObject = null;
        }
    }
}

