using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour

{
    public int zombieHealth;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("ZombieRed"))
        {
            zombieHealth = 4;
        }
        else
        {
            zombieHealth = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieHealth < 1)
        {
            GameObject.Destroy(gameObject);
        }
    }
    public void TakeDamage()
    {
        zombieHealth--;
        Debug.Log("Zombie health: " + zombieHealth);
    }
}
