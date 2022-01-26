using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour
{
    [SerializeField] private GameObject audioManager;
    AudioSource audioData;

    void Start()
    {
        audioManager.GetComponent<AudioSource>();
        audioData = audioManager.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        audioData.Play(0);
    }
}

