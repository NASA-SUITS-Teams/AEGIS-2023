using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BatteryCap : MonoBehaviour
{
     // Start is called before the first frame update
    public TMP_Text batteryCapText;
    public GameObject telemetry;
    int batteryCap; 

    // Start is called before the first frame update
    void Start()
    {
        batteryCap = telemetry.GetComponent<GetTelemetry>().telemData.batteryParams.capacity;
        displayFunc(batteryCap);
    }

    void Update() {
        batteryCap = telemetry.GetComponent<GetTelemetry>().telemData.batteryParams.capacity;
        displayFunc(batteryCap);
    }

    void displayFunc(double x) {
        batteryCapText.text = "Battery Capacity: " + x.ToString() + " amp-hr";
    }
}
