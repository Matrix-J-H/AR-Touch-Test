using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
//using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]
public class SelectionController : MonoBehaviour
{   
    [SerializeField] private Camera arCamera;

    public GameObject thePlayer;
    private PlayerController hittedPlayer;
    
    float beganTime, endTime;

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
            Ray ray = arCamera.ScreenPointToRay(touch.position);
            RaycastHit hitObject;

            switch(touch.phase)
            {
                case TouchPhase.Began: 
                    beganTime = Time.time;
                    /*
                    if(Physics.Raycast(ray, out hitObject))
                    {
                        if (hitObject.collider.CompareTag("Player"))
                        {
                            hittedPlayer = hitObject.collider.GetComponent<PlayerController>();
                        }
                    }
                    */
                    break;
            
                case TouchPhase.Moved:
                
                    
                    if(Physics.Raycast(ray, out hitObject))
                    {   
                        if (hitObject.collider.CompareTag("Plane") && hittedPlayer == null)
                        {
                            TouchRotate hittedPlane = hitObject.collider.GetComponent<TouchRotate>();
                            if(hittedPlane != null)
                            {
                                hittedPlane.rotateObject(touch);
                            } 
                        }
                    }
                    break;

                case TouchPhase.Stationary:
                /*
                    if(Physics.Raycast(ray, out hitObject))
                    {   
                        if (!hitObject.collider.CompareTag("Player"))
                        {
                            if(hitObject.collider != null)
                            {
                                hittedPlayer.Roll(hitObject.point);
                            } 
                        }

                    }
                    break;
                */
                case TouchPhase.Ended:
                    endTime = Time.time;
                    float touchDuration = endTime - beganTime;
                    /*
                    if(Physics.Raycast(ray, out hitObject))
                    {   
                        if(hitObject.collider.CompareTag("Player") && touchDuration < 0.1f)
                        {
                            if(hittedPlayer != null)
                            {
                                hittedPlayer.Jump(touch);
                            }
                        }
                    }
                    hittedPlayer = null;
                    */
                    Debug.Log("This touch lasted for: " + touchDuration);
                    break;
            }
        }   
    }
}
