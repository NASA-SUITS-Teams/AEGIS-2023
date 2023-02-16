using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OxygenRate : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text oxygenRateText;
    public GameObject telemetry;
    public GameObject Truncater;
    double oxygenRate; 

    // Start is called before the first frame update
    void Start()
    {
        oxygenRate = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.oxyRate;
        displayFunc(oxygenRate);
    }

    void Update() {
        oxygenRate = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.oxyRate;
        displayFunc(oxygenRate);
    }

    void displayFunc(double x) {
        oxygenRateText.text = "Oxygen Rate: " + Truncater.GetComponent<TruncateStringHelper>().truncateString(x.ToString()) + " psi/min";
    }
}
