// test.cs
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


public class Logging : MonoBehaviour 
{
    // TODO: what are the object classes for each????
    // running list of objects for "Activities_Log"
    // running list of objects for "Telemetry_Log"
    // running list of objects for "Rock_Data"
    private List<> list_activities = new List<>();
    private List<> list_telemetry = new List<>();
    private List<> list_rock = new List<>();

    private string path_activities = "";
    private string path_telemetry = "";
    private string path_rock = "";


    // Notes:
        // Saves to "Application.persistentDataPath"
        // "Activities_Log", "Telemetry_Log", "Rock_Data"
        // Use JsonHelper instead of JSONUtility
        // Keeps a running list, then update everytime we receive new data
        // adds timestamp to the file name when initializing new list (at Start())
            // to prevent overwriting of previous data if HoloLens stops (loses lists) then starts (empty lists) and receives new data
            // e.g., "Activities_Log_2-15_2000" for Feb 15, 8 PM
        // Process:
            // GetTelem gets the raw json telemetry objects 
            // --> parse it somehow
            // --> store it nicely into the organized classes
            // --> depending on how they structure telemetry stream, get it here and store it directly into the lists and write to the logging files
        // if UI needs any of the data, they should be avail to retrive from the neat classes
        // DATA CAVEATS for Application.persistentDataPath:
            // data will be removed if app is removed
            // data will be removed if redeployed
        // ACCESS CAVEATS for Application.persistentDataPath:
            // NOT accessible through file explorer
            // accessible through Windows Device Portal


    // TODO: check everything works
    // TODO: take NASA's json object classes and put them into "Activity", "Telemetry", "RockData"
        // but! depends on how they structure the telemetry stream
    // TODO: add anomaly checker as you parse NASA's json objects into Rohan's nicely neatly organized classes


    void Start()
    {
        string time = DateTime.Now.ToString("_yyyy-MM-dd_HH-mm-ss-fff");
        path_activities = Path.Combine(Application.persistentDataPath, "Activities_Log" + time + ".json");
        path_telemetry = Path.Combine(Application.persistentDataPath, "Telemetry_Log" + time + ".json");
        path_rock = Path.Combine(Application.persistentDataPath, "Rock_Data" + time + ".json");
        
    }
    

    public class TestJsonObject
    {
        public string str = "testtest";
    }


    // for TESTING! It overwrites all files with "testtest"
        // courtesy of: https://www.appzinside.com/2018/08/06/hololens-and-unity-tip-004-storing-and-retrieving-data-on-hololens-device-storage/
    public void overwriteAll()
    {
        // string json = JsonUtility.ToJson(testObject);
        TestJsonObject testObject = TestJsonObject();
        string json = JsonConvert.SerializeObject(testObject);
        byte[] data = Encoding.ASCII.GetBytes(json);
        UnityEngine.Windows.File.WriteAllBytes(path_activities, testObject);
        UnityEngine.Windows.File.WriteAllBytes(path_telemetry, testObject);
        UnityEngine.Windows.File.WriteAllBytes(path_rock, testObject);
        
    }
    // overloaded function for overwriting file w/ list (since we keep a running list, and overwrite each time to update)
        // TODO: add Activity/Telemetry/Rock object class type here
        // overwrites one of the three files, depending on the data type it is given
            // given ActivityClass --> "Activities_Log" file, etc.
    public void overwriteFile(actData) 
    {
        // add to running list
        list_activities.add(actData);
        // turn updated list into json, then bytes
        string json = JsonUtility.ToJson(list_activities);
        byte[] data = Encoding.ASCII.GetBytes(json);
        // overwrite the Activities_Log file w/ the updated list
        UnityEngine.Windows.File.WriteAllBytes(path_act, data);
    }
    public void overwriteFile(telemData) 
    {
        // add to running list
        list_telemetry.add(telemData);
        // turn updated list into json, then bytes
        string json = JsonConvert.SerializeObject(list_telemetry);
        byte[] data = Encoding.ASCII.GetBytes(json);
        // overwrite the Telemetry_Log file w/ the updated list
        UnityEngine.Windows.File.WriteAllBytes(path_telemetry, data);
    }
    public void overwriteFile(rockData) 
    {
        // add to running list
        list_rock.add(rockData);
        // turn updated list into json, then bytes
        string json = JsonConvert.SerializeObject(list_rock);
        byte[] data = Encoding.ASCII.GetBytes(json);
        // overwrite the Rock_Data file w/ the updated list
        UnityEngine.Windows.File.WriteAllBytes(path_rock, data);
    }

}


