using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{   
    //using event so other scripts can subscribe to these events without reference to this script directly.
    #region 
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;
    #endregion
    private TouchControls touchControls;
    private Camera mainCamera;

    private void Awake()
    {
        touchControls = new TouchControls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        touchControls.Enable();

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    private void OnDisable()
    {
        touchControls.Disable();

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void Start() //run when player start pressing the screen
    {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);

    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch started" + touchControls.Touch.TouchPosition.ReadValue<Vector2>());
        if (OnStartTouch != null) //if this event is subscribed by something
        {
            OnStartTouch(Utils.ScreenToWorld(mainCamera, touchControls.Touch.TouchPosition.ReadValue<Vector2>()), (float)context.startTime);
        }
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        Debug.Log("Touch ended");
        if (OnEndTouch != null) //if this event is subscribed by something
        {
            OnEndTouch(Utils.ScreenToWorld(mainCamera, touchControls.Touch.TouchPosition.ReadValue<Vector2>()), (float)context.time);
        }
    }

    public Vector2 TouchPosition()
    {
        return Utils.ScreenToWorld(mainCamera, touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    }

    private void FingerDown(Finger finger)
    {
        if (OnStartTouch != null) 
        {
            OnStartTouch(finger.screenPosition, (float)Time.time);
        }
    }
}
