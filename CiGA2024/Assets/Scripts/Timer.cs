using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerValueText;
    public bool Running { get => TimeManager.Instance.IsRunning; }

    void Update() {
        timerValueText.text = TimeManager.Instance.CurrentTime.ToString("F0");
    }

    public void Reset() {
        TimeManager.Instance.Reset();
    }
}
