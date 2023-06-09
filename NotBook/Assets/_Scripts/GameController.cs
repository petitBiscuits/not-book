using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject spawnpoint;

    public bool isGameStarted = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void StartGame()
    {
        isGameStarted = true;
    }

    public void EnGame()
    {
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
