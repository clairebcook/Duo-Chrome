

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
        //SceneManager.LoadScene("levelSelect");
        //use this one to add the first level once it is created
    }
}