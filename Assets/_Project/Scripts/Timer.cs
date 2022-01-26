using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timertxt;
    [SerializeField] private Prefs prefs;
    public float timer = 0.0f;
    private bool isTimer = false;
    [SerializeField] private GameObject enterTrigger;
    [SerializeField] private GameObject exitTrigger;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject trophy;

    [SerializeField] private GameObject _enemy1;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private GameObject _enemy3;

    [SerializeField] private int game;

     void Start()
    {
        prefs = FindObjectOfType<Prefs>();
    }

    void Update()
    {
        if (isTimer)
        {
            timer += Time.deltaTime;
            DisplayTime();
        }
    }

    void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timertxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == enterTrigger && door.activeSelf)
        {
            isTimer = true;
            if (_enemy1 && _enemy2 && _enemy3)
            {
                _enemy1.SetActive(true);
                _enemy2.SetActive(true);
                _enemy3.SetActive(true);
            }
            Debug.Log("ENTERED TRIGGER");
        } else if (collider.gameObject == exitTrigger && !door.activeSelf)
        {
            isTimer = false;
            trophy.SetActive(true);    

            switch (game)
            {
                case 1:
                    if (timer < PlayerPrefs.GetFloat("Score1"))
                    {
                        PlayerPrefs.SetFloat("Score1", timer);
                        prefs.LoadPrefs();
                    }     
                    break;
                case 2:
                    if (timer < PlayerPrefs.GetFloat("Score2"))
                    {
                        PlayerPrefs.SetFloat("Score2", timer);
                        prefs.LoadPrefs();
                    }
                    break;
                case 3:
                    if (timer < PlayerPrefs.GetFloat("Score3"))
                    {
                        PlayerPrefs.SetFloat("Score3", timer);
                        prefs.LoadPrefs();
                    }
                    break;
                default:
                    break;
            }

            Debug.Log("EXITED TRIGGER");
        }
    }

}
