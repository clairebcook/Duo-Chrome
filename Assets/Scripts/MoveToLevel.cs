using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToLevel : MonoBehaviour
{
        private AudioManager am;
        
        public void Start() {
            am = GetComponent<AudioManager>();
        }
        
       public string nextLevel;
       
       private void OnCollisionEnter2D(Collision2D other) {
        var player = other.collider.GetComponent<Player1>();
        if (player != null) {
            am.playDoor();
            SceneManager.LoadScene(nextLevel);
        }
    }
}
