using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiTextManager : MonoBehaviour
{
    public Text deathText;
    public Text Health;
    private PlayerController PlayerControllerUI;
    public static List<string> DeathPhrase = new List<string>()
        {
        "You Lose", "You Died", "Why So Bad?"
        }
;
    // Start is called before the first frame update
    void Start()
    {

        PlayerControllerUI = GameObject.Find("Player").GetComponent<PlayerController>();
        Debug.Log(PlayerControllerUI.health);

    }

    // Update is called once per frame
    void Update()
    {
        Health.text = "HP:" + PlayerControllerUI.health;
    }
    public void HandleDeath()
    {
        int randomIndex = Random.Range(0, DeathPhrase.Count);
        deathText.text = DeathPhrase[randomIndex];

        
    }
}
