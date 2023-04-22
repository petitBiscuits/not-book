using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditManager : MonoBehaviour
{
    public float scrollSpeed = 50f;
    public KeyCode resetKey = KeyCode.Space;
    public float resetHoldTime = 2f;
    public Text resetText;
    public float timerDuration = 10f;

    private Vector3 initialPosition;
    private float keyHoldTimer = 0f;
    private int dotCount = 0;
    private Coroutine timerCoroutine;

    void Start()
    {
        initialPosition = transform.position;
        resetText.text = "Espace (Continuer)";
        timerCoroutine = StartCoroutine(TimerRoutine());
    }

    void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);

        if (Input.GetKey(resetKey))
        {
            keyHoldTimer += Time.deltaTime;

            if (keyHoldTimer >= dotCount + 1)
            {
                resetText.text += ".";
                dotCount++;
            }

            if (keyHoldTimer >= resetHoldTime)
            {
                transform.position = initialPosition;
                keyHoldTimer = 0f;
                dotCount = 0;
                resetText.text = "Espace (Continuer)";
                if (timerCoroutine != null)
                {
                    StopCoroutine(timerCoroutine);
                }
                timerCoroutine = StartCoroutine(TimerRoutine());
            }
        }
        else
        {
            keyHoldTimer = 0f;
            dotCount = 0;
            resetText.text = "Espace (Continuer)";
        }
    }

    IEnumerator TimerRoutine()
    {
        float timer = timerDuration;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        // scène suivante
    }
}
