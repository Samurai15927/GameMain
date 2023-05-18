using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour

{
    public GameObject zombie;
    public int zombieHealth;
    // Start is called before the first frame update
    void Start()
    {
        if (zombie.CompareTag("ZombieRed"))
        {
            int zombieHealth = 4;
        }
        else
        {
            int zombieHealth = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieHealth < 1)
        {

        }
    }
    public void TakeDamage()
    {
        zombieHealth--;
        Debug.Log("Zombie health: " + zombieHealth);
    }
}
