using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using Microsoft.MixedReality.Toolkit;
using System.Linq;
using TMPro;


public class GetTelemetry : MonoBehaviour
{
    // [SerializeField] private LSAR lsar;
    public serverInfoUnit serverInfo;
    public telemUnit telemData;
    public GPSUnit gpsData;
    private string connectionJsonFilepath;

    TouchScreenKeyboard keyboard;
    public GameObject portTextField;
    public TMP_Text portText;
    bool initialized = false;
    string selected;

    void Start()
    {
        connectionJsonFilepath = Application.persistentDataPath + "/ConnectionInfo.json";
        Debug.Log("Connection saved at: " + connectionJsonFilepath);
        serverInfo = ImportConnectionJson<serverInfoUnit>();
        _Start();
    }

    public void changeRoom(int newRoom)
    {
        StartCoroutine(StopSimulation());
        serverInfo.room = newRoom;
        StartCoroutine(StartSimulation());
    }

    void _Start()
    {
        // StartCoroutine(StopSimulation());
        StartCoroutine(StartSimulation());
        StartCoroutine(GetGPS());
        StartCoroutine(UpdateSimulationState());
        //lsar.StartLSAR(serverInfo);
        SocketIOClient.Instance.StartClient(serverInfo.mlIP);
        print("Start Connection...");
    }

    private void OnApplicationQuit()
    {
        StartCoroutine(StopSimulation());
    }

    IEnumerator UpdateSimulationState()
    {
        for (; ; )
        {
            // Creating URL in loop because room value can change
            String url = $"{serverInfo.api}/api/simulationstate/{serverInfo.room.ToString()}";
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                var text = request.downloadHandler.text;
                //Debug.Log(text);
                telemData = JsonUtility.FromJson<telemUnit>(text);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator GetGPS()
    {
        for (; ; )
        {
            // Creating URL in loop because room value can change
            String url = $"{serverInfo.api}/api/locations/{serverInfo.room.ToString()}";
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();
                if (request.responseCode == 200)
                {
                    var text = request.downloadHandler.text;
                    gpsData = JsonUtility.FromJson<GPSUnit>(text);
                }
            }
        yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator StartSimulation()
    {
        String url = $"{serverInfo.api}/api/simulationcontrol/sim/{serverInfo.room.ToString()}/start";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();
            var text = request.downloadHandler.text;
            //Debug.Log(text);
            telemData = JsonUtility.FromJson<telemUnit>(text);
        }
    }

    IEnumerator StopSimulation()
    {
        String url = $"{serverInfo.api}/api/simulationcontrol/sim/{serverInfo.room.ToString()}/stop";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            //Debug.Log(request.downloadHandler.text);
        }
    }


    void Update()
    {
        if (keyboard != null && selected != null)
        {
            if (!initialized && keyboard.status == TouchScreenKeyboard.Status.Done ||
                Input.GetKeyDown(KeyCode.Return))
            {
                if (selected.Equals("telem"))
                {
                    serverInfo.api = keyboard.text;
                    if (!serverInfo.api.Contains("http"))
                    {
                        serverInfo.api = "http://" + serverInfo.api;
                    }
                    serverInfo.api += ":8080";
                    _Start();
                }
                else if (selected.Equals("ML"))
                {
                    serverInfo.mlIP = keyboard.text;
                    if (!serverInfo.mlIP.Contains("http"))
                    {
                        serverInfo.mlIP = "http://" + serverInfo.mlIP;
                    }
                    serverInfo.mlIP += ":4000";
                    SocketIOClient.Instance.StartClient(serverInfo.mlIP);
                }
                portTextField.SetActive(false);
                UpdateJson<ConnectionManager.ConnectionInfo>();
                keyboard.active = false;
                keyboard = null;
                selected = null;
            }
            if (keyboard.text.Length > 0)
            {
                portText.text = keyboard.text;
            }
        }
    }

    public void ShowKeyboard(string function)
    {
        initialized = false;
        selected = function;
        portTextField.SetActive(true);
        if (function.Equals("telem"))
        {
            portText.text = "Enter Telem API";
        }
        else if (function.Equals("room"))
        {
            portText.text = "Enter Room Number";
        }
        else
        {
            portText.text = "Enter ML API";
        }
        keyboard = TouchScreenKeyboard.Open("");
    }

    public String[] GetDataReading(String feature) {
        if (telemData == null) 
            telemData = new telemUnit(); 
        switch(feature) {
            case "pressure":
                return new string[]{telemData.envParams.subPressure.ToString()};
            case "battery":
                return new string[]{telemData.batteryParams.percentAvailable.ToString()};
            case "oxygen":
                return new string[]{telemData.oxygenParams.primaryPercent.ToString()};                
            case "water":
                return new string[]{telemData.H2oParams.liquidPressure.ToString()};
            case "heart rate":
                return new string[]{telemData.vitalParams.heart_bpm.ToString()};
            case "gas pressure":
            case "oxygen pressure":
                return new string[]{telemData.oxygenParams.oxyPressure.ToString()};
            case "secondary oxygen":
                return new string[]{telemData.oxygenParams.secondaryPercent.ToString()};
            case "temperature":
                return new string[] { telemData.envParams.temperature.ToString() };
                break;
            case "oxygen rate":
                return new string[]{telemData.oxygenParams.oxyRate.ToString()};
            
            default:
                return null;
        }
    }

    public String[] GetDataUnit(String feature) {
        switch(feature) {
            case "pressure":
                return new string[]{"undefined"};
            case "battery":
                return new string[]{"percent"};
            case "oxygen":
                return new string[]{"percent"};                
            case "water":
                return new string[]{"percent"};
            case "heart rate":
                return new string[]{"beat per minute"};
            case "gas pressure":
            case "oxygen pressure":
                return new string[]{"psia"};
            case "secondary oxygen":
                return new string[]{"percent"};
            case "temperature":
                return new string[] { "F" };
            case "oxygen rate":
                return new string[]{"psia/min"};
            
            default:
                return null;
        }
    }

    // helper JSON functions
    public T ImportConnectionJson<T>()
    {
        if (!File.Exists(connectionJsonFilepath))
        {
            File.WriteAllText(connectionJsonFilepath,
                "{\"api\": \"http://172.16.52.165:8080\",\"room\": 1,\"mlIP\": \"http://localhost:4000\"}");
        }
        string jsonText = File.ReadAllText(connectionJsonFilepath);
        return JsonUtility.FromJson<T>(jsonText);
    }

    public void UpdateJson<T>()
    {
        string json = JsonUtility.ToJson(serverInfo);
        File.WriteAllText(connectionJsonFilepath, json);
    }
}
