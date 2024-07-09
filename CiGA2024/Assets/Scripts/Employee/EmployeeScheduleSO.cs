using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmployeeScheduleSO", menuName = "ScriptableObjects/EmployeeScheduleSO", order = 1)]
public class EmployeeScheduleSO : ScriptableObject
{
    public List<ActionAndTime> Schedule;
}

[System.Serializable]
public struct ActionAndTime{
    public EmployeeActionSO action;
    public TimePair StartTime;
    public TimePair EndTime;
}
