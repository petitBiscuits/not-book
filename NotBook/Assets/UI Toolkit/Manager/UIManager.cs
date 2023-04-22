using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UIDocument document;

    private Label _speed;
    private Label _timer;

    private void Awake()
    {
        _speed = document.rootVisualElement.Q<Label>("speed");
        _timer = document.rootVisualElement.Q<Label>("timer");
    }

    private void OnEnable()
    {
        EventManager.SpeedChange += OnSpeedChanged;
        EventManager.TimerChange += OnTimerChanged;
    }

    private void OnDisable()
    {
        EventManager.SpeedChange -= OnSpeedChanged;
        EventManager.TimerChange -= OnTimerChanged;
    }

    private void OnSpeedChanged(float speed)
    {
        _speed.text = speed.ToString("0") + " km/h";
    }

    private void OnTimerChanged(string timer)
    {
        _timer.text = timer;
    }


}
