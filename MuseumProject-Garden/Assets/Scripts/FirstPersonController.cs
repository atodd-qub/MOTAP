using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirstPersonController : MonoBehaviour
{
    public float movementSpeed = 5.0f; // Player movement speed
    public float mouseSensitivity = 100.0f; // Sensitivity of mouse movement

    private float xRotation = 0f; // Rotation around the X-axis (for looking up and down)

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    void Update()
    {
        // Player movement
        float x = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        // Apply movement relative to where the player is facing
        transform.Translate(x, 0, z);

        // Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // Invert mouseY input for up and down look
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp the up/down look to 90 degrees

        // Apply rotation for looking up and down
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the player left and right
        transform.Rotate(Vector3.up * mouseX);
    }
}