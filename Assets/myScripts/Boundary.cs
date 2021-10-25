using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        UIPlayManager.instance.SetPositionPlayer();
    }
}
