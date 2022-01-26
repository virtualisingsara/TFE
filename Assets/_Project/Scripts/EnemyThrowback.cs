using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowback : MonoBehaviour
{
        private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
        {
            transform.position -= (Vector3.back *2);
        }
    }
}
