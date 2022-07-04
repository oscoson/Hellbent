using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text pointsText;
    public void Setup(int score)
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        if(!(SceneManager.GetActiveScene().name == "Tutorial"))
        {
            GameObject.FindWithTag("MainMusic").SetActive(false);
            pointsText.text = "You made it to Room " + (score - 1).ToString();
        }
        else
        {
            GameObject.FindWithTag("Tutorial Music").SetActive(false);
            pointsText.text = "Restart or go back to Main Menu";
        }
    }

    public void RestartButton() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void RestartTutorialButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Tutorial");   
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
