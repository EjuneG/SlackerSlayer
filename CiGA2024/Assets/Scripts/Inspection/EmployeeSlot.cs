using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeSlot : MonoBehaviour
{
    [field: SerializeField]public int Index{get; set;}
    [field: SerializeField]public bool IsSlacking {get; set;}
    [field: SerializeField]public bool SlackCaught {get; set;}
    [field: SerializeField]public bool IsLookedAt {get; set;}

    public Animator animator;

    public void WorkAfterCaught(){
        StartCoroutine(PlayAnimationForDuration("Work", 30f));
    }
    private IEnumerator PlayAnimationForDuration(string animationName, float duration)
    {
        float endTime = Time.time + duration;
        
        while (Time.time < endTime)
        {
            animator.Play(animationName);
            yield return null; // Wait for the next frame
        }

        // Animation has finished looping for the specified duration
        animator.Play("Idle");
        Debug.Log("Finished playing animation: " + animationName);
    }

}
