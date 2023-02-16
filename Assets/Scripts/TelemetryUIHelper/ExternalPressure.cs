using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ExternalPressure : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text extPressureText;
    public GameObject telemetry;
    public GameObject Truncater;   
    double extPressure; 

    // Start is called before the first frame update
    void Start()
    {
        extPressure = telemetry.GetComponent<GetTelemetry>().telemData.envParams.subPressure;
        displayFunc(extPressure);
    }

    void Update()
    {
        extPressure = telemetry.GetComponent<GetTelemetry>().telemData.envParams.subPressure;
        displayFunc(extPressure);
    }

    void displayFunc(double x) {
        extPressureText.text = "External Pressure: " + Truncater.GetComponent<TruncateStringHelper>().truncateString(x.ToString()) + " psia";
    }
}
