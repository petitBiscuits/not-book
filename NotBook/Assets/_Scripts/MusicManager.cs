using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    [SerializeField]
    private AudioSource Music;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    void Start()
    {
        Music.Play();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
