using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public Text scoreText;
    public ScoreContainer scoreContainer;
    private void Awake()
    {
        Instance = this;
    }
    
    private void OnEnable()
    {
        scoreContainer.onScoreUpdate += UpdateScore;
    }

    private void OnDisable()
    {
        scoreContainer.onScoreUpdate -= UpdateScore;
    }

    private void Start()
    {
        scoreContainer.ResetCurrentScore();
    }

    private void UpdateScore(float score)
    {
        scoreText.text = score.ToString();
    }
}
