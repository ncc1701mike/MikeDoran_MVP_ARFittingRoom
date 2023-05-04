using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGestures : MonoBehaviour
{
    [SerializeField] private OVRHand ovrHand;
    [SerializeField] private OVRHand.Hand handType = OVRHand.Hand.None;

    private void OnEnable()
    {
        Debug.Log(ovrHand == null ? "ovrHand must be set in the inspector" : "ovrHand has been set in the inspector");
    }

    private void Update()
    {
        if (ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
        {
            Debug.Log($"Hand ({handType}) Pinch Strength ({ovrHand.GetFingerPinchStrength(OVRHand.HandFinger.Index)})");
        }
    }
}

