using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

    [Header("Timer Settings")]
    public float currentTime;
    public int countdownTime = 3;

    public bool StartTimer { get; set; }

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
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
        {
            currentTime += Time.deltaTime;
            EventManager.OnTimerChange(currentTime.ToString("0.0"));
        }
    }

    public void Restart()
    {
        this.StartTimer = false;
        GameController.Instance.EnGame();
        countdownTime = 3;
        currentTime = 0f;
        EventManager.OnTimerChange(currentTime.ToString("0.0"));
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            EventManager.OnCountDown(countdownTime);
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        EventManager.OnCountDown(countdownTime);

        // GO !
        this.StartTimer = true;
        GameController.Instance.StartGame();
    }
}
