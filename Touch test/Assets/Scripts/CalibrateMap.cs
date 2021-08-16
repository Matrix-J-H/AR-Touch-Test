using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARSessionOrigin))]
public class CalibrateMap : MonoBehaviour
{   
    public GameObject levelMap;
    private Transform sessionTransform;
    private ARSessionOrigin mySessionOrigin;

    // Start is called before the first frame update
    private void Awake()
    {
        sessionTransform = transform;
        mySessionOrigin = GetComponent<ARSessionOrigin>();
    }

    void OnPositionContent()
    {
        Vector3 pos = new Vector3 (sessionTransform.position.x - 20f, sessionTransform.position.y - 30f, sessionTransform.position.z - 30f);
        Vector3 rot = new Vector3 (sessionTransform.rotation.x - 90, sessionTransform.position.y - 90, sessionTransform.position.z);
        mySessionOrigin.MakeContentAppearAt(levelMap.transform, pos, Quaternion.Euler(rot));
        DisablePlanes();
    }

    void DisablePlanes()
    {
        ARPlaneManager planeManager = GetComponent<ARPlaneManager>();
        List<ARPlane> allPlanes = new List<ARPlane>();
        planeManager.enabled = false;
        foreach (ARPlane plane in allPlanes)
        {
            plane.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    private void Start()
    {   
        OnPositionContent();
    }
}
