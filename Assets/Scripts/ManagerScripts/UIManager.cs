using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText, comboText, levelFinishedText, logo;
    [SerializeField] Transform Player, EndLine, LevelFinishedPanel;
    [SerializeField] Slider slider;
    [SerializeField] GameObject MovementIndicator;
    [SerializeField] RawImage replay, nextLevel;
    float maxDistance;

    void Awake()
    {
        ScoreManager.OnScoreChanged += UpdateScore;
        PlayerInteraction.OnObstacleDestroyed += BoomBoomScore;
        PlayerInteraction.OnLevelFinished += OnFinishHandler;
        InputController.mousePressed += HideMovementIndicator;
        InputController.mousePressed += SetMaxDistance;
        Destructable.OnBoxMissed += OnBoxMissedHandler;
    }
    private void Update()
    {
        if(Player.position.z <= maxDistance && Player.position.z <= EndLine.position.z)
        {
            float distance = 1 - (getDistance() / maxDistance);
            setProgress(distance);
        }
    }
    void UpdateScore()
    { 
        scoreText.text = ScoreManager.Instance.totalScore.ToString();
    }

    void BoomBoomScore(int reward)
    {
        // comboText.transform.localScale *= 1.01f;
        CancelInvoke("DisableComboText");
        comboText.DOFade(1, .1f);
        comboText.enabled = true;
        comboText.text = "Combo x" + PlayerInteraction.comboCount;
        Animator animCombo = comboText.GetComponent<Animator>();
        animCombo.SetTrigger("boom");
        Invoke("DisableComboText", 1f);
    }

    void DisableComboText()
    {
        comboText.DOFade(0, 2f);
    }

    void SetMaxDistance()
    {
        maxDistance = getDistance();
        InputController.mousePressed -= SetMaxDistance;
    }

    float getDistance()
    {
        return Vector3.Distance(Player.position, EndLine.position);
    }
    void setProgress(float p)
    {
        slider.value = p;
    }

    void HideMovementIndicator()
    {
        InputController.mousePressed -= HideMovementIndicator;
        MovementIndicator.SetActive(false);
        logo.gameObject?.SetActive(false);
    }

    void OnFinishHandler()
    {
        LevelFinishedPanel.gameObject.SetActive(true);
        scoreText.DOFade(0, .2f);
        comboText.DOFade(0, .2f);
        levelFinishedText.DOFade(1f,0.2f);
        replay.DOFade(1f, 0.2f);
        nextLevel.DOFade(1f, 0.2f);
    }

    void OnBoxMissedHandler()
    {
        CancelInvoke("DisableComboText");
        comboText.DOFade(1f, 0.1f);
        comboText.text = "Missed!";
    }

    private void OnDisable()
    {
        InputController.mousePressed -= HideMovementIndicator;
        InputController.mousePressed -= SetMaxDistance;
        ScoreManager.OnScoreChanged -= UpdateScore;
        PlayerInteraction.OnObstacleDestroyed -= BoomBoomScore;
        PlayerInteraction.OnLevelFinished -= OnFinishHandler;
        Destructable.OnBoxMissed -= OnBoxMissedHandler;
    }
}
