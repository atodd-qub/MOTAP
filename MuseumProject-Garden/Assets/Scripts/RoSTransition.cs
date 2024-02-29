using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoSTransition : MonoBehaviour
{
    // Current/past objects in arrays
    public GameObject[] currentObjects;
    public GameObject[] pastObjects;

    private bool currentDayBool;
    private bool pastBool;
    
    // Start is called before the first frame update
    void Start()
    {
        /*if (currentObjects == null)
        {
            currentObjects = GameObject.FindGameObjectsWithTag("Current");
        }
        if (pastObjects == null)
        {
            pastObjects = GameObject.FindGameObjectsWithTag("Past");
        }*/

        currentObjects = GameObject.FindGameObjectsWithTag("Current");
        pastObjects = GameObject.FindGameObjectsWithTag("Past");

        currentDayBool = true;
        pastBool = false;
        CheckTimePeriod();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Change period");
            
            CheckTimePeriod();
        }
    }

    void CheckTimePeriod()
    {
        // TODO: REFACTOR THIS METHOD
        
        if (currentDayBool && !pastBool)
        {
            foreach (GameObject currentObj in currentObjects)
            {
                // disable mesh renderer and collider
                MeshRenderer meshRend = currentObj.GetComponent<MeshRenderer>();
                meshRend.enabled = true;
            }
            foreach (GameObject pastObj in pastObjects)
            {
                // disable mesh renderer and collider
                MeshRenderer meshRend = pastObj.GetComponent<MeshRenderer>();
                meshRend.enabled = false;
            }

            currentDayBool = false;
            pastBool = true;
        }
        else if (!currentDayBool && pastBool)
        {
            foreach (GameObject currentObj in currentObjects)
            {
                // disable mesh renderer and collider
                MeshRenderer meshRend = currentObj.GetComponent<MeshRenderer>();
                meshRend.enabled = false;
            }
            foreach (GameObject pastObj in pastObjects)
            {
                // disable mesh renderer and collider
                MeshRenderer meshRend = pastObj.GetComponent<MeshRenderer>();
                meshRend.enabled = true;
            }

            currentDayBool = true;
            pastBool = false;
        }
    }
}
