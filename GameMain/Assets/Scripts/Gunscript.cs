using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunscript : MonoBehaviour
{

    // Update is called once per frame
    private CameraController cameracontroller;
    private bool isShooting = false;
    void Start()
    {
        cameracontroller = FindObjectOfType<CameraController>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
            StartCoroutine(ShootRepeatedly());
          
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }
    }

    IEnumerator ShootRepeatedly()
    {
        while (isShooting)
        {
            Shoot();
            yield return new WaitForSeconds(0.1f);
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100))
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
        cameracontroller.xRotation -= 1.5f;

    }

}

