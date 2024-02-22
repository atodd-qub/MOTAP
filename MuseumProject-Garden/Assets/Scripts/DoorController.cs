using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    public float smoothRotationSpeed = 5f;
    public Quaternion doorOpenRotation;
    public Quaternion doorClosedRotation;

    private bool isOpen = false;

    private void Start()
    {
        doorClosedRotation = transform.rotation; // Set initial closed rotation
        doorOpenRotation = Quaternion.Euler(0f, 90f, 0f); // Set desired open rotation
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Example: Press 'E' to interact
        {
            isOpen = !isOpen;
            StartCoroutine(AnimateDoor(isOpen ? doorOpenRotation : doorClosedRotation));
        }
    }

    private IEnumerator AnimateDoor(Quaternion targetRotation)
    {
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * smoothRotationSpeed;
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime);
            yield return null;
        }
    }
}