using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FanVelocity : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text velText;
    public GameObject telemetry;
    int fanVel; 

    // Start is called before the first frame update
    void Start()
    {
        fanVel = telemetry.GetComponent<GetTelemetry>().telemData.suitParams.fan_tach;
        displayFunc(fanVel);
    }

    void Update()
    {
        fanVel = telemetry.GetComponent<GetTelemetry>().telemData.suitParams.fan_tach;
        displayFunc(fanVel);
    }

    void displayFunc(int x) {
        velText.text = "Fan Velocity: " + x.ToString() + " RPM";
    }
}
