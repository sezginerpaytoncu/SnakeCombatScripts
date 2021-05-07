using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager2 : MonoBehaviour
{
    private int scoreSnake2, scoreSnake3;
    public Text scoreText1, scoreText2, finalScoreText;

    void Start()
    {
        scoreSnake2 = 0;
        scoreSnake3 = 0;
        scoreText1.text = "Score: " + scoreSnake2;
        scoreText2.text = "Score: " + scoreSnake3;
    }
    public void AddScore1()
    {
        scoreSnake2++;
        scoreText1.text = "Score: " + scoreSnake2;
    }
    public void AddScore2()
    {
        scoreSnake3++;
        scoreText2.text = "Score: " + scoreSnake3;
    }
    public void WriteFinalScores(bool snake2Dead, bool snake3Dead)
    {
        if ((snake2Dead == true && snake3Dead == false) || scoreSnake3 > scoreSnake2)
            finalScoreText.text = "Player2 WINS!";
        else if ((snake3Dead == true && snake2Dead == false) || scoreSnake2 > scoreSnake3)
            finalScoreText.text = "Player1 WINS!";
        else if(snake2Dead==true && snake3Dead == true)
            finalScoreText.text = ":) TIE! :)";
        else
            finalScoreText.text = ":) TIE! :)";
    }
}
