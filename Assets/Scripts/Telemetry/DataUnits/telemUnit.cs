using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using Microsoft.MixedReality.Toolkit;
using System.Linq;
using Parameters.state;
using Parameters.clock;
using Parameters.oxygen;
using Parameters.battery;
using Parameters.environment;
using parameters.suit;
using Parameters.water;
using Parameters.vital;
using TMPro;

[Serializable]
public class telemUnit : MonoBehaviour
{
    public int id;

    public state stateParams;

    public clock timeParams;

    public oxygen oxygenParams;

    public battery batteryParams;

    public environment envParams;

    public water H2oParams;

    public vital vitalParams;

    public suit suitParams;

    public timeStampUnit timeStamp;
}
