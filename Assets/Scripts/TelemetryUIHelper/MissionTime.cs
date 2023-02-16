using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MissionTime : MonoBehaviour
{
    // Start is called before the first frame update
    // time will be available on inspector for users to input as needed
    // public int time;

    // Drag the relevant textmeshPro to the script to activate the function
    public TMP_Text timerText;
    public GameObject telemetry;
    string missionTimer; 

    // Start is called before the first frame update
    void Start()
    {
        missionTimer = telemetry.GetComponent<GetTelemetry>().telemData.clockParams.EVATime;
    }

    void Update() {
        missionTimer = telemetry.GetComponent<GetTelemetry>().telemData.clockParams.EVATime;
        timerText.text = "EVA Elapsed Time: " + missionTimer; 
    }
}
