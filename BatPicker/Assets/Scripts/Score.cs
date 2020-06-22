using System;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public string currentScore;
    public string bestScore;

    public void SaveScore()
    {
        PlayerPrefs.SetString("BestScore", currentScore);
        LoadScore();
    }

    public void LoadScore()
    {
        bestScore = PlayerPrefs.GetString("BestScore", "00:00");
    }

    public bool CompareScore()
    {
        int currentMinutes;
        int bestMinutes;
        int currentSeconds;
        int bestSeconds;

        int.TryParse(currentScore.Substring(0, 2), out currentMinutes);
        int.TryParse(currentScore.Substring(3, 2), out currentSeconds);

        int.TryParse(bestScore.Substring(0, 2), out bestMinutes);
        int.TryParse(bestScore.Substring(3, 2), out bestSeconds);

        if (currentMinutes > bestMinutes)
            return true;
        else if (currentMinutes == bestMinutes && currentSeconds >= bestSeconds)
            return true;
        else
            return false;
    }
}
