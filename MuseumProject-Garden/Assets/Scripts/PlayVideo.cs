using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; // Correct namespace is UnityEngine.Video

public class PlayVideo : MonoBehaviour
{
    // Reference to your VideoPlayer component
    private VideoPlayer videoPlayer;

    // Initialize the videoPlayer reference
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        if (videoPlayer == null)
        {
            Debug.LogError("No VideoPlayer component found on the GameObject.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player") && videoPlayer != null)
        {
            // Play the video when the player enters the trigger zone
            videoPlayer.Play();
        }
    }
}

