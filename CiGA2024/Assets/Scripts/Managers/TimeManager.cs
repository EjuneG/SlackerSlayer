using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    public SlackWarning slackWarning;
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

    public bool IsRunning { get; private set; }
    [SerializeField] public float TimeSpeed = 1f;
    float timeAccumulator = 0f;
    float inactivityTimer = 0f;
    public float inactivityThreshold = 120f;

    public GameTime CurrentTime;
    public float InspectionTime => timeAccumulator;

    void FixedUpdate()
    {
        if (IsRunning)
        {

        }
    }
    void Update()
    {
        if (IsRunning)
        {
            timeAccumulator += Time.deltaTime * TimeSpeed;

            // Handle time progression
            while (timeAccumulator >= 1f)
            {
                timeAccumulator -= 1f;
                CurrentTime.Minute++;

                // Handle minute to hour progression
                if (CurrentTime.Minute >= 60)
                {
                    CurrentTime.Hour++;
                    CurrentTime.Minute = 0;
                }
            }

            // Check if the game time has reached the end of the day
            if (CurrentTime >= new GameTime(20, 0))
            {
                // Day Ends
                StopTimer();
                LevelManager.Instance.EndDay();
            }

            // Handle player inactivity
            if (IsPlayerActive())
            {
                inactivityTimer = 0f;
            }
            else
            {
                inactivityTimer += Time.deltaTime * TimeSpeed;
                if (inactivityTimer >= inactivityThreshold)
                {
                    slackWarning.ShowAndClose();
                    inactivityTimer = 0f;
                }
            }
        }

        //while time is running, if player does not do anything for 30 minutes (game), play slack warning
    }

    private bool IsPlayerActive()
    {
        //if any key is pressed or mouse clicked, return true
        return Input.anyKey || Input.GetMouseButtonDown(0);
    }

    public void StartTimer()
    {
        IsRunning = true;
    }

    public void StopTimer()
    {
        IsRunning = false;
    }

    public void ToNextDay()
    {
        CurrentTime.ToNextDay();
    }
    public void Reset()
    {
        timeAccumulator = 0f;
        CurrentTime = new GameTime(5, 11, 1, 6, 9, 0);
    }
}
