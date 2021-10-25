using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public static GameManager _instance;
    public UnityEvent<int> updateScore;

    [Header("Player")]
    private GameObject defaultCarPosition;

    /*
    [Header("Text Score")]
    [SerializeField]
    public Text _textScore;
    //public TextMeshPro _textScore;
    */


    private int _score;
   
    
    private GameObject player;


    private void Awake()
    {
        _instance = this;

    }
    private void Start()
    {
        
       
    }
    public void CollectItem(int score)
    {
        this._score += score;
        updateScore?.Invoke(score);

        //_textScore.text = "Score: "+this._score.ToString();
    }

    

    public void AddScore(int score)
    { 
    }
}
