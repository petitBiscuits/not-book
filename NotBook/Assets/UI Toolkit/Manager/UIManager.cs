using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private UIDocument document;

    private VisualElement _UI;
    private Label _speed;
    private Label _timer;
    private VisualElement _countDown;
    private Label _lblCountDown;

    private void Awake()
    {
        _UI = document.rootVisualElement.Q<VisualElement>("ui");
        _speed = document.rootVisualElement.Q<Label>("speed");
        _timer = document.rootVisualElement.Q<Label>("timer");
        _countDown = document.rootVisualElement.Q<VisualElement>("countDown");
        _lblCountDown = document.rootVisualElement.Q<Label>("lblCountDown");
    }

    private void OnEnable()
    {
        EventManager.SpeedChange += OnSpeedChanged;
        EventManager.TimerChange += OnTimerChanged;
        EventManager.CountDown += OnCountDown;
    }

    private void OnDisable()
    {
        EventManager.SpeedChange -= OnSpeedChanged;
        EventManager.TimerChange -= OnTimerChanged;
        EventManager.CountDown -= OnCountDown;
    }

    private void OnSpeedChanged(float speed)
    {
        _speed.text = speed.ToString("0") + " km/h";
    }

    private void OnTimerChanged(string timer)
    {
        _timer.text = timer + "s";
    }

    public void OnCountDown(int timer)
    {
        _lblCountDown.text = timer.ToString("0");
        if(timer == 0)
        {
            _countDown.style.display = DisplayStyle.None;
            _UI.style.display = DisplayStyle.Flex;
        }
        else
        {
            _UI.style.display = DisplayStyle.None;
            _countDown.style.display = DisplayStyle.Flex;
        }
    }
}
