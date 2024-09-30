using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject startButton;

    public void PlayGame()
    {
        SceneManager.LoadScene("tutorialLevel");
    }
}

