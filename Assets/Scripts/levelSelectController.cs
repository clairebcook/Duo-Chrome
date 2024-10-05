using UnityEngine;
using UnityEngine.SceneManagement;

public class levelSelectController : MonoBehaviour
{
    public void TutorialLevel()
    {
        SceneManager.LoadScene("tutorialLevel");
    }

    public void LevelOne()
    {
        SceneManager.LoadScene("level1");
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("level2");
    }
    public void LevelThree()
    {
        SceneManager.LoadScene("level3");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}