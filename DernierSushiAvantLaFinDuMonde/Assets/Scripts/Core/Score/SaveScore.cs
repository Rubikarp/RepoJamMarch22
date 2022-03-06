using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveScore 
{
    Score score;
    public SaveScore()
    {
        Load();
    }
    private void NewSave()
    {
        score = new Score();
        var dataPath = Path.Combine(Application.persistentDataPath, "score.json");
        string json = JsonUtility.ToJson(score);
        Debug.Log(json);
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }
    public void Load()
    {
        var dataPath = Path.Combine(Application.persistentDataPath, "score.json");
        if (!File.Exists(dataPath))
            NewSave();
        string json = File.ReadAllText(dataPath);
        score = JsonUtility.FromJson<Score>(json);

    }
    public void Saving(int newScore)
    {
        score.bestScore = newScore;
        var dataPath = Path.Combine(Application.persistentDataPath, "score.json");
        string json = JsonUtility.ToJson(score);
        StreamWriter sw = File.CreateText(dataPath);
        sw.Close();
        File.WriteAllText(dataPath, json);
    }

    public int GetBestScore()
    {
        return score.bestScore;
    }
  
   
  
}
