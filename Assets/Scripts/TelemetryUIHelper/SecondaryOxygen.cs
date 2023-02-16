using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SecondaryOxygen : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text sOxygenText;
    public GameObject telemetry;
    int sOxygen; 

    // Start is called before the first frame update
    void Start()
    {
        sOxygen = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.secondaryPercent;
        displayFunc(sOxygen);
    }

    void Update() {
        sOxygen = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.secondaryPercent;
        displayFunc(sOxygen);
    }

    void displayFunc(int x) {
        sOxygenText.text = "Secondary Oxygen: " + x.ToString() + " %";
    }
}
