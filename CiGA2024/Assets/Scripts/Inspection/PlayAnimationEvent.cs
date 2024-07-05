using UnityEngine;

public class PlayAnimationEvent : InspectionEvent
{
    public Animator animator;
    public string animationName;

    protected override void TriggerEvent()
    {
        if (animator != null && !string.IsNullOrEmpty(animationName))
        {
            animator.Play(animationName);
            Debug.Log("Playing animation: " + animationName);
        }
    }
}
