using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class InspectionEvent : MonoBehaviour
{
    public TimePair TriggerTime;
    protected GameTime triggerGameTime { get { return new GameTime(TriggerTime.hour, TriggerTime.minute); } }
    public bool eventTriggered = false;
    public bool RequireVisionBuff = false;
    public bool RequireHearingBuff = false;
    public bool Completed = false;

    protected bool isPaused = false;
    public EmployeeSlot ActingEmployee {get; set;}

    public void CheckAndTrigger()
    {
        if(RequireVisionBuff && PlayerState.Instance.UnleashedLimits.Contains(UnleashedLimit.Vision) == false){
            return;
        }else if(RequireHearingBuff && PlayerState.Instance.UnleashedLimits.Contains(UnleashedLimit.Hearing) == false){
            return;
        }
        if (!eventTriggered && TimeManager.Instance.CurrentTime >= triggerGameTime)
        {
            TriggerEvent(ActingEmployee);
            eventTriggered = true;
        }
    }

    protected abstract void TriggerEvent(EmployeeSlot employeeSlot);

    protected abstract void CompleteEvent();

    public abstract void Pause();
}
