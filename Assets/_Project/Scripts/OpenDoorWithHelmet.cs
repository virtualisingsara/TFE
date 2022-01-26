using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenDoorWithHelmet : MonoBehaviour
{
    AudioSource rockAudio;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject rocks;
    [SerializeField] private GameObject _helmet;
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private GameObject audioManager;
    AudioSource audioData;

    void Start()
    {
        rockAudio = GetComponent<AudioSource>();
        audioManager.GetComponent<AudioSource>();
        audioData = audioManager.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        XRSocketInteractor socket = _helmet.GetComponent<XRSocketInteractor>();

        if (socket.hasSelection)
        {
            Debug.Log("HAS HELMET");
            door.SetActive(false);
            rocks.SetActive(false);
            audioData.Stop();
        }
        else if (!socket.hasSelection)
        {
            Debug.Log("NO HELMET");
            rockAudio.Play(0);
        }
    }
}
