using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HeartRate : MonoBehaviour
{
    // heart rate
    public TMP_Text heartRateText;
    public GameObject telemetry;
    public GameObject Truncater; 
    int heartRate; 

    // Start is called before the first frame update
    void Start()
    {
        heartRate = telemetry.GetComponent<GetTelemetry>().telemData.vitalParams.heart_bpm;
        heartRateFunc(heartRate);
    }

    void Update()
    {
        heartRate = telemetry.GetComponent<GetTelemetry>().telemData.vitalParams.heart_bpm;
        heartRateFunc(heartRate);
    }

    void heartRateFunc(int x) {
        heartRateText.text = "Heart rate: " + Truncater.GetComponent<TruncateStringHelper>().truncateString(x.ToString()) + " BPM";
    }
}