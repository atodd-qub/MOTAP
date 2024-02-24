using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool isOpen = false;
    private bool isPlayerInside = false;
    public float openAngle = 90f;
    public float closeAngle = 0f;
    public float smooth = 2f;
    public float delayBeforeClosing = 1f;

    void Update()
    {
        if (isPlayerInside)
        {
            // Smoothly rotate the door to open position
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0, 0, isOpen ? openAngle : closeAngle), Time.deltaTime * smooth);
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
            StartCoroutine(CloseDoorWithDelay(delayBeforeClosing)); // Add a delay before closing the door
        }
    }

    IEnumerator CloseDoorWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isOpen = false; // Automatically close the door after the delay
    }
}