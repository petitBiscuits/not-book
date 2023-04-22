using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 29;
    public float acceleration = 0.1f;
    Vector2 targetVelocity = new Vector2();

    [Header("Running")]
    public bool canRun = false;
    public bool IsRunning { get; private set; }
    public float runSpeed = 19;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    public static FirstPersonMovement Instance { get; private set; }
    
    
    void Awake()
    {
        Instance = this;
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        if (Keyboard.current.wKey.isPressed)
        {
            if (!Keyboard.current.ctrlKey.isPressed)
            {
                acceleration += 0.1f;
                targetMovingSpeed = speed + acceleration;
            }
            else
            {
                if (acceleration + speed > 0)
                    acceleration -= 0.1f;
                targetMovingSpeed = speed + acceleration;
            }
        }
        else
        {
            if (acceleration + speed > 0)
            {
                acceleration -= 0.1f;
            }
                
            targetMovingSpeed = speed + acceleration;
        }
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, 1 * targetMovingSpeed);
        

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }
}