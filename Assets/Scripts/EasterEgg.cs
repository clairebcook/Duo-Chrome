using System.Collections;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    private Rigidbody2D rb;
    public float collectForce = 5;

    public AudioSource audioS;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        audioS = GetComponent<AudioSource>();
    }

    void Update() {

    }

    // called on the easter egg when the player collides with it
    private IEnumerator CollectMe() {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, collectForce);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    // audio coroutine
    private IEnumerator PlayJingle() {
        if (audioS != null) {
            audioS.Play();
        }
        yield return new WaitForSeconds(1);
    }

    // collect the item when walked on
    private void OnTriggerEnter2D(Collider2D other) {
        var player = other.GetComponent<Player1>();

        if (player != null) {
            StartCoroutine(PlayJingle());
            StartCoroutine(CollectMe());
        }

    }
    
}
