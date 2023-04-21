using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateManager : MonoBehaviour
{
    [SerializeField]
    public string loadLevel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detect trigger with object
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            SceneManager.LoadScene(loadLevel);
        }   
    }
}
