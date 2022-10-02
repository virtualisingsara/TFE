using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    public float rotationsPerMinute = 10f;
    public void Update()
    {
        transform.Rotate(0, 6 * rotationsPerMinute * Time.deltaTime, 0);
    }
}