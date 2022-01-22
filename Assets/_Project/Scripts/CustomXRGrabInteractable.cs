using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomXRGrabInteractable : XRGrabInteractable
{
    AudioSource audioData;
    [SerializeField] private GameObject cat1;
    [SerializeField] private GameObject cat2;
    [SerializeField] private GameObject toy;
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    Vector3 initialPos = new Vector3(1.66f, 0.62f, 4.233f);
    Quaternion initialRot = new Quaternion(0, -0.537196338f, 0, 0.843457282f);

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        bool isDirectInteractor = interactor is XRDirectInteractor;
        if (isDirectInteractor)
        {

        }

    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);

        bool isDirectInteractor = interactor is XRDirectInteractor;
        if (isDirectInteractor)
        {

        }

        toy.transform.position = initialPos;
        toy.transform.rotation = initialRot;
    }

    protected override void OnActivate(XRBaseInteractor interactor)
    {
        base.OnActivate(interactor);

        audioData.Play(0);

        cat1.GetComponent<AudioSource>().Play();
        cat2.GetComponent<AudioSource>().Play();
    }

}
