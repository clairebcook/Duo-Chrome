using UnityEngine;
using System;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();

        if (player != null)
        {
            player.setRespawn(transform.position);
        }
    }
}

