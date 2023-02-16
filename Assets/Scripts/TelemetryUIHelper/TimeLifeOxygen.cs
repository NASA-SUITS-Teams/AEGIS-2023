using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeLifeOxygen : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject telemetry;
    string timeLeft; 

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.timeLeft;
        timerText.text = "Time Life Oxygen: " + timeLeft;
    }

    void Update() {
        timeLeft = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.timeLeft;
        timerText.text = "Time Life Oxygen: " + timeLeft; 
    }
}
