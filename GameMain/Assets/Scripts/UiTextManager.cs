//UITextManager is a script that manages the text in the UI It does this by updating text when it changes.
//It contains a list of ending phrases that are played when the game ends through a random selection.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiTextManager : MonoBehaviour
{
    public Text deathText;// Reference to the UI from DeathText
    public Text healthText;// Reference to the UI from Health
    private PlayerController playerControllerUI;// Reference to the PlayerController script

    // List of death phrases
    public static List<string> DeathPhrase = new List<string>()
    {
        "You Lose", "You Died", "Why So Bad?" //Three death Phrases
    };
    
    void Start()
    {
        // Finding the PlayerController script attached to the Player
        playerControllerUI = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        // Updating the health text with the current health value of the player
        healthText.text = "HP:" + playerControllerUI.health;    
    }

    // Method called when the player dies that displays a random death text
    public void HandleDeath()
    {
        int randomIndex = Random.Range(0, DeathPhrase.Count);   // Generating a random value within the range of the DeathPhrase list
        deathText.text = DeathPhrase[randomIndex];              // Setting the death text to a random death phrase from the list
    }
}
