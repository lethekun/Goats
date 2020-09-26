using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("ScoreManager is NULL");
            }
            return _instance;
        }
    }
    public int totalScore;
    public static event Action OnScoreChanged;
    void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
        PlayerInteraction.OnObstacleDestroyed += AddScore;
    }

    public void AddScore(int reward)
    {
        totalScore += reward *PlayerInteraction.comboCount;
        OnScoreChanged?.Invoke();
    }
    private void OnDisable()
    {
        PlayerInteraction.OnObstacleDestroyed -= AddScore;
    }

}
