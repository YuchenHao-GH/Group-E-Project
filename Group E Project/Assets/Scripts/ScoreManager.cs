using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    public Text FinalScore;
    public GameObject ReloadPanel;
    private float HighScore; 
    public Text high;

    void Awake()
    {
      HighScore = PlayerPrefs.GetFloat("HighScore");
    }

    void Start()
    {
        ReloadPanel.SetActive(false);
        UpdateScoreText();
        StartCoroutine(IncrementScore());
    }

   
   
    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        FinalScore.text = "Score: " + score.ToString();
    }

  

    private IEnumerator IncrementScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            score += 10;
            UpdateScoreText();
        }
        
    }

    void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    public void StopScore()
    {
        StopAllCoroutines();
        SetHighScore();
        
    }

    public void SetHighScore()
    {
        if (score > HighScore)
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
        high.text = "High Score: " + PlayerPrefs.GetFloat("HighScore").ToString();
    }
}
