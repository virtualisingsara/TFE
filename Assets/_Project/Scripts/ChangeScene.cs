using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void Start()
    {
        StartCoroutine(GoToMainScene());
    }

    IEnumerator GoToMainScene()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Main");
    }

}

