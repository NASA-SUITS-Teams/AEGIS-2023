using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BodyTemperature : MonoBehaviour
{
    int bodyTemp;
    public TMP_Text bodyTempText;
    public GameObject telemetry;

    // Start is called before the first frame update
    void Start()
    {
        bodyTemp = 0;
        bodyTempFunc(bodyTemp);
    }

    void bodyTempFunc(int x) {
        bodyTempText.text = "Body Temperature: " + x.ToString() + " Celcius";
    }
}