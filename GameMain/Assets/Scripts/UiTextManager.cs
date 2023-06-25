using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiTextManager : MonoBehaviour
{
    public Text deathText;// Reference to the UI from DeathText
    public Text Health;// Reference to the UI from Health
    private PlayerController PlayerControllerUI;// Reference to the PlayerController script

    // List of death phrases
    public static List<string> DeathPhrase = new List<string>()
    {
        "You Lose", "You Died", "Why So Bad?" //Three death Phrases
    };

    void Start()
    {
        // Finding the PlayerController script attached to the Player
        PlayerControllerUI = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        // Updating the health text with the current health value of the player
        Health.text = "HP:" + PlayerControllerUI.health;    
    }

    // Method called when the player dies that displays a random death text
    public void HandleDeath()
    {
        int randomIndex = Random.Range(0, DeathPhrase.Count);   // Generating a random value within the range of the DeathPhrase list
        deathText.text = DeathPhrase[randomIndex];              // Setting the death text to a random death phrase from the list
    }
}
