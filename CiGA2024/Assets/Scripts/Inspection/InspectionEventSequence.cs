using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InspectionEventSequence : MonoBehaviour
{
    public GameTime TriggerTime { get; private set; }
    public int triggerHour;
    public int triggerMinute;
    public bool eventTriggered = false;
    public bool IsSlackerEvent = false;
    public bool SlackEventCaught = false;
    public EmployeeSlot ActingEmployee;
    public float EventTimer { get; private set; }
    public bool SequenceCompleted = false;
    public Queue<InspectionEvent> EventsToPlay;
    public Animator animator => ActingEmployee.animator;
    InspectionEvent currentEvent;

    public void Initialize()
    {
        EventsToPlay = new Queue<InspectionEvent>();
        foreach (Transform child in transform)
        {
            InspectionEvent inspectionEvent = child.GetComponent<InspectionEvent>();
            if (ActingEmployee == null)
            {
                Debug.LogError("Slacker Event has no acting employee");
            }
            else
            {
                inspectionEvent.ActingEmployee = this.ActingEmployee;
            }

            if (child.GetComponent<InspectionEvent>() == null)
            {
                Debug.LogError("Inspection Event Sequence has a child that is not an Inspection Event");
            }
            EventsToPlay.Enqueue(inspectionEvent);
        }

        TriggerTime = new GameTime(triggerHour, triggerMinute);
        EventTimer = 0;
    }

    public void Update()
    {
        if (eventTriggered && !SequenceCompleted)
        {
            EventTimer += Time.deltaTime;
            if (EventsToPlay.Count == 0)
            {
                if(currentEvent != null && currentEvent.Completed)
                {
                    Debug.Log("Sequence Completed");
                    SequenceCompleted = true;
                }
            }
            else
            {
                currentEvent = EventsToPlay.Peek();
                currentEvent.CheckAndTrigger();
                if (currentEvent.eventTriggered)
                {
                    EventsToPlay.Dequeue();
                }
            }
        }
    }

    public void CheckAndTrigger(GameTime currentTime)
    {
        if (!eventTriggered && currentTime >= TriggerTime)
        {
            eventTriggered = true;
            if (IsSlackerEvent)
            {
                if (ActingEmployee == null)
                {
                    Debug.LogError("Slacker Event has no acting employee");
                }
                else
                {
                    ActingEmployee.IsSlacking = true;
                }
            }
        }
    }

    public void Caught(){
        SlackEventCaught = true;
        ActingEmployee.IsSlacking = false;
        SequenceCompleted = true;
        currentEvent.Pause();
        ActingEmployee.WorkAfterCaught();
    }
}
