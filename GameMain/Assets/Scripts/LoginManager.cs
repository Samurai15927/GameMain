using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public InputField username;
    public Button loginButton;
    private string usernameText;
    void Start()
    {
        usernameText = username.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UsernameChecker()
    {
       
    }
    

}  

