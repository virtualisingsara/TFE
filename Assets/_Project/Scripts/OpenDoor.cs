using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject _enemy1;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private GameObject _enemy3;
    [SerializeField] private GameObject _weapon;

    private void OnTriggerEnter(Collider other)
    {
        door.SetActive(false);
        if (_enemy1 && _enemy2 && _enemy3)
        {
            Destroy(_enemy1);
            Destroy(_enemy2);
            Destroy(_enemy3);
        }

        if (_weapon)
        {
            Destroy(_weapon);
        }

    }
}
