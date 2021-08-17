using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScoreContainer",menuName = "Data/ScoreContainer")]
public class ScoreContainer : ScriptableObject
{
    public float currentScore;
    public float maxScore;
    public Action<float> onScoreUpdate;

    public void SetMaxScore()
    {
        if (currentScore > maxScore)
        {
            maxScore = currentScore;
        }
    }

    public void UpdateScore(float score)
    {
        currentScore += score;
        onScoreUpdate?.Invoke(currentScore);
        SetMaxScore();
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }
}
