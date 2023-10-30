using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI comboText;
    [SerializeField] private float time = 60;
    private int combo;
    [SerializeField] private int score = 0;
    void AddToScore(int point)
    {
        score += point;
        scoreText.text = score.ToString();
        combo++;
        comboText.text = "X" + combo.ToString();
    }

    private void Update()
    {
        time -= Time.deltaTime;
        timerText.text = time.ToString();
        if (time <= 0)
        {
            GameManager.getScore?.Invoke(score);
            SceneLoader.loadScene(2);
        }
    }

    private void OnEnable()
    {
        AddPoint.addScore += AddToScore;
    }
    private void OnDisable()
    {
        AddPoint.addScore -= AddToScore;
    }
}
