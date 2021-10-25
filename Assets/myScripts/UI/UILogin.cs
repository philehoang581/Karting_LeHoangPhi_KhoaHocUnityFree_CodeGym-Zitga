using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UILogin : MonoBehaviour
{
    public Button loginBtn;
    public Button registerloginBtn;

    public GameObject reisterGameObject;

    public TMP_InputField userInputField;
    public TMP_InputField passInputField;

    
    

    private void Awake()
    {
        gameObject.SetActive(true);
        loginBtn.onClick.AddListener(Login);
        registerloginBtn.onClick.AddListener(Register);
        
    }

   
    public void Login()
    {
        if (userInputField.text == "" && passInputField.text == "")
        {
            UIController.instance.OnMainMenuGame();
            
            
            gameObject.SetActive(false);
            //Debug.Log($"Your User: {userInputField.text}");
            //Debug.Log($"Your Pass: {passInputField.text}");
        }
        else
        {
            userInputField.text = "wrong";
            passInputField.text = "wrong";
        }

    }
    private void Register()
    {
        userInputField.text = "Tính năng chưa có sẵn...!";
    }
}
