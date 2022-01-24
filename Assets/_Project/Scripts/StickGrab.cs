using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StickGrab : XRGrabInteractable
{
    public Transform hand;
    public Transform secondHand;
    private Vector3 positionOffset;
    private Quaternion rotationOffset;
    private Quaternion secondRotationOffset;

    void Start()
    {
        positionOffset = hand.InverseTransformPoint(transform.position);
        rotationOffset = Quaternion.Inverse(hand.rotation) * transform.rotation;
        secondRotationOffset = Quaternion.Inverse(Quaternion.LookRotation(secondHand.position - hand.position)) * hand.rotation;
    }

    void Update()
    {
        transform.position = hand.TransformPoint(positionOffset);
        transform.rotation = hand.rotation * rotationOffset;
        hand.rotation = Quaternion.LookRotation(secondHand.position - hand.position) * secondRotationOffset;
    }
}
