using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timertxt;
    public float timer = 0.0f;
    private bool isTimer = false;
    [SerializeField] private GameObject enterTrigger;
    [SerializeField] private GameObject exitTrigger;

    // Update is called once per frame
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
        if (collider.gameObject == enterTrigger)
        {
            isTimer = true;
            Debug.Log("ENTERED TRIGGER");
        } else if (collider.gameObject == exitTrigger)
        {
            isTimer = false;
            Debug.Log("EXITED TRIGGER");
        }
    }

}
