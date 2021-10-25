using System.Collections;
using UnityEngine;

public static class DataManager
{
    public static int cardId;


}

/// <summary>
/// Pattern singleton
/// </summary>
public class DataManager2
{
    
    public static DataManager2 Instance { get; }

    static DataManager2()
    {
        Instance = new DataManager2();
    }

    private DataManager2() { }

    /// Data của mình

    public int cardId;
    public Vector3 position;

    public void Reset() 
    {
        // reset các giá trị về mặc định
    }
}