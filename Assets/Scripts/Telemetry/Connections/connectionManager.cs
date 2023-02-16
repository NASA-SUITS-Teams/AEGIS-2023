using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataUnits.serverInfoUnit;

public class ConnectionManager : MonoBehaviour
{
    public serverInfoUnit conInfo;

    private void Awake()
    {
        conInfo = ImportJson<ConnectionInfo>("JSON/ConnectionInfo");
    }
    
    public static T ImportJson<T>(string path)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        return JsonUtility.FromJson<T>(textAsset.text);
    }

    public void UpdateJson<T>()
    {
        string json = JsonUtility.ToJson(conInfo);
    }
}