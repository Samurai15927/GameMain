using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginManager : MonoBehaviour
{
    public InputField username;
    public Button loginButton;
    private int charCount;
    public TMP_Text errorMessage;
    private int numCount;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UsernameChecker()
    {
        int specCount = username.text.Length;

        foreach (char c in username.text)
        {
            if (char.IsDigit(c))
            {
                numCount++;

            }
            else if (char.IsLetterOrDigit(c))
            {
                specCount--;
            }

        }
        if (charCount > 10 || charCount < 2)
        {
            errorMessage.SetText("The Name Must Have Between 2 And 10 Characters");
        }
        else if (numCount > 0)
        {
            errorMessage.SetText("No Numbers Are Allowed");
        }
        else if (specCount > 0)
        {
            errorMessage.SetText("No Special Characters allowed");
        }
        else 
        {
            errorMessage.SetText("Username Accepted");
        }
    }
    

}  

