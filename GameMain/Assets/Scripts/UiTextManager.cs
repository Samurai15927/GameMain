using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiTextManager : MonoBehaviour
{

    public Text Health;
    public PlayerController PlayerControllerUI;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerControllerUI.health);
        PlayerControllerUI = GameObject.Find("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
      
        
    
        Health.text = "HP" + PlayerControllerUI.health;
    
       
    }
}
