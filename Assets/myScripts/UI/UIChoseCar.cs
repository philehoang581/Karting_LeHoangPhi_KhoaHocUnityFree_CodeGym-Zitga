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

    private int indexCar;
    private int valueCar;

    

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
        indexCar = 0;
        valueCar = DataPlayer.GetCar(indexCar);


    }
    private void Start()
    {
        

        nextCarBtn.onClick.AddListener(NextCar);
        backCarBtn.onClick.AddListener(BackCar);

        closeBtn.onClick.AddListener(OnHideChose);

    }

    private void NextCar()
    {
        indexCar++;
        int quantityCar = DataPlayer.GetQuantityCar();
        if (indexCar>quantityCar-1)
        {
            indexCar = 0;
        }
       
        //Lấy giá rị indexCar làm index trong carList => load lên model car
        valueCar = DataPlayer.GetCar(indexCar);
        //Debug.Log($"Gia tri value car trong hàm UIShooseCar: {valueCar}");

        // Gui indexCar den Prencenter trong GamePlay Level1, Level2

        SetCar(valueCar);
        //Debug.Log($"valueCar lay tu Data: {valueCar}");

        UpdateCarChooseCar(true);
        InitCar();
        
    }

    private void BackCar()
    {
        indexCar--;
        
        int quantityCar = DataPlayer.GetQuantityCar();
        if (indexCar < 0)
        {
            indexCar = quantityCar-1;
        }
        Debug.Log($"Gia tri Index car trong hang BACK: {indexCar}");

        //Lấy giá rị indexCar làm index trong carList => load lên model car
        valueCar = DataPlayer.GetCar(indexCar);
        //Debug.Log($"Gia tri value car trong hàm UIShooseCar: {valueCar}");

        // Gui indexCar den Prencenter trong GamePlay Level1, Level2

        SetCar(valueCar);
        //Debug.Log($"valueCar lay tu Data: {valueCar}");

        UpdateCarChooseCar(true);
        InitCar();
    }

    public void SetCar(int indexCar)
    {

        setCar?.Invoke(indexCar);
        DataManager.cardId = indexCar;
        //PlayerPrefs.SetInt("CarId", indexCar); // lưu qua nhiều session, persistent storage
        //DataManager2.Instance.cardId = indexCar;
        //Debug.Log($"Choose car dang phat su kien chon car ID: {indexCar}");
    }
    private void InitCar()
    {
       
        prefab = Resources.Load<GameObject>($"CarModel/Car-{valueCar}");
        Debug.Log($"Value Carr: {valueCar}");
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
