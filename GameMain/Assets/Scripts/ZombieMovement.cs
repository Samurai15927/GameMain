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
    private PlayerController pc;
    
    

    private bool isAttacking = false;
    // Start is called before the first frame update
    void Start()
    {
       
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        zombieAttack();
      

        
    }

    void zombieAttack()
    {
        distance = Vector3.Distance(player.transform.position, zombie.transform.position);
        if (distance < 1.5)
        {
            animator.SetBool("IsClose", true);
            transform.LookAt(player.transform);
            Vector3 Rotation = transform.eulerAngles;
            Rotation.x = 0f;
            transform.eulerAngles = Rotation;

            if (!isAttacking)
            {
                StartCoroutine(Damage());
            }

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

    IEnumerator Damage()
    {
        isAttacking = true;
        yield return new WaitForSeconds(2f);
        pc.takeDamage();
        Debug.Log(pc.health);
        isAttacking = false;
    }

}
