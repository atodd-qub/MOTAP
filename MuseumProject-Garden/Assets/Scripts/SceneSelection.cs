using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // swap scene
        if (gameObject.tag == "Blue")
        {
            SceneManager.LoadScene("SceneBlue", LoadSceneMode.Single);
        }
        else if (gameObject.tag == "Red")
        {
            SceneManager.LoadScene("SceneRed", LoadSceneMode.Single);
        }

    }
}
