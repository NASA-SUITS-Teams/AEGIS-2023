using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SuitPressure : MonoBehaviour
{
   // Start is called before the first frame update
    public TMP_Text suitPressureText;
    public GameObject telemetry;
    public GameObject Truncater;   
    double suitPressure; 

    // Start is called before the first frame update
    void Start()
    {
        suitPressure = telemetry.GetComponent<GetTelemetry>().telemData.suitParams.suitPressure;
        sPressureFunc(suitPressure);
    }

    void Update()
    {
        suitPressure = telemetry.GetComponent<GetTelemetry>().telemData.suitParams.suitPressure;
        sPressureFunc(suitPressure);
    }

    void sPressureFunc(double x) {
        suitPressureText.text = "Suit Pressure: " + Truncater.GetComponent<TruncateStringHelper>().truncateString(x.ToString()) + " psid";
    }
}
