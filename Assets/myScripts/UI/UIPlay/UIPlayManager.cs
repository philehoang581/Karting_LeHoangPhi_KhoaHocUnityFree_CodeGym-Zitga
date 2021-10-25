using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UIPlayManager : MonoBehaviour
{
    public static UIPlayManager instance;
    [SerializeField]
    private GameObject uiMain;
    [SerializeField]
    private GameObject uiEndGame;

    //[SerializeField]
    //private GameObject player;
    private Vector3 tempPositionCar;


    [SerializeField]
    private Button playBtn;
    [SerializeField]
    private Button homeBtn;


    [SerializeField]
    private int idScene;



    private void Awake()
    {
        instance = this;
        uiEndGame.SetActive(false);

        homeBtn.onClick.AddListener(LoadHomeScene);
        playBtn.onClick.AddListener(PlayAgain);

    }

    private void LoadHomeScene()
    {
        SceneManager.LoadScene("MainMenu1");
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene("Level1"+idScene);
    }


    public void SetPositionPlayer()
    {
        
       // player.transform.position = position;
    }

    public void EndGame()
    {
        uiEndGame.SetActive(true);
    }
}
