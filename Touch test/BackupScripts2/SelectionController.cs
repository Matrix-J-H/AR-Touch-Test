using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

//[RequireComponent(typeof(ARRaycastManager))]
public class SelectionController : MonoBehaviour
{   
    [SerializeField] private Camera arCamera;
    
    private Vector2 touchPosition;
    //private ARRaycastManager arRaycastManager;
    //private static List<ARRaycastHit> hitList = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {   
            Touch touch = Input.GetTouch(0);
            touchPosition = Utils.ScreenToWorld(mainCamera, touch.position);

            if(touch.phase == touchPhase.Moved)
            {
                Ray ray = ar.Camera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if(Physics.Raycast(ray, out hitObject))
                {   
                    GameObject hitObject = hitObject.GetComponent<Collider>().GetComponent<Rotate>();
                    if(hitObject != null)
                    {
                        //Rotate.rotateObject();
                    }
                        
                    
                }
            }
    }   }
}
