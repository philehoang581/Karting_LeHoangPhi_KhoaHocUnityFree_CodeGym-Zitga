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

}

public class AllData
{
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
}
