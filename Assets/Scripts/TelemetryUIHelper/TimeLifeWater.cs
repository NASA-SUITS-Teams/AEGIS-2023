using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeLifeWater : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject telemetry;
    string timeLeft; 

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = telemetry.GetComponent<GetTelemetry>().telemData.H2oParams.timeLeft;
        timerText.text = "Time Life Water: " + timeLeft;
    }

    void Update() {
        timeLeft = telemetry.GetComponent<GetTelemetry>().telemData.H2oParams.timeLeft;
        timerText.text = "Time Life Water: " + timeLeft; 
    }
}
