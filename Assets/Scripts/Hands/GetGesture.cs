using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Hands;

public class GetGesture : MonoBehaviour
{
    public XRHandSubsystem handSubsystem;
    public static bool rightHandPinching;
    public static bool rightHandGrasping;
    public static bool leftHandPinching;
    public static bool leftHandGrasping;

    void Start()
    {
        // Find and initialize the hand subsystem
        var descriptors = new List<XRHandSubsystemDescriptor>();
        SubsystemManager.GetSubsystemDescriptors(descriptors);
        
        if (handSubsystem != null) {
            handSubsystem.Start();
        } else {
            Debug.LogError("No hand subsystem found.");
        }
    }

    void Update()
    {
        if (handSubsystem == null)
            return;

        XRHand leftHand = handSubsystem.leftHand;
        if (leftHand != null) {
            leftHandPinching = IsPinching(leftHand);
            leftHandGrasping = IsGrasping(leftHand);
        }

        XRHand rightHand = handSubsystem.rightHand;
        if (rightHand != null) {
            rightHandPinching = IsPinching(rightHand);
            rightHandGrasping = IsGrasping(rightHand);
        }
    }

    private bool IsPinching(XRHand hand)
    {
        // Use hand data to determine if a pinch gesture is occurring
        // You may need to adjust this based on the specific implementation and finger joint tracking
        
        XRHandJoint thumbTip = hand.GetJoint(XRHandJointID.ThumbTip);
        XRHandJoint indexTip = hand.GetJoint(XRHandJointID.IndexTip);



        if (thumbTip != null && indexTip != null) {
            thumbTip.TryGetPose(out Pose thumbPos);
            indexTip.TryGetPose(out Pose indexPos);

            float pinchDistance = Vector3.Distance(thumbPos.position, indexPos.position);
            return pinchDistance < 0.03f; // Adjust the threshold based on your needs
        }
        return false;
    }

    private bool IsGrasping(XRHand hand)
    {
        // Use hand data to determine if a grasp gesture is occurring
        // Check if all the finger tips are close to the palm
        
        XRHandJoint palm = hand.GetJoint(XRHandJointID.Palm);
        XRHandJoint thumbTip = hand.GetJoint(XRHandJointID.ThumbTip);
        XRHandJoint indexTip = hand.GetJoint(XRHandJointID.IndexTip);
        XRHandJoint middleTip = hand.GetJoint(XRHandJointID.MiddleTip);
        XRHandJoint ringTip = hand.GetJoint(XRHandJointID.RingTip);
        XRHandJoint littleTip = hand.GetJoint(XRHandJointID.LittleTip);

        if (palm != null && thumbTip != null && indexTip != null && middleTip != null && ringTip != null && littleTip != null)
        {

            palm.TryGetPose(out Pose palmPos);
            thumbTip.TryGetPose(out Pose thumbPos);
            indexTip.TryGetPose(out Pose indexPos);
            middleTip.TryGetPose(out Pose middlePos);
            ringTip.TryGetPose(out Pose ringPos);
            littleTip.TryGetPose(out Pose littlePos);

            float thumbDistance = Vector3.Distance(thumbPos.position, palmPos.position);
            float indexDistance = Vector3.Distance(indexPos.position, palmPos.position);
            float middleDistance = Vector3.Distance(middlePos.position, palmPos.position);
            float ringDistance = Vector3.Distance(ringPos.position, palmPos.position);
            float littleDistance = Vector3.Distance(littlePos.position, palmPos.position);

            // Adjust the threshold based on your needs
            float graspThreshold = 0.05f;

            return thumbDistance < graspThreshold &&
                   indexDistance < graspThreshold &&
                   middleDistance < graspThreshold &&
                   ringDistance < graspThreshold &&
                   littleDistance < graspThreshold;
        }
        return false;
    }




}





