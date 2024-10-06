using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("tutorialLevel");
    }

    public void LevelSelector()
    {
        SceneManager.LoadScene("levelSelect");
    }

    public void OpenControls()
    {
        SceneManager.LoadScene("gameControls");
    }
}