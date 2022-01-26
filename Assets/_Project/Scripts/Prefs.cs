using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Prefs : MonoBehaviour
{
    [SerializeField] private TMP_Text score1;
    [SerializeField] private TMP_Text score2;
    [SerializeField] private TMP_Text score3;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Score1"))
        {
            PlayerPrefs.SetFloat("Score1", 3599f);
        }

        if (!PlayerPrefs.HasKey("Score2"))
        {
            PlayerPrefs.SetFloat("Score2", 3599f);
        }

        if (!PlayerPrefs.HasKey("Score3"))
        {
            PlayerPrefs.SetFloat("Score3", 3599f);
        }

        LoadPrefs();
        
    }

    public void LoadPrefs()
    {
        float timer1 = PlayerPrefs.GetFloat("Score1");
        int minutes1 = Mathf.FloorToInt(timer1 / 60.0f);
        int seconds1 = Mathf.FloorToInt(timer1 - minutes1 * 60);
        score1.text = string.Format("{0:00}:{1:00}", minutes1, seconds1);

        float timer2 = PlayerPrefs.GetFloat("Score2");
        int minutes2 = Mathf.FloorToInt(timer2 / 60.0f);
        int seconds2 = Mathf.FloorToInt(timer2 - minutes2 * 60);
        score2.text = string.Format("{0:00}:{1:00}", minutes2, seconds2);

        float timer3 = PlayerPrefs.GetFloat("Score3");
        int minutes3 = Mathf.FloorToInt(timer3 / 60.0f);
        int seconds3 = Mathf.FloorToInt(timer3 - minutes3 * 60);
        score3.text = string.Format("{0:00}:{1:00}", minutes3, seconds3);
    }
}
