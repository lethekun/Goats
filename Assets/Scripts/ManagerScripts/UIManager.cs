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
    [SerializeField] Transform Player;
    [SerializeField] Transform EndLine;
    [SerializeField] Slider slider;
    [SerializeField] GameObject MovementIndicator;

    float maxDistance;

    void Awake()
    {
        maxDistance = getDistance();
        ScoreManager.OnScoreChanged += UpdateScore;
        PlayerInteraction.OnObstacleDestroyed += BoomBoomScore;
        InputController.mousePressed += HideMovementIndicator;
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
        scoreText.text = "Score: " + ScoreManager.Instance.totalScore;
    }

    void BoomBoomScore(int reward, int comboCount)
    {
        // comboText.transform.localScale *= 1.01f;
        CancelInvoke("DisableComboText");
        comboText.DOFade(1, .1f);
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
    }

    private void OnDisable()
    {
        InputController.mousePressed -= HideMovementIndicator;
        ScoreManager.OnScoreChanged -= UpdateScore;
        PlayerInteraction.OnObstacleDestroyed -= BoomBoomScore;
    }
}
