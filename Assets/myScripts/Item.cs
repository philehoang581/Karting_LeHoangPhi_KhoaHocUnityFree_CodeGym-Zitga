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

    public UnityEvent<Vector3> updateTempPosition;


    public AudioSource colecAudio;
    private Vector3 tempPositionCar;

    private void Awake()
    {
        _instance = this;
    }
    public void CollectItem(int score)
    {
        //this._score += score;
        updateScore?.Invoke(score);

        //_textScore.text = "Score: "+this._score.ToString();
    }


    public void UpdateTempPostionCar(Vector3 tempPostion)
    {
        //updateTempPosition?.Invoke(tempPositionCar);
        //Debug.Log($"Thu thap Item vi tri: {gameObject.transform.position}");
    }
    private void Start()
    {
        GetComponent<GameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIPlayManager.instance.UpdateScore(_score);
            //colecAudio.Play();

            CollectItem(_score);

            UpdateScoreEndGame();

            //gui su kien update vi tri xe khi nguoi choi thu thap item
            UpdateTempPostionCar(gameObject.transform.position);
            Destroy(gameObject);

        }

        

        tempPositionCar = gameObject.transform.position;
    }

    IEnumerator UpdateScoreEndGame()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
