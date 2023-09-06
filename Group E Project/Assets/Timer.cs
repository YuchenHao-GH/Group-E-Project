using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    private Text TimerText;
    public bool Timing;
    private float CurrentTime;
    private float TotalTime;
    public Text Finaltime;
  
    void Start()
    {
        TimerText = GetComponent<Text>();
            
        CurrentTime = 0;
        TotalTime = 0;
    }


   
    // Update is called once per frame
    void Update()
    {
        if (Timing == true)
        {
        CurrentTime = CurrentTime + Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
        TimerText.text = time.ToString(@"mm\:ss\:ff");
        Finaltime.text = time.ToString(@"mm\:ss\:ff");
        }
        if (Timing == false)
        {
           
            
        }
    }
}

