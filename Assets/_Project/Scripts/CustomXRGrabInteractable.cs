using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomXRGrabInteractable : XRGrabInteractable
{
    [SerializeField] private Transform character;
    [SerializeField] private Transform startPoint;

    private bool tokenFirstInteraction = true;
    private Vector3 tokenPosition;

    public void Start()
    {
        Vector3 tokenPosition = transform.position;
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        bool isDirectInteractor = interactor is XRDirectInteractor;
        if (isDirectInteractor)
        {
            if (tokenFirstInteraction == true)
            {
                character.transform.position = startPoint.position;
                this.transform.position = tokenPosition;
                tokenFirstInteraction = false;
            }
            else if (tokenFirstInteraction == false)
            {
                this.gameObject.SetActive(false);
            }
        }

    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);

        bool isDirectInteractor = interactor is XRDirectInteractor;
        if (isDirectInteractor)
        {

        }

    }

    protected override void OnActivate(XRBaseInteractor interactor)
    {
        base.OnActivate(interactor);
    }

}
