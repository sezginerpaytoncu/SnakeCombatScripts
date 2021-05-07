using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int scoreSnake1;
    public Text scoreText1, finalScoreText1;

    void Start()
    {
        scoreSnake1=0;
        scoreText1.text = "Score: " + scoreSnake1;
        finalScoreText1.text = "Your Score: " + scoreSnake1;
    }

    public void AddScore()
    {
        scoreSnake1++;
        scoreText1.text = "Score: " + scoreSnake1;
        finalScoreText1.text = "Your Score: " + scoreSnake1;
    }
}
