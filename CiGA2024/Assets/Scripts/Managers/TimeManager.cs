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

    public float CurrentTime{get => timeAccumulator;}
    void Update()
    {
        if(IsRunning){
            timeAccumulator += Time.deltaTime * TimeSpeed;
            if(CurrentTime >= 3f){
                EndInspection();
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
