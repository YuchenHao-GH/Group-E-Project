using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    private Text FinalScore;
    public GameObject lol;
    public GameObject ReloadPanel;

    void Awake()
    {
      
    }

    void Start()
    {
        FinalScore = GameObject.FindGameObjectWithTag("FinalText").GetComponent<Text>();
        lol = GameObject.FindGameObjectWithTag("FinalText");
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
        
    }
}
