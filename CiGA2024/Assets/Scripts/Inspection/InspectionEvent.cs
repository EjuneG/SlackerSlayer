using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InspectionEvent : MonoBehaviour
{
    public float triggerTime;
    public bool eventTriggered = false;

    public void CheckAndTrigger(float currentTime)
    {
        if (!eventTriggered && currentTime >= triggerTime)
        {
            TriggerEvent();
            eventTriggered = true;
        }
    }

    protected abstract void TriggerEvent();
}
