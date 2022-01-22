using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    [SerializeField] ParticleSystem effect;
    // Start is called before the first frame update
    void Start()
    {
        effect.Stop();
    }

    private void OnTriggerEnter()
    {
        if (GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Stop();
            effect.Stop();
        }
        else
        {
            GetComponent<AudioSource>().Play();
            effect.Play();
        }
    }

}
