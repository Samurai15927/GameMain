using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunscript : MonoBehaviour
{
    public GameObject player;
    public float GunVertical;
    public float GunDistance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 cameraForward = player.transform.forward;
            Vector3 cameraDown = player.transform.up;
            Vector3 newPosition = player.transform.position + cameraForward * GunDistance + cameraDown * GunVertical;
            transform.position = newPosition;
        }
     



  
    }
}
