using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{

    public void exitGame()
    {
        Application.Quit();
    }

    public void nextLevel()
    {
        Debug.Log("button clicked");
        SceneManager.LoadScene(SceneManager.sceneCount + 1);
    }

    public void startGame()
    {
        Debug.Log("start clicked");
        SceneManager.LoadScene("Level1");
    }
}
