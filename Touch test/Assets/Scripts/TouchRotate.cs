using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    private Vector3 touchPosition;
    bool dragging = false;
    Rigidbody rb;
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    private void OnMouseDrag() 
    {
        dragging = true;
    }    

    // Update is called once per frame
    void Update()
    {   
        /*
        if(Input.GetMouseButtonDown(0))
        {
            OnMouseDrag();
        }
        */
        if(Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }
        //Debug.Log(Input.GetAxis("Mouse X"));

    }
    
    public void rotateObject()
    {
        if(Input.touchCount > 0)
        {   
            Touch touch = Input.GetTouch(0);
            touchPosition = Utils.ScreenToWorld(mainCamera, touch.position);

            if(touch.phase == TouchPhase.Moved)
            {
                float x = touch.deltaPosition.x * rotationSpeed * Time.fixedDeltaTime;
                rb.AddTorque(Vector3.down * x); //maybe need Vector3.right
            }
        }
    }
}
