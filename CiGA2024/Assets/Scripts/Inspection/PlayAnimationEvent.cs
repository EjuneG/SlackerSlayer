using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayAnimationEvent : InspectionEvent
{
    public Animator animator => ActingEmployee.CharacterAnimator;
    public string animationName;
    public TimePair EndTime;

    protected override void TriggerEvent(EmployeeSlot ActingEmployee)
    {
        if (animator != null && !string.IsNullOrEmpty(animationName))
        {
            StartCoroutine(PlayAnimationForDuration());
            Debug.Log("Playing animation: " + animationName);
        }
    }

    private IEnumerator PlayAnimationForDuration()
    {
        GameTime endTime = new GameTime(EndTime.Hour, EndTime.Minute);

        while (TimeManager.Instance.CurrentTime < endTime && !isPaused)
        {
            animator.Play(animationName);
            yield return null; // Wait for the next frame
        }

        if (!isPaused)
        {
            // Animation has finished looping for the specified duration
            animator.Play("Idle");
            CompleteEvent();
            Debug.Log("Finished playing animation: " + animationName);
        }
        else
        {
            // Handle the animation being paused
            CompleteEvent();
            Debug.Log("Animation paused: " + animationName);
        }
    }

    protected override void CompleteEvent()
    {
        Completed = true;
    }

    public override void Pause()
    {
        Debug.Log("Pause Called!!!");
        isPaused = true;
    }
}
