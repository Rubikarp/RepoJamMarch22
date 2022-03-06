using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int Score{get; private set;}
    public static ScoreSystem instance;
    public SaveScore saveScore;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            return;
        }
        Destroy(gameObject);
    }
    private void Start()
    {
        StartCoroutine(IncrementOverTime());
        saveScore = new SaveScore();
    }
    IEnumerator IncrementOverTime()
    {
        yield return new WaitForSeconds(0.2f);
        Score++;
        StartCoroutine(IncrementOverTime());
    }
    public void AddScore(int value)
    {
        Score += value;
    }
    public bool CompareScore()
    {
        if (saveScore.GetBestScore() < Score)
        {
            saveScore.Saving(Score);
            return true;

        }
        return false;
    }


}
