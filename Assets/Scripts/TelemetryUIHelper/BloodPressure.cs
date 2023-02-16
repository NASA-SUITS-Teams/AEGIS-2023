using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BloodPressure : MonoBehaviour
{
    // heart rate
    public int bloodPressure;
    public TMP_Text bloodPressureText;


    // Start is called before the first frame update
    void Start()
    {
        bloodPressureFunc(bloodPressure);
    }

    void bloodPressureFunc(int x) {
        bloodPressureText.text = "Blood pressure: " + x.ToString() + " mmHg";
    }
}
