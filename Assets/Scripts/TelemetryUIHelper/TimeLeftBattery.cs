using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeLeftBattery : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject telemetry;
    string timeLeft; 

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = telemetry.GetComponent<GetTelemetry>().telemData.batteryParams.timeLeft;
        timerText.text = "Time Left Battery: " + timeLeft;
    }

    void Update() {
        timeLeft = telemetry.GetComponent<GetTelemetry>().telemData.batteryParams.timeLeft;
        timerText.text = "Time Left Battery: " + timeLeft; 
    }
}
