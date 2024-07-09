using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlackerCamera : MonoBehaviour
{
    public EmployeeSlot CurrentEmployeeSlot{get; private set;}
    public void Initialize(){
        CurrentEmployeeSlot = InspectionManager.Instance.EmployeeSlots[0];
        ShowCurrentEmployee();
    }
    private void ShowCurrentEmployee(){
        //set all employees active
        foreach(EmployeeSlot slot in InspectionManager.Instance.EmployeeSlots){
            slot.gameObject.SetActive(true);
        }

        //put the current employee in front
        CurrentEmployeeSlot.transform.SetAsLastSibling();
        LookAtEmployee(CurrentEmployeeSlot);
    }
    public void ShowNextEmployee(){
        int targetIndex = CurrentEmployeeSlot.Index + 1;

        //if within the limit
        if(targetIndex < InspectionManager.Instance.EmployeeSlots.Count){
            InspectionManager.Instance.EmployeeSlots[CurrentEmployeeSlot.Index + 1].transform.SetAsLastSibling();
            LookAtEmployee(InspectionManager.Instance.EmployeeSlots[CurrentEmployeeSlot.Index + 1]);
            CurrentEmployeeSlot = InspectionManager.Instance.EmployeeSlots[CurrentEmployeeSlot.Index + 1];
        }else{
            InspectionManager.Instance.EmployeeSlots[0].transform.SetAsLastSibling();
            LookAtEmployee(InspectionManager.Instance.EmployeeSlots[0]);
            CurrentEmployeeSlot = InspectionManager.Instance.EmployeeSlots[0];
        }
    }

    public void ShowLastEmployee(){
        int targetIndex = CurrentEmployeeSlot.Index - 1;

        //if within the limit
        if(targetIndex >= 0){
            InspectionManager.Instance.EmployeeSlots[CurrentEmployeeSlot.Index - 1].transform.SetAsLastSibling();
            LookAtEmployee(InspectionManager.Instance.EmployeeSlots[CurrentEmployeeSlot.Index - 1]);
            CurrentEmployeeSlot = InspectionManager.Instance.EmployeeSlots[CurrentEmployeeSlot.Index - 1];
        }else{
            InspectionManager.Instance.EmployeeSlots[InspectionManager.Instance.EmployeeSlots.Count - 1].transform.SetAsLastSibling();
            LookAtEmployee(InspectionManager.Instance.EmployeeSlots[InspectionManager.Instance.EmployeeSlots.Count - 1]);
            CurrentEmployeeSlot = InspectionManager.Instance.EmployeeSlots[InspectionManager.Instance.EmployeeSlots.Count - 1];
        }
    }

    private void LookAtEmployee(EmployeeSlot employeeSlot){
        CurrentEmployeeSlot.IsLookedAt = false;
        CurrentEmployeeSlot.MuteAudioSource();

        employeeSlot.IsLookedAt = true;
        employeeSlot.UnmuteAudioSource();
    }
}
