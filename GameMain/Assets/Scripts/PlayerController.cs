using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Public variables
    public float movementSpeed; // Speed of the player movement
    public float sensitivity; // Sensitivity of the player rotation
    public float jumpHeight; // Height of the player jump
    public bool isGrounded; // Whether or not the player is touching the ground
    public int health;
    private UiTextManager UiTextManagerPC;
    private bool isDead = false;
    public float minX; // Minimum x-axis boundary
    public float minZ; // Minimum z-axis boundary
    public float maxX; // Maximum x-axis boundary
    public float maxZ; // Maximum z-axis boundary

    // Private variables
    private Rigidbody playerRb; // Rigidbody component of the player object
    private CapsuleCollider playerCollider; // CapsuleCollider component of the player object

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody and CapsuleCollider components of the player object
        playerRb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        UiTextManagerPC = GameObject.Find("Ui Text").GetComponent<UiTextManager>();
    }

    // Update is called once per frame
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
        // Check if the other object has the "Terrain" tag and set isGrounded to true if it does
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
        }
    }

    public void takeDamage()
    {
        if (isDead == false)
        {
            health--;
            if (health < 1)
            {
                isDead = true;
                UiTextManagerPC.HandleDeath();
                StartCoroutine(SwitchScene());
            }
        }
    }

    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Login Page");
    }
}