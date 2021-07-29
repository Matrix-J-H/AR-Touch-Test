using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class CalibrateMap : MonoBehaviour
{   
    public GameObject levelMap;

    private ARRaycastManager arRaycastManager;
    private Vector2 touchPosition;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Vector2 rayOrigin = new Vector2(0f,0f);
    private Vector3 mapHeight;

    // Start is called before the first frame update
    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        levelMap = GameObject.Find("output");
        mapHeight = levelMap.transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {   
        if(arRaycastManager.Raycast(rayOrigin, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if(levelMap != null)
            {
                mapHeight.y = hitPose.position.y;
                levelMap.transform.position = mapHeight;
            }
        }
    }
}
