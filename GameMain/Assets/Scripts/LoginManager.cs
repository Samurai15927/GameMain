//This is the login manager this script take what the user puts in for there username and checks if it is a valid username. It then switches scene to the game.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    public InputField username; // Input field for the username
    public Button loginButton; // Button for login
    public TMP_Text errorMessage; // Text field for error messages

    //start is called before the first frame updates. In start the cursor is unlocked. 
    void Start()
    {
        // Unlocks the cursor so the player can type in their username. The cursor is locked in the game and doesn't unlock without this code.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Method called when the Login button is clicked. This method will determine if the username is acceptable or not.
    public void UsernameChecker()
    {
        int numCount = 0; // Count of digits in the username
        int charCount = username.text.Length; // Character count of the username
        int specCount = username.text.Length; // Count of special characters in the username

        // Checks the character count of the username to determine if it's too long or short.
        foreach (char c in username.text)
        {
            // Checks if there are any digits in the username and increments the numCount variable if found.
            if (char.IsDigit(c))
            {
                numCount++;
            }

            // Checks if there are any special characters by comparing the total characters and subtracting all letters and digits.
            // If the remaining count is greater than zero, it means there is a special character.
            if (char.IsLetterOrDigit(c))
            {
                specCount--;
            }
        }
        
        // Detects if the character count is too great and displays an error message if it is.
        if (charCount > 10 || charCount < 2)
        {
            errorMessage.SetText("The Name Must Have Between 2 And 10 Characters");
        }
        // Checks if there are any digits in the username and displays an error message if found.
        else if (numCount > 0)
        {
            errorMessage.SetText("No Numbers Are Allowed");
        }
        // Checks if there are any special characters in the username and displays an error message if found.
        else if (specCount > 0)
        {
            errorMessage.SetText("No Special Characters allowed");
        }
        //Checks if username has Briggs in it and if so initates scene switch into the game.
        else if (username.text.Contains("Briggs"))
        {
            errorMessage.SetText("Welcome Sir");
            StartCoroutine(SwitchToGame());
        }
        // If all checks pass, it means the username is accepted and initiates a switch to the Game scene after a delay.
        else
        {
            errorMessage.SetText("Username Accepted");
            StartCoroutine(SwitchToGame());
        }
    }

    // Coroutine for switching to the Game scene after a delay
    IEnumerator SwitchToGame()
    {
        //Waits 2 seconds before entering game
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");
    }
}
