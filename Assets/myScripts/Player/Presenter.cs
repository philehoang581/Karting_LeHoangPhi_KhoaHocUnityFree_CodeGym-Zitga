using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TigerForge;
using UnityEngine.Events;

public class Presenter : MonoBehaviour
{
    public static Presenter _instance;
   

    private GameObject prefabPlayer;
    private GameObject player;

    private const string PLAYER_KEY = "KEY";


    [SerializeField]
    private int playerIndex;
    public GameObject[] playerList;

    #region --- EventManager Chu su dung ---
    /*
    private void OnEnable()
    {
        EventManager.StartListening(EventName.TRIGGER_PRESENTER, OnTrigger);
    }

    private void OnTrigger()
    {
        var isActive = EventManager.GetBool(EventName.TRIGGER_PRESENTER);

       // SetPlayerState(isActive);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventName.TRIGGER_PRESENTER, OnTrigger);
    }
    */
    #endregion

    private void Awake()
    {
        _instance = this;

        #region --- Luu Du lieu nguoi dung, chua su dung ----
        //khoi tao gia tri mat dinh playerIndex =1
        // playerIndex = 1;
        //SetCar(1);
        if (PlayerPrefs.HasKey(PLAYER_KEY) == false)
        {
            //RandomPlayer();
        }
        else
        {
            //playerIndex = PlayerPrefs.GetInt(PLAYER_KEY);
        }
        if (PlayerPrefs.HasKey(PLAYER_KEY) == false)
        {
            //RandomPlayer();
        }
        else
        {
            //playerIndex = PlayerPrefs.GetInt(PLAYER_KEY);
        }
        #endregion

        //Lay gia tri car tu UI Choose Car
        //UIChoseCar._instance.setCar.AddListener(SetCar);
        if (UIChoseCar._instance == null)
        {
            Debug.Log("Chua co UI Choose Car.... !!!");

        }
        else
        {
            UIChoseCar._instance.setCar.AddListener(SetCar);
            Debug.Log("Da gan su kien Choose Car.... !!!");
        }

    }
    

    private void Start()
    {
        if (UIChoseCar._instance == null)
        {
            Debug.Log("UI Choose Car khong gui ID den Presenter.... !!!");
            playerIndex = 1;

        }
        LoadPlayer();
        
    }

    //Nhan id car tu UIChoseCar gui qua
    private void SetCar(int _idCar)
    {
        playerIndex = _idCar;
        Debug.Log($"Prencenter get ID Car Form UI Choose Car: {playerIndex}");
    }


    private void LoadPlayer()
    {
        var path = "PrefabCar/Car";
        prefabPlayer = Resources.Load<GameObject>(path + playerIndex);
        Debug.Log($"Path:  {path + playerIndex}");

        player = GameObject.Instantiate(prefabPlayer, transform);
        player.transform.localPosition = Vector3.zero;
       
    }
    



    /* Minh Hoa them set nhieu keu du lieu khac nhau
    private void SavePlayerPosition()
    {
        var position = JsonUtility.ToJson(player.transform.position);
        PlayerPrefs.SetString(PLAYER_KEY, position);
        JsonUtility.FromJson<Vector3>(position);
    }
    */
    
    
}
