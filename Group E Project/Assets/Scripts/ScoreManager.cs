using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    private void Start()
    {
        UpdateScoreText();
        StartCoroutine(IncrementScore());
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private IEnumerator IncrementScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            score += 10;
            UpdateScoreText();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
}
