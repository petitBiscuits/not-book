﻿using UnityEngine.Events;

public static class EventManager
{
    public static event UnityAction<float> SpeedChange;
    public static void OnSpeedChange(float f) => SpeedChange?.Invoke(f);

    public static event UnityAction<string> TimerChange;

    public static void OnTimerChange(string s) => TimerChange?.Invoke(s);

    public static event UnityAction<int> CountDown;

    public static void OnCountDown(int s) => CountDown?.Invoke(s);
}
