using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour

{
    public GameObject player;
    public float zombieSpeed;
    public GameObject zombie;
    public float distance;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, zombie.transform.position);
        if (distance < 1.5)
        {
            animator.SetBool("IsClose", true);
            transform.LookAt(player.transform);
            Vector3 Rotation = transform.eulerAngles;
            Rotation.x = 0f;
            transform.eulerAngles = Rotation;
        }
        else
        {
            animator.SetBool("IsClose", false);
            Transform playerTransform = player.transform;
            transform.LookAt(playerTransform);
            Vector3 Rotation = transform.eulerAngles;
            Rotation.x = 0f;
            transform.eulerAngles = Rotation;
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * zombieSpeed);
            
        }
       
    }
}
