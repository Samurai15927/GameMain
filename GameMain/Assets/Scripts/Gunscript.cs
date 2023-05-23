using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunscript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
            {
                if (hit.collider != null)
                {
                    // Check if the hit object is a ZombieRed or ZombieGreen
                    if (hit.collider.CompareTag("ZombieRed") || hit.collider.CompareTag("ZombieGreen"))
                    {
                        // Get the ZombieHealth component of the hit object
                        ZombieHealth zombieHealth = hit.collider.GetComponent<ZombieHealth>();

                        // Apply damage to the zombie
                        if (zombieHealth != null)
                        {
                            zombieHealth.TakeDamage();
                        }
                    }
                }
            }
        }
    }
}