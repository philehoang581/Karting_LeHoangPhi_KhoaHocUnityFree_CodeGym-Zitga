using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TigerForge;

public class UIManager : Singleton<UIManager>
{
    public Animator uiMainAnimator;

    public GameObject uiRewardGameObject;
    public GameObject uiChapter;

    public Button btnShop;
    public Button Level;
    public Button mapBtn;

    


    private void Awake()
    {
        btnShop.onClick.AddListener(OnOpenShop);
        //Level.onClick.AddListener(OnOpenChapter);
        mapBtn.onClick.AddListener(OnOpenChapter);
    }

    

  
   

    private void OnOpenShop()
    {
        uiRewardGameObject.SetActive(true);
       // SetPlayerState(false);
        //EventManager buoi 10
    }

    private void OnOpenChapter()
    {
        uiChapter.SetActive(true);
        //SetPlayerState(false);

    }

   
}
