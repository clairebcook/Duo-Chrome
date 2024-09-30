using UnityEngine;
using System;
using System.Collections;


public class OnDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        var player = other.collider.GetComponent<Player1Dash>();

        if (player != null) {
            player.Die();
        }

    }
}
