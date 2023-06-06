using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public variables
    public float movementSpeed; // Speed of the player movement
    public float sensitivity; // Sensitivity of the player rotation
    public float jumpHeight; // Height of the player jump
    public bool isGrounded; // Whether or not the player is touching the ground
    public int health = 5;

    // Private variables
    private Rigidbody playerRb; // Rigidbody component of the player object
    private CapsuleCollider playerCollider; // CapsuleCollider component of the player object

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody and CapsuleCollider components of the player object
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical input axes
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        
        // Move the player object in the direction of the input axes
        transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * movementSpeed * Time.deltaTime, Space.Self);

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
        // Check if the other object has the "Terrain" tag and set isGrounded to true if it does
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
        }
    }

    public void takeDamage()
    {
        health--;
    }

}