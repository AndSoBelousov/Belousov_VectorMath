using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class SwitchingTheScene : GameManager
{
    private void FixedUpdate()
    {
        if(_numberOfLives <= 0)
        {
            OpenGame();
        }
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

}
