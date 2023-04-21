using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            transform.position += new Vector3(0, 0, 1) * _speed * Time.deltaTime;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            transform.position += new Vector3(0, 0, -1) * _speed * Time.deltaTime;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            transform.position += new Vector3(-1, 0, 0) * _speed * Time.deltaTime;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += new Vector3(1, 0, 0) * _speed * Time.deltaTime;
        }
        if (Keyboard.current.shiftKey.isPressed)
        {
            transform.position += new Vector3(0, -1, 0) * _speed * Time.deltaTime;
        }
        if (Keyboard.current.spaceKey.isPressed)
        {
            transform.position += new Vector3(0, 1, 0) * _speed * Time.deltaTime;
        }
    }
}
