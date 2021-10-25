using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Item : MonoBehaviour
{
    [SerializeField]
    private int _score;
    public static Item _instance;
    public UnityEvent<int> updateScore;



    private Vector3 tempPositionCar;


    public void CollectItem(int score)
    {
        //this._score += score;
        updateScore?.Invoke(score);

        //_textScore.text = "Score: "+this._score.ToString();
    }

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectItem(_score);
            //GameManager.Instance.CollectItem(_score);
            Destroy(gameObject);
        }

        

        tempPositionCar = gameObject.transform.position;
    }
}
