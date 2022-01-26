using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractable : XRBaseInteractable
{
    [SerializeField] private CharacterController character;
    private bool isAlreadySelected = false;

    private void Update()
    {
        if (character.transform.position.y < 0.4f)
        {
            isAlreadySelected = false;
        }
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        if (isAlreadySelected == false)
        {
            character.Move(transform.rotation * new Vector3(0, 0.4f, 0));
        }
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
            isAlreadySelected = true;
    }

}
