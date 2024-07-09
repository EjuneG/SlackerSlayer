using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] TMP_Text slackerCountText;
    public TMP_Text FeedbackText;

    
    public TMP_Text DateText;
    public TMP_Text GameDayText;

    public string GoodFeedback;
    public string MidFeedback;
    public string BadFeedback;

    public void ShowResult(){
        this.gameObject.SetActive(true);
        GameTime time = TimeManager.Instance.CurrentTime;
        DateText.text = time.Month.ToString("0") + "月" + time.Day.ToString("00") + "日" + "（" + time.GetChineseTimeOfTheWeek() + "）";
        GameDayText.text = "DAY " + time.GameDay.ToString("00");

        string result = "今天你找到了" + LevelManager.Instance.DailySlackerCaught + "名摸鱼员工";
        if(LevelManager.Instance.DailySlackerCaught == LevelManager.Instance.DailyTotalSlacks){
           result = result + "，没有放过任何一条漏网之鱼。";
        }else{
            result = result + "，但仍有" + (LevelManager.Instance.DailyTotalSlacks - LevelManager.Instance.DailySlackerCaught) + "名漏网之鱼。";
        }

        if(LevelManager.Instance.DailySlackerCaught == 0){
            result = "今天你没有找到任何摸鱼员工。";
        }
        slackerCountText.text = result;
        int diff = LevelManager.Instance.DailyTotalSlacks - LevelManager.Instance.DailySlackerCaught;
        Debug.Log("Found:" + LevelManager.Instance.DailySlackerCaught + " Total:" + LevelManager.Instance.DailyTotalSlacks + " Diff:" + diff);
        if(diff <= 1){
            FeedbackText.text = GoodFeedback;
            PlayerState.Instance.TotalGoodFeedback++;
        }else if (diff < 4){
            FeedbackText.text = MidFeedback;
        }else {
            FeedbackText.text = BadFeedback;
            PlayerState.Instance.TotalBadFeedback++;
        }
    }
    void Update(){
        //if any key is pressed, close the panel
        if(Input.anyKeyDown){
            CloseResult();
        }
    }

    public void CloseResult(){
        if(TimeManager.Instance.CurrentTime.GameDay < 3){
            TimeManager.Instance.ToNextDay();
            LevelManager.Instance.StartDay(TimeManager.Instance.CurrentTime.GameDay);
            SceneManager.Instance.EnterDay();
            this.gameObject.SetActive(false);
        }else{
            LevelManager.Instance.EndGame();
        }
    }
}
