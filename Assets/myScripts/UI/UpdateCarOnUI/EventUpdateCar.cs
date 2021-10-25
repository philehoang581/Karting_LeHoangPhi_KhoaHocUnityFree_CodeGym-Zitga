using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(GameObject))]
public class EventUpdateCar : MonoBehaviour
{
    public static EventUpdateCar intance;
    private void Awake()
    {
        intance = this;

    }
    private void Start()
    {



        
        if (UIChoseCar._instance == null)
        {
            Debug.Log("Chua co UI Choose Car.... !!!");
            
        }
        else
        {
            UIChoseCar._instance.updateCarChooseCar.AddListener(UpdatteCar);
        }

        if (UIShopElement._instance == null)
        {
            Debug.Log("Chua co UI Shop.... !!!");
            
        }
        else
        {
            UIShopElement._instance.updateCarShop.AddListener(UpdatteCar);
            Debug.Log("Su kieen UI Shop da duoc gan.... !!!");
        }
       


    }
    private void UpdatteCar(bool onlclick) 
    {
        Destroy(gameObject);
    }

    private void UpdatteCarShop(bool onlclick)
    {
        Destroy(gameObject);
    }
    public void DestroyCar()
    {
        Destroy(this.gameObject);
        Debug.Log("Ham huy xe tu dong duoc goi...!!!");
        //gameObject.SetActive(false);
    }
}
