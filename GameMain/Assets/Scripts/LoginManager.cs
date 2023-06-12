using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class LoginManager : MonoBehaviour
{
    public InputField username;
    public Button loginButton;
    public TMP_Text errorMessage;
   
   

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UsernameChecker()
    {
        int numCount = 0;
        int charCount = username.text.Length;
        int specCount = username.text.Length;

        foreach (char c in username.text)
        {
            if (char.IsDigit(c))
            {
                numCount++;

            }
            if (char.IsLetterOrDigit(c))
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
            StartCoroutine(SwitchToGame());
        }
        
    }
    IEnumerator SwitchToGame()
    {
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene("Game");
    }


}

