using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myMenuGame : MonoBehaviour
{
    public GameObject login;
    public GameObject logged;

    public InputField user;
    public InputField pass;
    public int choseCar;
    public Camera mainCamera;

    //public Text user;
    //public Text pass;
    // Start is called before the first frame update
    void Start()
    {
        choseCar = -20;
        //logged.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        mainCamera.transform.position = new Vector3(choseCar, 1, -10);
    }

    public void NextCar()
    {
        choseCar += 20;
    }
    
    public void BackCar()
    {
        choseCar -= 20;
    }
    void LoginEnter()
    {
        logged.SetActive(true);
        login.SetActive(false);
    }
    public void Login()
    {
        if (user.text == "phi" && pass.text == "phi")
        {
            LoginEnter();
            Debug.Log($"Your User: {user.text}");
            Debug.Log($"Your Pass: {pass.text}");
        }
        else
        {
            user.text = "wrong";
            pass.text = "wrong";
        }
            
    }
}
