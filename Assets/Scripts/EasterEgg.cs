using System.Collections;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public float collectForce = 5;

    public AudioSource audioSource;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {

    }

    private IEnumerator CollectMe() {
        rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, collectForce);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private IEnumerator PlayJingle() {
        if (audioSource != null) {
            audioSource.Play();
        }
        yield return new WaitForSeconds(1);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        var player = other.GetComponent<Player>();

        if (player != null) {
            StartCoroutine(PlayJingle());
            StartCoroutine(CollectMe());
        }

    }
    
}
