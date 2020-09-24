using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText, comboText;



    void Awake()
    {
        ScoreManager.OnScoreChanged += UpdateScore;
        PlayerInteraction.OnObstacleDestroyed += BoomBoomScore;
    }

    void UpdateScore()
    { 
        scoreText.text = "Score: " + ScoreManager.Instance.totalScore;
    }

    void BoomBoomScore(int reward, int comboCount)
    {
        // comboText.transform.localScale *= 1.01f;
        CancelInvoke("DisableComboText");
        comboText.enabled = true;
        comboText.text = "Combo x" + comboCount;
        Animator animCombo = comboText.GetComponent<Animator>();
        animCombo.SetTrigger("boom");
        Invoke("DisableComboText", 1f);
    }

    void DisableComboText()
    {
        comboText.DOFade(0, .2f);
    }
}
