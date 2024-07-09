using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EmployeeAction
{
    public bool IsSlackingAction;
    public string AnimationName;
    public string PCAnimationName;
    public AudioClip SFX;
    public float SFXVolume;
    public float SFXPitch;
    public bool SlackIsCaught;
    public TimePair StartTime;
    public TimePair EndTime;
    public bool HasHint;
    public bool RequireHearing;

    public void Initialize(EmployeeActionSO actionSO, TimePair startTime, TimePair endTime){
        IsSlackingAction = actionSO.IsSlackingAction;
        AnimationName = actionSO.AnimationName;
        PCAnimationName = actionSO.PCAnimationName;
        SFX = actionSO.SFX;
        SFXVolume = actionSO.volume;
        SFXPitch = actionSO.pitch;
        SlackIsCaught = false;
        StartTime = startTime;
        EndTime = endTime;
        HasHint = actionSO.HasHint;
        RequireHearing = actionSO.RequireHearing;

    }

    public void Execute(Animator employeeAnimator, AudioSource employeeAudioSource, GameObject Hint, bool IsVIP = false){
        if(IsSlackingAction && !IsVIP){
            LevelManager.Instance.DailyTotalSlacks++;
            LevelManager.Instance.TotalSlacker++;
        }
        if(AnimationName != ""){
            employeeAnimator.Play(AnimationName);
        }

        if (RequireHearing && !PlayerState.Instance.HearingUnlocked){
            //do nothing
        }
        else if(SFX != null){
            employeeAudioSource.clip = SFX;
            employeeAudioSource.volume = SFXVolume;
            employeeAudioSource.pitch = SFXPitch;
            employeeAudioSource.Play();
        }

        Hint.SetActive(PlayerState.Instance.VisionUnlocked && HasHint);
    }

    public void Complete(Animator employeeAnimator, AudioSource employeeAudioSource, GameObject Hint){
        employeeAnimator?.Play("Idle");
        employeeAudioSource?.Stop();
        employeeAudioSource.clip = null;
        Hint.SetActive(false);

        if(IsSlackingAction && !SlackIsCaught){
            //if complete without caught, record the "failure"
            LevelManager.Instance.DailyMissedSlacks++;
        }
    }
}
