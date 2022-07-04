using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameOver gameoverscreen;
    public PlayerHealth curHealth;


    public void GameIsOver() 
    {
        gameoverscreen.Setup(SceneManager.GetActiveScene().buildIndex);
    }
    void Update()
    {
        if(curHealth != null)
        {
            if (curHealth.currentHealth <= 0)
            {
                curHealth.DeathState();
                GameIsOver();
            }
        }
        
    }
}
