using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DayStartTransition : MonoBehaviour
{
    [SerializeField]TMP_Text dateText;
    [SerializeField]TMP_Text dayText;

    public void ShowDayStartTransition()
    {
        GameTime time = TimeManager.Instance.CurrentTime;
        dateText.text = time.Month.ToString("0") + "月" + time.Day.ToString("00") + "日" + "（" + time.GetChineseTimeOfTheWeek() + "）";
        dayText.text = "DAY " + time.GameDay.ToString("00");
        gameObject.SetActive(true);
    }

    //if any key is pressed, close the panel
    void Update()
    {
        if (Input.anyKeyDown)
        {
            CloseDayStartTransition();
        }
    }

    public void CloseDayStartTransition()
    {
        gameObject.SetActive(false);
        SceneManager.Instance.ShowDesktop();
    }
}
