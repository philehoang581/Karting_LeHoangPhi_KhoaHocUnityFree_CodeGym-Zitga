using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Score : Singleton<Score>
{
    [SerializeField]
    private static Text textScore;

    private static Score _intance;
    public Score Intance => _intance;

    private void Awake()
    {
        _intance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        textScore.text = "Score: 100";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
