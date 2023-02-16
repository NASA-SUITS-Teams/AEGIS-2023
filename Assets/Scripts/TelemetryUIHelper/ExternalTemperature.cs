using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ExternalTemperature : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text extTemperatureText;
    public GameObject telemetry;
    public GameObject Truncater;
    double extTemperature; 

    // Start is called before the first frame update
    void Start()
    {
        extTemperature = telemetry.GetComponent<GetTelemetry>().telemData.envParams.temperature;
        displayFunc(extTemperature);
    }

    void Update() {
        extTemperature = telemetry.GetComponent<GetTelemetry>().telemData.envParams.temperature;
        displayFunc(extTemperature);
    }

    void displayFunc(double x) {
        extTemperatureText.text = "External Temperature: " + Truncater.GetComponent<TruncateStringHelper>().truncateString(x.ToString()) + "  Fahrenheit";
    }
}
