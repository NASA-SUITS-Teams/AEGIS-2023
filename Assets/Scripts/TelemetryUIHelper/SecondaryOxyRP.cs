using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SecondaryOxyRp : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text secondaryO2RPText;
    public GameObject telemetry;
    public GameObject Truncater;   
    double secondaryO2Rate; 
    int secondaryO2Pressure; 

    // Start is called before the first frame update
    void Start()
    {
        secondaryO2Rate = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.SOPRate;
        secondaryO2Pressure = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.SOPPressure;
        displayFunc(secondaryO2Rate, secondaryO2Pressure);
    }

    void Update()
    {
        secondaryO2Rate = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.SOPRate;
        secondaryO2Pressure = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.SOPPressure;
        displayFunc(secondaryO2Rate, secondaryO2Pressure);
    }

    void displayFunc(double x, int y) {
        secondaryO2RPText.text = "SOP Pressure/Rate: " + y.ToString() +" psia, " + Truncater.GetComponent<TruncateStringHelper>().truncateString(x.ToString()) + " psi/min";
    }
}
