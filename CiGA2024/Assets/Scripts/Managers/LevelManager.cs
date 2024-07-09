using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Playables;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start(){
        StartGame();
    }



    public InspectionLevel CurrentLevel { get; private set; }
    public int DailyEarnedMoney;
    public int DailySlackerCaught;
    public int DailyFalseAlarm;
    public int DailyPenaltyDueToFalseAlarm;
    public int DailyPenaltyDueToMissedSlacker;
    public int TotalSlacker;

    public int DailyTotalSlacks;
    public int DailyMissedSlacks;
    public bool IntroducedCompany;
    public bool UnlockedFirst;
    public bool UnlockedSecond;


    public void ResetDailyStats(){
        DailyEarnedMoney = 0;
        DailySlackerCaught = 0;
        DailyFalseAlarm = 0;
        DailyPenaltyDueToFalseAlarm = 0;
        DailyPenaltyDueToMissedSlacker = 0;
        DailyTotalSlacks = 0;
        DailyMissedSlacks = 0;
    }

    public void InitializeValues(){
        DailyEarnedMoney = 0;
        DailySlackerCaught = 0;
        DailyFalseAlarm = 0;
        DailyPenaltyDueToFalseAlarm = 0;
        DailyPenaltyDueToMissedSlacker = 0;
        IntroducedCompany = false;
        TotalSlacker = 0;
    }

    public void StartGame(){
        TimeManager.Instance.Reset();
        StartDay(1);
        InitializeValues();
        SceneManager.Instance.ShowMainMenu();
    }
    public void StartDay(int gameDay)
    {
        InspectionManager.Instance.InitializeDay(gameDay);
        ResetDailyStats();

        if (gameDay == 3)
        {
            PlayerState.Instance.VisionUnlocked = true;
            PlayerState.Instance.HearingUnlocked = true;
            
        }
    }

    public void EndDay()
    {
        SceneManager.Instance.ShowDayResult();
    }

    public void EndGame(){
        Result result = CalculateResult();

        SceneManager.Instance.ShowEndGame(result);
    }

    private Result CalculateResult(){
        if(PlayerState.Instance.TotalFalseAlarm > 10){
            return Result.Failure;
        }

        if(LevelManager.Instance.TotalSlacker - PlayerState.Instance.TotalCorrectCatch < 5){
            return Result.GoodGuesser;
        }

        if(PlayerState.Instance.TotalCorrectCatch < 10 && PlayerState.Instance.TotalFalseAlarm < 3){
            return Result.NicePerson;
        }

        return Result.Slacker;
    }
}

public enum Result{
    Failure,
    GoodGuesser,
    NicePerson,
    HighEQ,

    Slacker

}
