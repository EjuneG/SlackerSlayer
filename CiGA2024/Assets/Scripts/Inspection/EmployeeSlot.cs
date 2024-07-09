using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeSlot : MonoBehaviour
{
    [field: SerializeField] public int Index { get; set; }
    [field: SerializeField] public bool IsSlacking { get; set; }
    [field: SerializeField] public bool SlackCaught { get; set; }
    [field: SerializeField] public bool IsLookedAt { get; set; }
    public bool IsVIP; //vip aint give a shit
    public Animator CharacterAnimator;
    public AudioSource AudioSource;
    public EmployeeAction CurrentAction;
    public EmployeeSchedule ScheduleForTheDay;
    public EmployeeScheduleSO Day1ScheduleSO;
    public EmployeeScheduleSO Day2ScheduleSO;
    public EmployeeScheduleSO Day3ScheduleSO;

    public EmployeeActionSO BustedAction;
    public EmployeeActionSO WorkAction;
    public GameObject Hint;

    private TimePair currentTime => TimeManager.Instance.CurrentTime.TimePair;

    void Update()
    {
        if (TimeManager.Instance.IsRunning && ScheduleForTheDay.ScheduleInitialized)
        {
            if(ScheduleForTheDay.ActionQueue.Count == 0){
                return;
            }
            TimePair startTime = ScheduleForTheDay.ActionQueue.Peek().StartTime;
            GameTime startGameTime = new GameTime(startTime.Hour, startTime.Minute);
            if (TimeManager.Instance.CurrentTime >= startGameTime)
            {
                CurrentAction = ScheduleForTheDay.ActionQueue.Dequeue();
                if (CurrentAction.IsSlackingAction)
                {
                    IsSlacking = true;
                }else{
                    IsSlacking = false;
                }

                CurrentAction.Execute(CharacterAnimator, AudioSource, Hint, IsVIP);
            }
        }

        if(!IsLookedAt){
            AudioSource.mute = true;
        }else{
            AudioSource.mute = false;
        }
    }

    public void StartDay()
    {
        IsSlacking = false;
        SlackCaught = false;
        IsLookedAt = false;

        switch(TimeManager.Instance.CurrentTime.GameDay){
            case 1:
                AssignSchedule(Day1ScheduleSO);
                break;
            case 2:
                AssignSchedule(Day2ScheduleSO);
                break;
            case 3:
                AssignSchedule(Day3ScheduleSO);
                break;
        }
    }

    public void AssignSchedule(EmployeeScheduleSO schedule){
        if(schedule == null){
            Debug.LogError(gameObject.name + ": Schedule is null");
        }
        ScheduleForTheDay.UpdateSchedule(schedule);
    }

    public void Caught(){
        CurrentAction.SlackIsCaught = true; // just to make sure
        CurrentAction.Complete(CharacterAnimator, AudioSource, Hint);
        IsSlacking = false;
        Busted();
    }

    //Play a sequence of actions, first busted, then work
    public void Busted(){
        EmployeeAction bustedAction = new EmployeeAction()
        {
            IsSlackingAction = false,
            AnimationName = BustedAction.AnimationName,
            PCAnimationName = BustedAction.PCAnimationName,
            SFX = BustedAction.SFX,
            SFXVolume = BustedAction.volume,
            SFXPitch = BustedAction.pitch,
            SlackIsCaught = false,
            StartTime = currentTime,
            EndTime = new TimePair(currentTime.Hour, currentTime.Minute + 5)
        };

        bustedAction.Execute(CharacterAnimator, AudioSource, Hint);
    }

    public void MuteAudioSource(){
        AudioSource.mute = true;
    }

    public void UnmuteAudioSource(){
        AudioSource.mute = false;
    }

}
