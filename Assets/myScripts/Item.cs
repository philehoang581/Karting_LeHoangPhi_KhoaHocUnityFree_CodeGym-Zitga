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


    public AudioSource colecAudio;
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
            UIPlayManager.instance.UpdateScore(_score);
            colecAudio.Play();

            CollectItem(_score);

            UpdateScoreEndGame();


        }

        

        tempPositionCar = gameObject.transform.position;
    }

    IEnumerator UpdateScoreEndGame()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
