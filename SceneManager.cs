using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public GameObject pauseScreen, deathScreen, pauseButton, player1Button, player2Button, scoreText, scoreText2;

    void Update()
    {
        Debug.Log("TimeScale: " + Time.timeScale);
    }
    
    public void MainMenuScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");
        Time.timeScale = 1;
    }
    public void GameScreen1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("OnePlayerGameScene");
        Time.timeScale = 1;
    }
    public void GameScreen2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TwoPlayersGameScene");
        Time.timeScale = 1;
    }
    public void Pause()
    {
        pauseScreen.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void GameOver()
    {
        scoreText.SetActive(false); 
        pauseButton.SetActive(false);
        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameOver2()
    {
        //scoreText.SetActive(false);
        //scoreText2.SetActive(false);
        pauseButton.SetActive(false);
        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
