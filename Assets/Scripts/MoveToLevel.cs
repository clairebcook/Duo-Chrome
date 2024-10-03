using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToLevel : MonoBehaviour
{
        public string nextLevel;
       
       private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("hi!");
        var player = other.collider.GetComponent<Player1>();
        if (player != null) {
            Debug.Log("meow!");
            SceneManager.LoadScene(nextLevel);
        }
    }
}
