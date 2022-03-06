using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI score;
    public GameObject newBestScore;
    public TextMeshProUGUI bestScore;
    public TextMeshProUGUI currentScore;
    public GameObject gameOver;
    // Update is called once per frame
    void Update()
    {
        score.text = "score: " + ScoreSystem.instance.Score;
    }

    public void ShowEnd()
    {
        gameOver.SetActive(true);
        if (ScoreSystem.instance.CompareScore())
        {
            newBestScore.SetActive(true);
            bestScore.text ="BEST SCORE: " + ScoreSystem.instance.Score.ToString();
        }
        else
        {
            bestScore.text = "BEST SCORE: " + ScoreSystem.instance.saveScore.GetBestScore().ToString();
            currentScore.gameObject.SetActive(true);
            currentScore.text = "Your Score: " + ScoreSystem.instance.Score.ToString();
        }
    }
}
