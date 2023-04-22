using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditManager : MonoBehaviour
{
    public float scrollSpeed = 50f;
    public float timerDuration = 10f;

    private Vector3 initialPosition;
    private Coroutine timerCoroutine;

    void Start()
    {
        initialPosition = transform.position;
        timerCoroutine = StartCoroutine(TimerRoutine());
    }

    void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }

    IEnumerator TimerRoutine()
    {
        float timer = timerDuration;        
        yield return new WaitForSeconds(timerDuration);
        // scène suivante
    }
}
