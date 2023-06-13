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
        //Unlocks the cursor so player can type in there username. As cursor is locked in game and doesn't unlock without this code.
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Method UsernameChecker is called. This method will determine if the username is acceptable or not.
    public void UsernameChecker() 
    {
        int numCount = 0;
        int charCount = username.text.Length;
        int specCount = username.text.Length;
        //Checks the Charactor count of the Username to determine if username is too long or short.
        foreach (char c in username.text)
        {
            //Checks if there are any digits in the username and assigns if there are to a variable numcount.
            if (char.IsDigit(c))
            {
                numCount++;

            }
            //Checks if there are any special charactors by getting total charactors and taking away all letters and digits. If he number left is greater
            //than zero it means that there is a special character. I belive there is a better way to do this but this does work.
            if (char.IsLetterOrDigit(c))
            {
                specCount--;
            }

        }
        //Detects if Charactor Count is too great and prints an error message if it is.
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

