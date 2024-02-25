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
        yield return new WaitForSeconds(openTime);
        doorOpened.SetActive(false);
        doorClosed.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(false);
        }
    }
}