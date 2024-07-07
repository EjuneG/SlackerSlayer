using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayStartTransition : MonoBehaviour
{
    TMP_Text dateText;
    TMP_Text dayText;

    public void ShowDayStartTransition()
    {
        GameTime time = TimeManager.Instance.CurrentTime;
        dateText.text = time.Month.ToString("0") + "月" + time.Day.ToString("00") + "日" + "（" + time.GetChineseTimeOfTheWeek() + "）";
        dayText.text = "DAY" + time.Day.ToString("00");
        gameObject.SetActive(true);
    }
}