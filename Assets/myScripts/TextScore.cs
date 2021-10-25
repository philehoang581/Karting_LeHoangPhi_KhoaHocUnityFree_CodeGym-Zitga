using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Text))]
public class TextScore : MonoBehaviour
{
    private Text _textScore;
    private int score;

    //Event fun  

    private void Awake()
    {
        _textScore = GetComponent<Text>();
    }
    
    void Start()
    {
       // Item._instance.updateScore.AddListener(UpdateScore);
        UpdateScore(0);
        //Item._instance.updateScore.AddListener(UpdateScore);

    }
    private void OnEnable()
    {
        //GameManager.Instance.updateScore.AddListener(UpdateScore);
        //Item._instance.updateScore.AddListener(UpdateScore);

    }
    private void OnDisable()
    {
        //GameManager.Instance.updateScore.RemoveListener(UpdateScore);
    }
    private void UpdateScore(int _score)
    {
        score += _score;
        _textScore.text = $"Score: {score}";
    }
      
}
