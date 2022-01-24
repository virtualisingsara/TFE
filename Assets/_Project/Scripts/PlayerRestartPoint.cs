using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRestartPoint : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;
    [SerializeField] private GameObject enemy3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            transform.position = startPoint.position;
            transform.rotation = startPoint.rotation;
            enemy1.transform.position = new Vector3(21, 2, -17);
            enemy1.transform.position = new Vector3(19, 2, -12);
            enemy1.transform.position = new Vector3(24, 2, -17);
        }
    }
}
