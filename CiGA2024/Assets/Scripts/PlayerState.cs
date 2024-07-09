using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private static PlayerState instance;

    public static PlayerState Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerState>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject(typeof(PlayerState).Name);
                    instance = singleton.AddComponent<PlayerState>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return instance;
        }
    }
    //bad habit but saving time
    public GameState CurrentGameState;
   
    
    [field: SerializeField] public bool VisionUnlocked {get; set; }
    [field: SerializeField] public bool HearingUnlocked {get; set;}

    public float Hatred;
    public int TotalMoney;
    public int TotalCorrectCatch;
    public int TotalFalseAlarm;
    public int TotalGoodFeedback;
    public int TotalBadFeedback;
    public bool CaughtBossKid;

    public int MissedSlacks;

    public void Reset(){
        VisionUnlocked = false;
        HearingUnlocked = false;
        Hatred = 0;
        TotalMoney = 0;
        TotalCorrectCatch = 0;
        TotalFalseAlarm = 0;
        TotalGoodFeedback = 0;
        TotalBadFeedback = 0;
    }

    public void ResetGame(){
        Reset();
        TimeManager.Instance.Reset();
    
    }
}

public enum GameState{
    Inspecting,
    Menu
}


