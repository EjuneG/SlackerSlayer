using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InspectionManager : MonoBehaviour
{
    public static InspectionManager Instance { get; private set; }
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

    public Queue<InspectionEventSequence> EventSequenceQueue; // Saves the events that will happen in the level
    public List<InspectionEventSequence> EventSequences; // Assign this in the Inspector
    List<InspectionEventSequence> onGoingEventSequences;

    [SerializeField] GameObject EmployeeParent;
    public List<EmployeeSlot> EmployeeSlots { get; private set; } // Each slot has an Employee and its respective scene

    [SerializeField] SlackOffDecisionPanel decisionPanel;
    [SerializeField] SlackerCamera slackerCam;
    [SerializeField] Transform GameLevelParent;

    [SerializeField]private float falseAlarmPenaltyCooldown = 10;
    private float currentFalseAlarmPenaltyCooldown = 0;

    void Update()
    {
        if (TimeManager.Instance.IsRunning)
        {
            if (EventSequenceQueue.Count > 0)
            {
                InspectionEventSequence currentSequence = EventSequenceQueue.Peek();
                currentSequence.CheckAndTrigger(TimeManager.Instance.CurrentTime);
                if (currentSequence.eventTriggered)
                {
                    onGoingEventSequences.Add(currentSequence);
                    EventSequenceQueue.Dequeue();
                }
            }

            for (int i = onGoingEventSequences.Count - 1; i >= 0; i--)
            {
                InspectionEventSequence sequence = onGoingEventSequences[i];
                sequence.Update();
                if (sequence.SequenceCompleted)
                {
                    onGoingEventSequences.RemoveAt(i);
                }
            }

            if(falseAlarmPenaltyCooldown > 0){
                falseAlarmPenaltyCooldown -= Time.deltaTime;
            }
        }
    }

    void Start()
    {
        InitializeLevelEmployees();
        InitializeDay();
        slackerCam.Initialize();
    }

    void InitializeDay()
    {
        EventSequences = new List<InspectionEventSequence>();
        foreach (Transform child in GameLevelParent)
        {
            InspectionEventSequence sequence = child.GetComponent<InspectionEventSequence>();
            if (sequence != null)
            {
                EventSequences.Add(sequence);
            }
        }
        foreach (InspectionEventSequence sequence in EventSequences)
        {
            sequence.Initialize();
        }
        onGoingEventSequences = new List<InspectionEventSequence>();
        //Sort event sequences by their trigger time, and then add them to the event queue, so they are triggered in order
        EventSequenceQueue = new Queue<InspectionEventSequence>(EventSequences.OrderBy(x => x.TriggerTime));
    }

    void InitializeLevelEmployees()
    {
        EmployeeSlots = new List<EmployeeSlot>();
        for (int i = 0; i < EmployeeParent.transform.childCount; i++)
        {
            EmployeeSlot slot = EmployeeParent.transform.GetChild(i).GetComponent<EmployeeSlot>();
            slot.Index = i;
            EmployeeSlots.Add(slot);
        }
    }

    public void ShowDecisionPanel()
    {
        decisionPanel.ShowPanel();
    }

    public void HideDecisionPanel()
    {
        decisionPanel.HidePanel();
    }

    public void ReportSlacker()
    {
        if (slackerCam.CurrentEmployeeSlot.IsSlacking)
        {
            //caught slacker
            RewardCaughtSlacker();
            Debug.Log("Caught Slacker!");
            foreach (InspectionEventSequence sequence in onGoingEventSequences)
            {
                if (sequence.ActingEmployee.Index == slackerCam.CurrentEmployeeSlot.Index)
                {
                    sequence.Caught();
                }
            }
        }else{
            //false alarm
            Debug.Log("False Alarm");
            if(currentFalseAlarmPenaltyCooldown <= 0){
                LevelManager.Instance.DailyEarnedMoney -= 50;
                currentFalseAlarmPenaltyCooldown = falseAlarmPenaltyCooldown;
            }
        }
    }

    private void RewardCaughtSlacker(){
        LevelManager.Instance.DailyEarnedMoney += 100;
        LevelManager.Instance.DailySlackerCaught++;
    }

    private void PenalizeFalseAlarm(){
        LevelManager.Instance.DailyPenaltyDueToFalseAlarm += 50;
    }

}
