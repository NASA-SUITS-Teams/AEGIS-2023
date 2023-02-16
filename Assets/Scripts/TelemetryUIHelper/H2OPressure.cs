using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class H2OPressure : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text h2oPressureText;
    public GameObject telemetry;
    public GameObject Truncater;   
    double h2oGasPressure; 
    double h2oLiquidPressure; 

    // Start is called before the first frame update
    void Start()
    {
        h2oGasPressure = telemetry.GetComponent<GetTelemetry>().telemData.H2oParams.liquidPressure;
        h2oLiquidPressure = telemetry.GetComponent<GetTelemetry>().telemData.H2oParams.gasPressure;
        displayFunc(h2oGasPressure, h2oLiquidPressure);
    }

    void Update()
    {
        h2oGasPressure = telemetry.GetComponent<GetTelemetry>().telemData.H2oParams.gasPressure;
        h2oLiquidPressure = telemetry.GetComponent<GetTelemetry>().telemData.H2oParams.liquidPressure;
        displayFunc(h2oGasPressure, h2oLiquidPressure);
    }

    void displayFunc(double x, double y) {
        h2oPressureText.text = "H2O Gas Pressure: " + Truncater.GetComponent<TruncateStringHelper>().truncateString(x.ToString()) +" psia \n" + 
                                "H2O Liquid Pressure: " + Truncater.GetComponent<TruncateStringHelper>().truncateString(y.ToString()) +" psia";
    }
}
