using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionDecision : MonoBehaviour
{
    public void ChooseSlackOff(){
        FinishInspection();
    }

    public void ChooseNotSlackOff(){
        FinishInspection();
    }

    public void FinishInspection(){
        LevelManager.Instance.GoToNextLevel();
        InspectionManager.Instance.HideDecisionPanel();
    }
}
