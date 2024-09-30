using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("tutorialLevel");

    public void LevelSelector()
     {
            SceneManager.LoadScene("levelSelect");
     }

        public void OpenGameControls()
        {
            // Here, you can either load another scene, or show a panel with the controls.
            // Example: SceneManager.LoadScene("GameControlsScene");
        }

        public void OpenSettings()
        {
            // Same as Game Controls, either load a scene or show a settings panel.
            // Example: SceneManager.LoadScene("SettingsScene");
        }

        public void QuitGame()
        {
            Application.Quit(); // Quits the game (only works in the built version, not in the Unity editor).
        }
    }
}