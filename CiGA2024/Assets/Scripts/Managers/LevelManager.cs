using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Initialize();
    }

    public List<InspectionLevel> levels; // Assign this in the Inspector

    public InspectionLevel CurrentLevel { get; private set; }
    public int DailyEarnedMoney;
    public int DailySlackerCaught;
    public int DailyFalseAlarm;
    public int DailyPenaltyDueToFalseAlarm;
    public int DailyPenaltyDueToMissedSlacker;

    public void Initialize(){
        foreach(InspectionLevel level in levels){
            level.InitializeScene();
        }
        
        CurrentLevel = levels[0];
    }

    public void ResetDailyStats(){
        DailyEarnedMoney = 0;
        DailySlackerCaught = 0;
        DailyFalseAlarm = 0;
    }
    public void StartDay(int levelIndex)
    {
        TimeManager.Instance.StartTimer();
        ResetDailyStats();
    }

    public void EndDay()
    {
        SceneManager.Instance.EndDay();
    }
}
