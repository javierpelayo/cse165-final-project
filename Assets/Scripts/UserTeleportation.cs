using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserTeleportation : MonoBehaviour
{

    public LayerMask teleportationAreasMask; // Set this mask to the layers that are teleportable
    public Transform rightHandTransform; // Assign the transform of the right hand controller
    public Transform cameraRig; // Assign your VR Camera Rig's Transform here


    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Jump")) 
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            RaycastForTeleportationArea();
        }
    }

    void RaycastForTeleportationArea()
    {
        RaycastHit hit;
        if (Physics.Raycast(rightHandTransform.position, rightHandTransform.forward, out hit, Mathf.Infinity, teleportationAreasMask))
        {
            // Perform the teleportation if a valid teleportable area is hit
            PerformTeleportation(hit.point);
        }
    }

    void PerformTeleportation(Vector3 targetPoint)
    {
        // Adjust the y position of the targetPoint to the current y position of the cameraRig
        // to maintain the current height after teleporting.
        targetPoint.y = cameraRig.position.y;

        // Teleport the camera rig to the target position.
        cameraRig.position = targetPoint;
    }
}

