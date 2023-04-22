using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCast : MonoBehaviour
{
    [SerializeField]
    public float range = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }   

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if (Keyboard.current.fKey.isPressed)
        {
            if(Physics.Raycast(theRay, out RaycastHit hit, range))
            {
                if(hit.collider.tag == "Chest")
                {
                    Debug.Log("Chest");
                }
            }
        }
    }
}
