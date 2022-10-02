using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using DG.Tweening;
//using UnityEngine.Video;

public class PlayerRestartPoint : MonoBehaviour
{
    public Volume volume;
    private Vignette vignette;
    [SerializeField] private Volume fadeToBlackVolume;
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
    //GameObject camera;
    //VideoPlayer videoPlayer;

    bool token1FirstInteraction = true;
    bool token2FirstInteraction = true;
    bool token3FirstInteraction = true;
    bool token4FirstInteraction = true;
    bool token5FirstInteraction = true;
    bool token6FirstInteraction = true;

    bool hasToken1 = false;
    bool hasToken2 = false;
    bool hasToken3 = false;
    bool hasToken4 = false;
    bool hasToken5 = false;
    bool hasToken6 = false;

    private void FadeToBlack()
    {
        DOTween.To(() => fadeToBlackVolume.weight, x => fadeToBlackVolume.weight = x, 1f, 1).OnComplete(() =>
        {
            DOTween.To(() => fadeToBlackVolume.weight, x => fadeToBlackVolume.weight = x, 0f, 1);
        });
    }

    public void Start()
    {
        VolumeProfile profile = volume.sharedProfile;
        tokenAudio = GetComponent<AudioSource>();
        audioManager.GetComponent<AudioSource>();
        audioData = audioManager.GetComponent<AudioSource>();
        //camera = GameObject.Find("Main Camera");
        //videoPlayer = camera.GetComponent<VideoPlayer>();
        //videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
        //videoPlayer.targetCameraAlpha = 0;
    }

    public void Update()
    {
        if (hasToken1 == true && hasToken2 == true && hasToken3 == true && hasToken4 == true && hasToken5 == true && hasToken6 == true)
        {
            gameObject.transform.position = startPoint.position;
            gameObject.transform.rotation = startPoint.rotation;
            StartCoroutine(GoToEndingScene());
        }
    }

    IEnumerator playerRestart()
    {
        moveProvider.enabled = false;
        //videoPlayer.Play();
        FadeToBlack();
        yield return new WaitForSeconds(0.1f);
        enemy.transform.position = enemyStartPoint.position;
        enemy.transform.rotation = enemyStartPoint.rotation;
        gameObject.transform.position = startPoint.position;
        gameObject.transform.rotation = startPoint.rotation;
        yield return new WaitForSeconds(0.1f);
        moveProvider.enabled = true;
    }

    IEnumerator GoToEndingScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Ending");
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
            hasToken1 = true;
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
            hasToken2 = true;
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
            hasToken3 = true;
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
            hasToken4 = true;
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
            hasToken5 = true;
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
            hasToken6 = true;
        }
    }
}