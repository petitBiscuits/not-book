using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 10;
    public float maxSpeed = 13;
    
    public float acceleration = 0.1f;
    public float accelerationSpeed = 0.01f;

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
        // Get targetMovingSpeed.
        float targetMovingSpeed = speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        if (Keyboard.current.wKey.isPressed)
        {
            if (!Keyboard.current.ctrlKey.isPressed)
            {
                if (maxSpeed > speed + acceleration)
                {
                    acceleration += accelerationSpeed;
                }
                targetMovingSpeed = speed + acceleration;
            }
            else
            {
                if (0 < acceleration + speed)
                    acceleration -= accelerationSpeed;
                targetMovingSpeed = speed + acceleration;
            }
        }
        else
        {
            if (acceleration + speed > 0)
            {
                acceleration -= accelerationSpeed;
            }
                
            targetMovingSpeed = speed + acceleration;
        }
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, 1 * targetMovingSpeed);
        

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }
}