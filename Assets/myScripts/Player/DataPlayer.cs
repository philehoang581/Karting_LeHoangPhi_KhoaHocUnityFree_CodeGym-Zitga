using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataPlayer
{
    private const string ALL_DATA = "all_data";
    private static AllData allData;

    static DataPlayer()
    {
        // chuyen doi keu du lieu tu Json sang all_data 
        allData = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(ALL_DATA));

        //neu du lieu dau vao la null, tuc la user vao lan dau 
        // chung ta khoi tao gia tri mac dinh cho user
        if (allData == null)
        {
            var carDefaultId = 1;
            allData = new AllData
            {
                carList = new List<int> { carDefaultId },
                
            };
        }
        SaveDatda();

    }

    private static void SaveDatda()
    {
        var data = JsonUtility.ToJson(allData);
        PlayerPrefs.SetString(ALL_DATA, data); 
    }

    public static bool isOwnerCarWithId(int id)
    {
        return allData.isOwnerCarWithId(id);
    }

    public static void AddCar(int id)
    {
        allData.AddCar(id);
        SaveDatda();
    }

    public static int GetCar(int carId)
    {
        int valueCar = allData.GetCar(carId);
        Debug.Log($"Gia tri value car trong hàm GetCar: {valueCar}");
        return valueCar;
    }
    public static int GetQuantityCar()
    {
        Debug.Log($"So luong xe dang co: {allData.GetQuantityCar()}");
        return allData.GetQuantityCar();
    }

}

public class AllData
{
    //them static
    public List<int> carList;
    

    public bool isOwnerCarWithId(int id)
    {
        return carList.Contains(id);
    }

    public void AddCar(int id)
    {
        isOwnerCarWithId(id);
        carList.Add(id);
        /*
        if (isOwnerCarWithId(id))
        {
            carList.Add(id);
        }
        */
    }

    public int GetCar(int indexCar)
    {
        
        int valueCar = carList[indexCar];
        return valueCar;

    }
    

    public int GetQuantityCar()
    {
        return carList.Count;
    }





}
