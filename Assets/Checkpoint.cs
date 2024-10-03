using UnityEngine;
using System;

public class Checkpoint : MonoBehaviour
{
    // Called when another collider enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player1>();

        if (player != null)
        {
            // Call a method to set the respawn point for the player
            player.setRespawn(transform.position);
        }
    }
}

