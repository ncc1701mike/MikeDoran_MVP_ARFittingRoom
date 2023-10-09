using UnityEngine;
using OculusSampleFramework;

public class PinchGrabReticle : MonoBehaviour
{
    public OVRHand hand;
    public float reticleDistance = 2.0f;

    private void Update()
    {
        if (!hand)
        {
            hand = FindObjectOfType<OVRHand>();
        }

        if (hand)
        {
            transform.position = hand.transform.position + hand.PointerPose.forward * reticleDistance;
            transform.rotation = hand.PointerPose.rotation;
        }
    }
}
