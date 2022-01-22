using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHider : MonoBehaviour
{
    [SerializeField] private List<XRBaseInteractor> interactors;
    //Para añadir el modelo manualmente desde el inspector
    //[SerializeField] private GameObject handVisual;

    private void OnEnable()
    {
        foreach (XRBaseInteractor interactor in interactors)
        {
            interactor.selectEntered.AddListener(HideHand);
            interactor.selectExited.AddListener(ShowHand);
        }
    }

    private void HideHand(SelectEnterEventArgs enterEvent)
    {
        //Para añadir el modelo manualmente desde el inspector
        //handVisual.SetActive(false);
        this.gameObject.SetActive(false);
    }

    private void ShowHand(SelectExitEventArgs exitEvent)
    {
        //Para añadir el modelo manualmente desde el inspector
        //handVisual.SetActive(true);
        this.gameObject.SetActive(true);
    }
}
