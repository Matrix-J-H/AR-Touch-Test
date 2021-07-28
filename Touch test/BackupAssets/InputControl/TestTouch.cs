using UnityEngine;

public class TestTouch : MonoBehaviour
{   
    public InputManager inputManager;
    private Camera camera;

    // Start is called before the first frame update
    private void Awake()
    {
        camera = Camera.main;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += Move;
    }

    private void OnDisable()
    {
        inputManager.OnEndTouch -= Move;
    }

    public void Move(Vector2 screenPosition, float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, camera.nearClipPlane);
        Vector3 worldCoordinates = camera.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.z = 0;
        transform.position = worldCoordinates;
    }
}
