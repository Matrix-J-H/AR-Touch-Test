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

    // Update is called once per frame
    public void rotateObject(Touch touch)
    {   
        //touchPosition = Utils.ScreenToWorld(mainCamera, touch.position);

        if(touch.phase == TouchPhase.Moved)
        {
            float x = Mathf.Max(touch.deltaPosition.x, touch.deltaPosition.y) * rotationSpeed * Time.deltaTime;
            rb.AddTorque(Vector3.down * x); //maybe need Vector3.right
        }
    }
}
