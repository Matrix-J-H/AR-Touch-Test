using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
//using UnityEngine.UI;

//[RequireComponent(typeof(ARRaycastManager))]
public class SelectionController : MonoBehaviour
{   
    [SerializeField] private Camera arCamera;
    
    private Vector2 touchPosition;
    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hitList = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {   
            Touch touch = Input.GetTouch(0);
            touchPosition = Utils.ScreenToWorld(arCamera, touch.position);

            if(touch.phase == TouchPhase.Moved)
            {
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if(Physics.Raycast(ray, out hitObject))
                {   
                    TouchRotate hittedObject = hitObject.collider.GetComponent<TouchRotate>();
                    if(hittedObject != null)
                    {
                        hittedObject.rotateObject();
                    }
                        
                    
                }
            }
        }
    }   
    
}
