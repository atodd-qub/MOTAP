using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool isOpen = false;
    private bool isPlayerInside = false;
    public float openAngle = 90f;
    public float closeAngle = 0f;
    public float smooth = 2f;

    void Update()
    {
        if (isPlayerInside)
        {
            // Smoothly rotate the door to open position
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(isOpen ? openAngle : closeAngle, 0, 0), Time.deltaTime * smooth);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            isOpen = true; // Automatically open the door when player enters
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            isOpen = false; // Automatically close the door when player exits
        }
    }
}