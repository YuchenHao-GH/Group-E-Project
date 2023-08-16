using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Timer : MonoBehaviour
{
    public Text TimerText;
    public bool Timing = true;
    public float CurrentTime;
    public float TotalTime;
    public Text FinalTime;
    void Start()
    {
        TimerText = GetComponent<Text>() as Text;
        CurrentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timing == true)
        {
        CurrentTime = CurrentTime + Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
        TimerText.text = time.ToString(@"mm\:ss\:ff");
        FinalTime.text = time.ToString(@"mm\:ss\:ff");
        }
        if (Timing == false)
        {
           
            
        }
    }
}
