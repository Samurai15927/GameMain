using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiTextManager : MonoBehaviour
{

    public Text Health;
    private PlayerController PlayerControllerUI;
    // Start is called before the first frame update
    void Start()
    {

        PlayerControllerUI = GameObject.Find("Player").GetComponent<PlayerController>();
        Debug.Log(PlayerControllerUI.health);

    }

    // Update is called once per frame
    void Update()
    {
        Health.text = "HP" + PlayerControllerUI.health;
    }
}
