using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    //Loads the level named 'Level'
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }

    //Closes the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
