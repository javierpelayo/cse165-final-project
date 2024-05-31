using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Hands;

public class HandTrackingManager : MonoBehaviour
{
    private XRHandSubsystem handSubsystem;

    public GameObject leftHandPrefab;
    public GameObject rightHandPrefab;

    private GameObject leftHandInstance;
    private GameObject rightHandInstance;

    void Start()
    {
        // Initialize the hand subsystem
        InitializeHandSubsystem();

        // Instantiate hand prefabs
        if (leftHandPrefab != null)
        {
            leftHandInstance = Instantiate(leftHandPrefab);
        }

        if (rightHandPrefab != null)
        {
            rightHandInstance = Instantiate(rightHandPrefab);
        }
    }

    void Update()
    {
        if (handSubsystem == null)
            return;

        // Update left hand
        var leftHand = handSubsystem.leftHand;
        if (leftHand != null && leftHandInstance != null)
        {
            UpdateHand(leftHand, leftHandInstance);
        }

        // Update right hand
        var rightHand = handSubsystem.rightHand;
        if (rightHand != null && rightHandInstance != null)
        {
            UpdateHand(rightHand, rightHandInstance);
        }
    }

    private void InitializeHandSubsystem()
    {
        // Find and initialize the hand subsystem
        var descriptors = new List<XRHandSubsystemDescriptor>();
        SubsystemManager.GetSubsystemDescriptors(descriptors);

        if (descriptors.Count > 0)
        {
            handSubsystem = descriptors[0].Create();
            if (handSubsystem != null)
            {
                handSubsystem.Start();
                Debug.Log("Hand subsystem started");
            }
        }
        else
        {
            Debug.LogError("No XRHandSubsystem found.");
        }
    }

    private void UpdateHand(XRHand hand, GameObject handInstance)
    {
        var wrist = hand.GetJoint(XRHandJointID.Wrist);
        if (wrist.TryGetPose(out Pose wristPose))
        {
            handInstance.transform.position = wristPose.position;
            handInstance.transform.rotation = wristPose.rotation;
        }

        // Optionally, update other joints of the handInstance
    }
}

