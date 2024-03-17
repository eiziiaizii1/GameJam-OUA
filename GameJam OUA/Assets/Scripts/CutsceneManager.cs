using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{

    public void exitGame()
    {
        Application.Quit();
    }

    public void nextLevel()
    {
        Debug.Log("Next level is on progress");
    }
}
