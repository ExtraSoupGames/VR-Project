using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.XR.Interaction.Toolkit.XRInteractionUpdateOrder;

public class FixedGrabInteractable : XRBaseInteractable
{
    private Quaternion initialRotation;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        // Lock the object's position and rotation when grabbed
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
        initialRotation = transform.rotation;

    }
    public override void ProcessInteractable(UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        // Check if the object is currently grabbed and lock rotation
        if (isSelected)
        {
            transform.rotation = initialRotation;
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        // Restore original Rigidbody behavior after releasing
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}