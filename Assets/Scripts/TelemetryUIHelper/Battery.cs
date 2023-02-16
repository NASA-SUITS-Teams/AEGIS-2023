using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Battery : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text batteryText;
    public GameObject telemetry;
    public GameObject Truncater;

    double battery; 

    // Start is called before the first frame update
    void Start()
    {
        battery = telemetry.GetComponent<GetTelemetry>().telemData.batteryParams.percentAvailable;
        batteryFunc(battery);
    }

    void batteryFunc(double x) {
        batteryText.text = "Battery: " + Truncater.GetComponent<TruncateStringHelper>().truncateString(x.ToString()) + " %";
    }

    void Update() {
        battery = telemetry.GetComponent<GetTelemetry>().telemData.batteryParams.percentAvailable;
        batteryFunc(battery);
    }
}
