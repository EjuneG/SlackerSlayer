using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EmployeeSchedule : MonoBehaviour
{
    EmployeeScheduleSO scheduleForTheDay;
    List<EmployeeAction> actionList;
    public Queue<EmployeeAction> ActionQueue;
    public bool ScheduleInitialized = false;

    public void UpdateSchedule(EmployeeScheduleSO schedule){
        scheduleForTheDay = schedule;
        ProcessSchedule();
    }
    public void ProcessSchedule(){
        actionList = new List<EmployeeAction>();
        foreach(ActionAndTime actionAndTime in scheduleForTheDay.Schedule){
            EmployeeAction action = new EmployeeAction();
            if(actionAndTime.action != null){
                action.Initialize(actionAndTime.action, actionAndTime.StartTime, actionAndTime.EndTime);
                actionList.Add(action);
            }
        }
        actionList = actionList.OrderBy(x => x.StartTime.Hour).ThenBy(x => x.StartTime.Minute).ToList();
        ActionQueue = new Queue<EmployeeAction>(actionList);
        ScheduleInitialized = true;
    }
}
