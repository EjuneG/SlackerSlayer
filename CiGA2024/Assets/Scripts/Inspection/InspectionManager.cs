using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;

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


    [SerializeField] GameObject EmployeeParent;
    [SerializeField] List<EmployeeSlot> Employees;
    public List<EmployeeSlot> EmployeeSlots { get; private set; } // Each slot has an Employee and its respective scene

    [SerializeField] SlackOffDecisionPanel decisionPanel;
    [SerializeField] SlackerCamera slackerCam;
    [SerializeField] Transform GameLevelParent;

    [SerializeField] private float falseAlarmPenaltyCooldown = 10;
    private float currentFalseAlarmPenaltyCooldown = 0;

    [SerializeField] Sound caughtSucessSound;
    [SerializeField] Sound falseAlarmSound;

    void Update()
    {
        if (falseAlarmPenaltyCooldown > 0)
        {
            currentFalseAlarmPenaltyCooldown -= Time.deltaTime;
        }
    }


    public void InitializeDay(int day)
    {
        InitializeLevelEmployees(day);
        slackerCam.Initialize();
    }

    void InitializeLevelEmployees(int day)
    //on day 1, initialize first 5 employees, on day 2, have 3 more, day 3, have all
    {
        EmployeeSlots = new List<EmployeeSlot>();
        int employeeCount = 5;
        if (day == 2)
        {
            employeeCount = 7;
        }
        else if (day == 3)
        {
            employeeCount = EmployeeParent.transform.childCount;
        }
        for (int i = 0; i < employeeCount; i++)
        {
            EmployeeSlot slot = Employees[i];
            slot.Index = i;
            EmployeeSlots.Add(slot);
            slot.StartDay();
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
            if (slackerCam.CurrentEmployeeSlot.CurrentAction.SlackIsCaught)
            {
                //already caught, return
                return;
            }
            //caught slacker
            if (slackerCam.CurrentEmployeeSlot.IsVIP)
            {
                PlayerState.Instance.CaughtBossKid = true;
                //no reward
            }
            else
            {
                RewardCaughtSlacker();
                Debug.Log("Caught Slacker!");
                caughtSucessSound.Play();
                slackerCam.CurrentEmployeeSlot.Caught();
            }

            // foreach (InspectionEventSequence sequence in onGoingEventSequences)
            // {
            //     if (sequence.ActingEmployee.Index == slackerCam.CurrentEmployeeSlot.Index)
            //     {
            //         sequence.Caught();
            //     }
            // }
        }
        else
        {
            //false alarm
            Debug.Log("False Alarm");
            if (currentFalseAlarmPenaltyCooldown <= 0)
            {
                falseAlarmSound.Play();
                LevelManager.Instance.DailyEarnedMoney -= 50;
                currentFalseAlarmPenaltyCooldown = falseAlarmPenaltyCooldown;
            }
        }
    }

    private void RewardCaughtSlacker()
    {
        LevelManager.Instance.DailyEarnedMoney += 100;
        LevelManager.Instance.DailySlackerCaught++;
        PlayerState.Instance.TotalCorrectCatch++;
    }

    private void PenalizeFalseAlarm()
    {
        LevelManager.Instance.DailyPenaltyDueToFalseAlarm += 50;
    }

}
