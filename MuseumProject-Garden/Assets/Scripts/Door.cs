using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorClosed, doorOpened, intIcon;
    public float openTime;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("OnTriggerStay called"); // Add this line
            intIcon.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                intIcon.SetActive(false);
                doorClosed.SetActive(false);
                doorOpened.SetActive(true);
                StartCoroutine(closeDoor());
            }
        }
    }

    IEnumerator closeDoor()
    {
        Debug.Log("Coroutine closeDoor started"); // Add this line
        yield return new WaitForSeconds(openTime);
        doorOpened.SetActive(false);
        doorClosed.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            Debug.Log("OnTriggerExit called"); // Add this line
            intIcon.SetActive(false);
        }
    }
}