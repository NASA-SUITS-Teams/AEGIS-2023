using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterUserLocalization : MonoBehaviour
{
    [SerializeField]
    private ApplicationReferences appRef;
    [SerializeField] private GameObject[] refPoints;
    private List<GPSCoords> refCoords = new List<GPSCoords>();

    // scaling variables 
    [Header("Scaling Properties")]
    public float realXMeters;
    public float realZMeters;
    private float modelX, modelZ;

    // helper variables for dynamic scaling of map
    private float metersPerLat, metersPerLon, scaleX, scaleZ, insX, insZ;

    public GameObject annotationPin, mapMeshObject;
    private Transform posMarker;
    private Renderer mapRend;

    private void Start()
    {
        posMarker = mapMeshObject.transform.Find("Pos Marker");
        mapRend = mapMeshObject.GetComponent<Renderer>();
        foreach (var point in refPoints)
        {
            refCoords.Add(point.GetComponent<GPSCoords>());
        }

        FindMetersPerLat(refCoords[0].lat);

        // // place all annotation pins
        // foreach (Transform child in appRef.annRoot.transform)
        // {
        //     // AnnotationObject annObj = child.gameObject.GetComponent<AnnotationObject>();
        //     GameObject newPin = Instantiate(annotationPin, transform);
        //     newPin.transform.localPosition = PlaceMarker(annObj.GPSCoords[0], annObj.GPSCoords[1]);
        // }
    }

    // keep updating user location
    private void LateUpdate()
    {
        posMarker.localPosition = PlaceMarker(appRef.GPSCoords[0], appRef.GPSCoords[1]);
    }

    public Vector3 PlaceMarker(float targetLat, float targetLon)
    {
        var bounds = mapRend.bounds;
        modelX = bounds.size.x;
        modelZ = bounds.size.z;
        print("Model Size: " + modelX + ", " + bounds.size.y + ", " + modelZ);
        var localScale = transform.localScale;
        scaleX = modelX / realXMeters / localScale.x;
        scaleZ = modelZ / realZMeters / localScale.z;
        print("Model Scale: " + scaleX + ", " + localScale.y + ", " + scaleZ);

        // set insert value to 0 if close to ref point to avoid float precision error
        if (Mathf.Abs(targetLat - refCoords[0].lat) < 0.00001f)
        {
            insX = 0;
        }
        else
        {
            insX = metersPerLon * (targetLon - refCoords[0].lon) * scaleX;
        }

        if (Mathf.Abs(targetLon - refCoords[0].lon) < 0.00001f)
        {
            insZ = 0;
        }
        else
        {
            insZ = metersPerLat * (targetLat - refCoords[0].lat) * scaleZ;
        }

        // add ref point offset to insX and insZ
        // // top right quadrant
        // if (targetLon > refCoords[0].lon && targetLat > refCoords[0].lat)
        // {
        // }
        // // top left quadrant
        // else if (targetLon < refCoords[0].lon && targetLat > refCoords[0].lat)
        // {
        // }
        // // bottom left quadrant
        // else if (targetLon < refCoords[0].lon && targetLat < refCoords[0].lat)
        // {
        // }
        // // bottom right quadrant
        // else
        // {
        // }
        insX = refPoints[0].transform.localPosition.x + insX;
        insZ = refPoints[0].transform.localPosition.z + insZ;

        return new Vector3(0, insX, insZ);
    }

    // From GPS to UCS library.  Don't touch unless u math god
    private void FindMetersPerLat(float lat) // Compute lengths of degrees
    {
        // Set up "Constants"
        float m1 = 111132.92f;    // latitude calculation term 1
        float m2 = -559.82f;        // latitude calculation term 2
        float m3 = 1.175f;      // latitude calculation term 3
        float m4 = -0.0023f;        // latitude calculation term 4
        float p1 = 111412.84f;    // longitude calculation term 1
        float p2 = -93.5f;      // longitude calculation term 2
        float p3 = 0.118f;      // longitude calculation term 3

        lat = lat * Mathf.Deg2Rad;

        // Calculate the length of a degree of latitude and longitude in meters
        metersPerLat = m1 + (m2 * Mathf.Cos(2 * (float)lat)) + (m3 * Mathf.Cos(4 * (float)lat)) + (m4 * Mathf.Cos(6 * (float)lat));
        metersPerLon = (p1 * Mathf.Cos((float)lat)) + (p2 * Mathf.Cos(3 * (float)lat)) + (p3 * Mathf.Cos(5 * (float)lat));
    }
}
