using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIChoseCar : MonoBehaviour
{
    public static UIChoseCar _instance;

    //Sự kiện cho button next/back ở UIShop và UIChooseCar nhận
    public UnityEvent<bool> updateCarChooseCar;

    //Su kien gia tri car id cho man choi (Scene Level1 và Scene Level2)
    public UnityEvent<int> setCar;

    private int idCar;

    

    #region !!!!!!!!!!!
    [SerializeField]
    private Button nextCarBtn;
    [SerializeField]
    private Button backCarBtn;
    [SerializeField]
    private Button closeBtn;

    public Animator animator;


    private GameObject carItem;
    private GameObject prefab;
    public GameObject positionCar;
    
    private void Awake()
    {
       
        _instance = this;
        idCar = 1;
       
    }
    private void Start()
    {
        

        nextCarBtn.onClick.AddListener(NextCar);
        backCarBtn.onClick.AddListener(BackCar);

        closeBtn.onClick.AddListener(OnHideChose);

    }

    private void NextCar()
    {
        if (idCar >= 3)
        {
            idCar = 1;
        }
        else
        {
            idCar += 1;

        }
        
        // Gui idCar den Prencenter trong GamePlay Level1, Level2
        SetCar(idCar);


        UpdateCarChooseCar(true);
        InitCar();
        
    }

    private void BackCar()
    {
        if (idCar <= 1)
        {
            idCar = 3;
        }
        else
        {
            idCar -= 1;
        }

        //Gui idCar den Prencenter trong GamePlay Level1, Level2
        SetCar(idCar);
        
        UpdateCarChooseCar(true);
        InitCar();
    }

    public void SetCar(int idCar)
    {
        setCar?.Invoke(idCar);
        DataManager.cardId = idCar;
        PlayerPrefs.SetInt("CarId", idCar); // lưu qua nhiều session, persistent storage
        DataManager2.Instance.cardId = idCar;
        Debug.Log($"Choose car dang phat su kien chon car ID: {idCar}");
    }
    private void InitCar()
    {
       
        prefab = Resources.Load<GameObject>($"CarModel/Car-{idCar}");
        carItem = Instantiate(prefab, positionCar.transform);
        
    }

    public void OnHideChose()
    {

        animator.Play("outChoseCar");
        UpdateCarChooseCar(true);
        Debug.Log("On hide Chose car..........!!!");
    }

    public void OnHideChoseEvent()
    {
        
        UIController.instance.uiChoseCarGameObject.SetActive(false);

        Debug.Log("On hide Chose car..........!!!");
    }

    public void UpdateCarChooseCar(bool onclick)
    {
        updateCarChooseCar?.Invoke(onclick);
    }

    #endregion
    
    
   
}
