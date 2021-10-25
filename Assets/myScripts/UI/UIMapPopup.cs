using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class UIMapPopup : MonoBehaviour
{
    

    [SerializeField]
    private Button level1Btn;
    [SerializeField]
    private Button level2Btn;
    [SerializeField]
    private Button closeBtn;

    public Animator animator;

    private int idMap;

    public static UIMapPopup _instance;
    public UnityEvent<int> updateMap;

    private void Start()
    {
        _instance = this;

        level1Btn.onClick.AddListener(AddLevel1);
        level2Btn.onClick.AddListener(AddLevel2);

        closeBtn.onClick.AddListener(OnHideMap);

    }

    public void UpdateMap(int _idMap)
    {
        //updateMap?.Invoke(_idMap);
       
    }
    private void AddLevel1()
    {
        //Goi ham UpdateMap tu UIController
        UIController.instance.UpdateMap(1);
        UpdateMap(1);
        //Debug.Log("Level 1 ........!");
    }
    private void AddLevel2()
    {
        UIController.instance.UpdateMap(2);
        UpdateMap(2);
        //Debug.Log("Level 2 ........!");
    }

    public void OnHideMap()
    {
        //animator.SetBool("outShop",true);
        animator.Play("outMap");
        

        Debug.Log("On Hide Map..........!!!");
    }

    public void OnHideMapEvent()
    {
        //animator.SetBool("outShop",true);
        
        UIController.instance.uiMapGameObject.SetActive(false);

        Debug.Log("On Hide Map Event..........!!!");
    }
    
}
