﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 10;
    public float maxSpeed = 13;
    
    public float acceleration = 0f;
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
        float targetMovingSpeed = GameController.Instance.isGameStarted ? 0 : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        if (Keyboard.current.wKey.isPressed && GameController.Instance.isGameStarted)
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
        EventManager.OnSpeedChange(rigidbody.velocity.magnitude);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "mort")
        {
            Respawn();
        }
        if (collision.collider.tag == "end")
        {
            SceneManager.LoadScene("HistoireScene");
        }
        if (collision.collider.tag == "Wall" || collision.collider.tag == "dogo")
        {
            this.speed = 1f;
            this.acceleration = 0f;
        }
    }

    public void Respawn()
    {
        this.transform.position = GameController.Instance.spawnpoint.transform.position;
        this.speed = 0f;
        this.acceleration = 0f;
        Timer.Instance.Restart();
    }
}