using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour
{
    public float scrollSpeed = 50f;
    public float timerDuration = 10f;

    [SerializeField]
    private string _sceneName;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        StartCoroutine(TimerRoutine());
    }

    void Update()
    {
        transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime);
    }

    IEnumerator TimerRoutine()
    {
        float timer = timerDuration;        
        yield return new WaitForSeconds(timerDuration);
        SceneManager.LoadScene(_sceneName);
    }
}
