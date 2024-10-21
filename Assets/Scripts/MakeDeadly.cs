using UnityEngine;
using System;
using System.Collections;


public class MakeDeadly : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        var player = other.collider.GetComponent<Player>();

        if (player != null) {
            player.Die();
        }

    }
}
