using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text dateText;
    [SerializeField] TMP_Text timerValueText;
    public bool Running { get => TimeManager.Instance.IsRunning; }

    void Update() {
        GameTime time = TimeManager.Instance.CurrentTime;
        dateText.text = time.Month.ToString("0") + "月" + time.Day.ToString("00") + "日" + "（" + time.GetChineseTimeOfTheWeek() + "）";
        timerValueText.text = time.Hour.ToString("D2") + ":" + time.Minute.ToString("D2");
    }

    public void Reset() {
        TimeManager.Instance.Reset();
    }
}
