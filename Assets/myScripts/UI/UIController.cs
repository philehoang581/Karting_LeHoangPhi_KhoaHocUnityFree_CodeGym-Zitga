using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Button uiShopBtn;
    public Button uiMapBtn;
    public Button uiChoseBtn;
    public Button playBtn;
    public TMP_Text text;
    

    private int idScene;


    public GameObject uiShopGameObject;
    public GameObject uiChoseCarGameObject;
    public GameObject uiMapGameObject;
    public GameObject uiLoginGameObject;
    public GameObject uiMainMenuObject;

    [SerializeField]
    private GameObject player;

    private void Awake()
    {
        player.SetActive(false);
        //Load Player
        //player = Resources.Load<GameObject>("CarModel/Ca-2");

        //Khoi toi gia tri mac dinh cho scene =1
        idScene = 1;

        instance = this;
        uiShopBtn.onClick.AddListener(OnOpenShop);
        uiMapBtn.onClick.AddListener(OnOpenMap);
        uiChoseBtn.onClick.AddListener(OnOpenChoseCar);
        playBtn.onClick.AddListener(LoadLevel);

        

        uiLoginGameObject.SetActive(true);
        uiMainMenuObject.SetActive(false);
    }

    private void Start()
    {
        uiShopGameObject.SetActive(false);
        uiMapGameObject.SetActive(false);
        uiChoseCarGameObject.SetActive(false);

        

    }
    private void OnEnable()
    {
        //Lang nghe su kien tu UIMapPopup
        //UIMapPopup._instance.updateMap.AddListener(UpdateMap);
    }
    private void OnDisable()
    {
        //Lang nghe su kien tu UIMapPopup
        //UIMapPopup._instance.updateMap.RemoveListener(UpdateMap);
    }
    public void OnMainMenuGame()
    {
        uiMainMenuObject.SetActive(true);
        //player.SetActive(true);
    }
    private void OnOpenShop()
    {
        //player.SetActive(false);
        uiShopGameObject.SetActive(true);
    }
    private void OnOpenMap()
    {
        //player.SetActive(false);
        uiMapGameObject.SetActive(true);
    }
    private void OnOpenChoseCar()
    {
        //player.SetActive(true);
        uiChoseCarGameObject.SetActive(true);
    }
    

    
    //Cap nhat idMap tu bo phat su kien UIMap
    public void UpdateMap(int idMap)
    {
        idScene = idMap;
        Debug.Log($"idMap duoc cap nhat tu UIMapPopup: {idScene}");
    }

    //Update level tu UIMapPopup
    private void LoadLevel()
    {
        SceneManager.LoadScene("Level" + idScene);
        Debug.Log($"Button play with idScene: {idScene}");
    }


    

    public void SetPlayerState(bool isActive)
    {
        EventManager.EmitEventData(EventName.TRIGGER_PRESENTER, isActive);
    }
}
