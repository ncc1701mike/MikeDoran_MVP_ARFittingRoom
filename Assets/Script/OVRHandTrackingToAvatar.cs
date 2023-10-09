using UnityEngine;
using System.Collections.Generic;
using Oculus;

public class OVRHandTrackingToAvatar : MonoBehaviour
{
    public OVRHand leftHand;
    public OVRHand rightHand;
    public List<Transform> leftHandJoints;
    public List<Transform> rightHandJoints;

    private void Update()
    {
        UpdateHandJoints(leftHand, leftHandJoints);
        UpdateHandJoints(rightHand, rightHandJoints);
    }

    private void UpdateHandJoints(OVRHand hand, List<Transform> handJoints)
    {
        if (hand.IsTracked)
        {
            OVRSkeleton skeleton = hand.GetComponent<OVRSkeleton>();

            if (skeleton != null)
            {
                for (int i = 0; i < handJoints.Count && i < skeleton.Bones.Count; i++)
                {
                    OVRBone bone = skeleton.Bones[i];
                    handJoints[i].position = bone.Transform.position;
                    handJoints[i].rotation = bone.Transform.rotation;
                }
            }
        }
    }
}

