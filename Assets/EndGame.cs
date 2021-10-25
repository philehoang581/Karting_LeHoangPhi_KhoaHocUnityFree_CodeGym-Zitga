using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIPlayManager.instance.EndGame();
            //GameManager.Instance.AddScore(_score);
            //Destroy(gameObject);
            Debug.Log("You hit End Game...!!!");
        }
    }
}
