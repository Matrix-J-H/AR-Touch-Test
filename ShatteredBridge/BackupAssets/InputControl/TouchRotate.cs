using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    [SerializeField]private float  rotSpeed;
    private float rotX;
    private Vector3 direction;
    Rigidbody rb;
    //private float rotY;

    public InputManager inputManager;

    private Vector2 startPosition, endPosition;
    private float startTime, endTime;
    private Coroutine coroutine;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += rotateStart;
        inputManager.OnEndTouch += rotateEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= rotateStart;
        inputManager.OnEndTouch -= rotateEnd;
    }

    private void rotateStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
        coroutine = StartCoroutine(Turn(position, time));
    }

    private void rotateEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        StopCoroutine(coroutine);
    }

    private IEnumerator Turn(Vector2 position, float time)
    {
        while(true)
        {   
            float torx = position.x * rotSpeed * Time.deltaTime;

            rb.AddTorque(Vector3.down * torx);
            
            yield return null;
        }
    }
}
