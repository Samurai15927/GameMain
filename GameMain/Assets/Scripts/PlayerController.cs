using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Public variables
    public float movementSpeed; // Speed of the player movement
    public float sensitivity; // Sensitivity of the player 
    public float jumpHeight; // Height of the player jump
    public bool isGrounded; // Whether or not the player is touching the ground
    public int health;      //Health of the player
    private UiTextManager UiTextManagerPC; //Allows to get variables from UITextManager
    private bool isDead = false;
    public float minX; // Minimum x-axis boundary
    public float minZ; // Minimum z-axis boundary
    public float maxX; // Maximum x-axis boundary
    public float maxZ; // Maximum z-axis boundary

    // Private variables
    private Rigidbody playerRb; // Rigidbody component of the player object
    private CapsuleCollider playerCollider; // CapsuleCollider component of the player object

    
    void Start()
    {
        // Get the Rigidbody and CapsuleCollider components of the player object
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        UiTextManagerPC = GameObject.Find("Ui Text").GetComponent<UiTextManager>();
    }

    
    void Update()
    {
     

        // Get the horizontal and vertical input axes
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        // Calculate the new position of the player object
        Vector3 newPosition = transform.position + (transform.forward * verticalInput + transform.right * horizontalInput) * movementSpeed * Time.deltaTime;
        
        // Apply boundaries to the new position based on the minimum and maximum x and z values
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        // Move the player object to the new position
        transform.position = newPosition;

        // Get the mouse X input axis
        var mouseX = Input.GetAxis("Mouse X");

        // Rotate the player object around the Y-axis based on the mouse X input
        transform.Rotate(Vector3.up * mouseX * sensitivity * Time.deltaTime, Space.Self);

        // Check if the Space key is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Get the jump input axis and apply an upward force to the player object
            float jumpInput = Input.GetAxis("Jump");
            playerRb.AddForce(Vector3.up * jumpInput * jumpHeight);

            // Set isGrounded to false since the player is no longer touching the ground
            isGrounded = false;
        }
    }

    // OnCollisionEnter is called when the player object collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the terraub and player are in contact with each other before allowing jump again
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
        }
    }

    public void takeDamage()
    {
        //Checks the player isnt dead before taking health to make HP not go below 0
        if (isDead == false)
        {
            //Takes a health off the player
            health--;
            if (health < 1)
            {
                //Starts the ending sequence as player is dead
                isDead = true;
                UiTextManagerPC.HandleDeath();
                StartCoroutine(SwitchScene());
            }
        }
    }
    //Starts corutine to switch scenes as game is over
    IEnumerator SwitchScene()
    {
        //Waits 5 seconds before switching scenes
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Login Page");
    }
}