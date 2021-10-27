using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UIShopElement : MonoBehaviour
{
    public static UIShopElement _instance;
    private int idCar;
    private int cost;

    public Animator animator;

    public TextMeshProUGUI txt_cost;
    
    public Button btnPurchase;
    public Button btnNextCar;
    public Button btnBackCar;
    public Button hideBtn;


    private GameObject carItem;
    private GameObject prefab;

    public GameObject positionCar;

    //Tạo sự kiện onclick button next/back cho EventUpdate nhận
    public UnityEvent<bool> updateCarShop;

    private void Awake()
    {
        _instance = this;
        idCar = 1;
        btnPurchase.onClick.AddListener(OnPurchase);
        btnNextCar.onClick.AddListener(NextCar);
        btnBackCar.onClick.AddListener(BackCar);
        hideBtn.onClick.AddListener(OnHideShop);

    }

    private void OnEnable()
    {
        //Debug.Log("UI Shop Element duoc goi...!!!");
        InitCar();
    }
    private void NextCar()
    {
        if (idCar >= 4)
        {
            idCar = 1;
        }
        else
        {
            idCar += 1;
            
        }
        SetData(idCar);
        InitCar();

        //xoa car truoc do
        UpdateCarShop(true);
    }

    private void BackCar()
    {
        if (idCar <=1)
        {
            idCar = 4;
        }
        else
        {
            idCar -= 1;
            
        }
        SetData(idCar);
        InitCar();

        //xoa car truoc do
        UpdateCarShop(true);
    }
    /*
    private IEnumerator Start()
    {
        //var request = Resources.LoadAsync<GameObject>($"Prefabs/player_{playerIndex}");
    }
    */
    #region----SetData----
    public void SetData(int id)
    {
        this.idCar = id;
        cost = id * 100;
        
        UpdateView();
    }
    #endregion

    #region----InitCar
    private void InitCar()
    {
        var postionCar = new Vector3(0,0,0);
        prefab = Resources.Load<GameObject>($"CarModel/Car-{idCar}");
        carItem = Instantiate(prefab, positionCar.transform);
        UpdateView();
    }
    #endregion

    
    private void UpdateView()
    {
        //Kiem tra xe co dang so huu hai khong
        var isOwned = DataPlayer.isOwnerCarWithId(idCar);
        
        //Neu so huu thi khong cho mua va nguoc lai
        if (isOwned)
        {
            btnPurchase.enabled = false;
            txt_cost.text = "Owner";
            
        }
        else
        {
            btnPurchase.enabled = true;
            
            txt_cost.text = cost.ToString();
        }

    }

    #region ----OnPurchase----
    public void OnPurchase()
    {
        Debug.Log("Purchase success Car ID: "+ idCar);
        DataPlayer.AddCar(idCar);
        UpdateView();

        //test goi ham GetCar
       
    }
    #endregion


    //Event update Car
    public void UpdateCarShop(bool onclick)
    {
        updateCarShop?.Invoke(onclick);
        
        
    }
    public void OnHideShop()
    {
        animator.Play("outShop");

        
        UpdateCarShop(true);
    }

   

    public void OnHideShopEvent()
    {
        gameObject.SetActive(false);
        Debug.Log("OnHideShopEvent");
        //UIController.instance.player.SetActive(true);
        UIController.instance.uiShopGameObject.SetActive(false);
    }
}
