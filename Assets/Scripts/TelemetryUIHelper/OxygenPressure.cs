using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OxygenPressure : MonoBehaviour
{
     // Start is called before the first frame update
    public TMP_Text oxygenPressureText;
    public GameObject telemetry;
    public GameObject Truncater;
    double oxygenPressure; 

    // Start is called before the first frame update
    void Start()
    {
        oxygenPressure = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.oxyPressure;
        displayFunc(oxygenPressure);
    }

    void Update() {
        oxygenPressure = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.oxyPressure;
        displayFunc(oxygenPressure);
    }

    void displayFunc(double x) {
        oxygenPressureText.text = "Oxygen Pressure: " + Truncater.GetComponent<TruncateStringHelper>().truncateString(x.ToString()) + " psia";
    }
}
