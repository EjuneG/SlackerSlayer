using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
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

    public bool IsRunning {get; private set;}
    [SerializeField] public float TimeSpeed = 1f;
    float timeAccumulator = 0f;
    int dayOfTheWeek = 1; // 1 = Monday, 2 = Tuesday, ..., 7 = Sunday
    int month;

    public GameTime CurrentTime;
    public float InspectionTime => timeAccumulator;

    void Start(){
        CurrentTime = new GameTime(5, 11, 1, 6, 9, 0);
    }
    void Update()
    {
        if(IsRunning){
            timeAccumulator += Time.deltaTime * TimeSpeed;
            //for each second passed, add 1 minute
            if(timeAccumulator >= 1f){
                CurrentTime.Minute++;
                timeAccumulator = 0f;
                //for each minute passed, add 1 hour
                if(CurrentTime.Minute >= 60){
                    CurrentTime.Hour++;
                    CurrentTime.Minute = 0;
                }
            }
            if(CurrentTime >= new GameTime(20,0)){
                //Day Ends
                LevelManager.Instance.EndDay();
            }
        }
    }

    public void StartTimer(){
        IsRunning = true;
    }

    public void StopTimer(){
        IsRunning = false;
    }

    public void Reset(){
        timeAccumulator = 0f;
    }

    public void EndInspection() {
        Reset();
        StopTimer();
        InspectionManager.Instance.ShowDecisionPanel();
    }
}
