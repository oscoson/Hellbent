using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // ALl of these examples loads "Level 0"
    }

    public void Intro()
    {
        SceneManager.LoadScene("Intro Scene");
    }

    public void QuitGame()
    {
        // Will happen when our game is an actual application
        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
