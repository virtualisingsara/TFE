using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerRestartPoint : MonoBehaviour
{
    public Volume volume;
    private Vignette vignette;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform enemyStartPoint;
    [SerializeField] private Transform enemy;
    [SerializeField] private GameObject token1;
    [SerializeField] private GameObject token2;
    [SerializeField] private GameObject token3;
    [SerializeField] private GameObject token4;
    [SerializeField] private GameObject token5;
    [SerializeField] private GameObject token6;
    [SerializeField] private ActionBasedContinuousMoveProvider moveProvider;
    [SerializeField] private GameObject audioManager;
    AudioSource audioData;
    AudioSource tokenAudio;

    bool token1FirstInteraction = true;
    bool token2FirstInteraction = true;
    bool token3FirstInteraction = true;
    bool token4FirstInteraction = true;
    bool token5FirstInteraction = true;
    bool token6FirstInteraction = true;

    public void Start()
    {
        VolumeProfile profile = volume.sharedProfile;
        tokenAudio = GetComponent<AudioSource>();
        audioManager.GetComponent<AudioSource>();
        audioData = audioManager.GetComponent<AudioSource>();
    }

    IEnumerator playerRestart()
    {
        moveProvider.enabled = false;
        yield return new WaitForSeconds(0.1f);
        enemy.transform.position = enemyStartPoint.position;
        enemy.transform.rotation = enemyStartPoint.rotation;
        gameObject.transform.position = startPoint.position;
        gameObject.transform.rotation = startPoint.rotation;
        
        yield return new WaitForSeconds(0.1f);
        moveProvider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            StartCoroutine(playerRestart());
        }

        if (other.tag == "Token1" && token1FirstInteraction == true)
        {
            StartCoroutine(playerRestart());
            token1FirstInteraction = false;
        }
        else if (other.tag == "Token1" && token1FirstInteraction == false)
        {
            tokenAudio.Play(0);
            volume.profile.TryGet(out vignette);
            vignette.intensity.value -= 0.1f;
            token1.SetActive(false);
        }

        if (other.tag == "Token2" && token2FirstInteraction == true)
        {
            StartCoroutine(playerRestart());
            token2FirstInteraction = false;
        }
        else if (other.tag == "Token2" && token2FirstInteraction == false)
        {
            tokenAudio.Play(0);
            volume.profile.TryGet(out vignette);
            vignette.intensity.value -= 0.2f;
            token2.SetActive(false);
        }

        if (other.tag == "Token3" && token3FirstInteraction == true)
        {
            StartCoroutine(playerRestart());
            token3FirstInteraction = false;
        }
        else if (other.tag == "Token3" && token3FirstInteraction == false)
        {
            tokenAudio.Play(0);
            volume.profile.TryGet(out vignette);
            vignette.intensity.value -= 0.2f;
            token3.SetActive(false);
        }

        if (other.tag == "Token4" && token4FirstInteraction == true)
        {
            StartCoroutine(playerRestart());
            token4FirstInteraction = false;
        }
        else if (other.tag == "Token4" && token4FirstInteraction == false)
        {
            tokenAudio.Play(0);
            volume.profile.TryGet(out vignette);
            vignette.intensity.value -= 0.2f;
            token4.SetActive(false);
        }

        if (other.tag == "Token5" && token5FirstInteraction == true)
        {
            StartCoroutine(playerRestart());
            token5FirstInteraction = false;
        }
        else if (other.tag == "Token5" && token5FirstInteraction == false)
        {
            tokenAudio.Play(0);
            volume.profile.TryGet(out vignette);
            vignette.intensity.value -= 0.2f;
            token5.SetActive(false);
        }

        if (other.tag == "Token6" && token6FirstInteraction == true)
        {
            StartCoroutine(playerRestart());
            token6FirstInteraction = false;
        }
        else if (other.tag == "Token6" && token6FirstInteraction == false)
        {
            tokenAudio.Play(0);
            volume.profile.TryGet(out vignette);
            vignette.intensity.value -= 0.1f;
            token6.SetActive(false);
        }
    }
}