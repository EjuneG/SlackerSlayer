using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionLevel : MonoBehaviour
{
    public int LevelIndex;
    [field: SerializeField] public bool IsSlacker { get; private set; }
    [field: SerializeField] public List<CompanyRule> RulesViolated { get; private set; }

    public InspectionScene InspectionScene {get; private set;}
    
    public void InitializeScene(){
        InspectionScene = GetComponent<InspectionScene>();
    }
}

public enum CompanyRule{
    Eating,
    NotWorking,
    Bathroom,
    InternetUsage
}
