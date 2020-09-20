using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText;

    void Awake()
    {
        ScoreManager.OnScoreChanged += UpdateScore;
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + ScoreManager.Instance.totalScore;
    }
}
