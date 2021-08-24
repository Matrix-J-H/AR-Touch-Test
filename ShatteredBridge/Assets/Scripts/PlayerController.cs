using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public bool isGrounded;
    Rigidbody rb;
    public Joystick joystick;
    private float radius;
    [SerializeField] private float rollSpeed, JumpForce;
    float y;

    private Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {   
        mainCamera = Camera.main;
        rb = this.GetComponent<Rigidbody>();
        radius = this.GetComponent<SphereCollider>().radius;
    }

    void OnCollisionStay()
    {
        isGrounded = true; // true if player is collided with the ground
    }

    // Update is called once per frame
    private void FixedUpdate()
    {   
        Roll();
    }

    public void Roll()
    {   
        if(isGrounded)
        {
            Vector3 direction = new Vector3(joystick.Horizontal, 0f, joystick.Vertical); // the bind direction of movement to the joystick
            rb.MovePosition(transform.position + (direction * rollSpeed * Time.deltaTime));
        }
    }

    public void Jump()
    {   
        if(isGrounded)
        {
            rb.AddForce(new Vector3(0f, JumpForce, 0f), ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
