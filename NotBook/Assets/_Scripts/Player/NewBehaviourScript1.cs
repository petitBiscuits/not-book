using System.Collections;
using UnityEngine;



public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    

    public void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}