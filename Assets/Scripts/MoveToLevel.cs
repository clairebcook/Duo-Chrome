using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToLevel : MonoBehaviour
{
        public AudioManager am;
                
       public string nextLevel;
       
       private void OnCollisionEnter2D(Collision2D other) {
        var player = other.collider.GetComponent<Player>();
        if (player != null) {
            am.playDoor();
            SceneManager.LoadScene(nextLevel);
        }
    }
}
