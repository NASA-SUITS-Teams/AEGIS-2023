using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PrimaryOxygen : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text pOxygenText;
    public GameObject telemetry;
    int pOxygen; 

    // Start is called before the first frame update
    void Start()
    {
        pOxygen = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.primaryPercent;
        displayFunc(pOxygen);
    }

    void Update() {
        pOxygen = telemetry.GetComponent<GetTelemetry>().telemData.oxygenParams.primaryPercent;
        displayFunc(pOxygen);
    }

    void displayFunc(int x) {
        pOxygenText.text = "Primary Oxygen: " + x.ToString() + " %";
    }
}
