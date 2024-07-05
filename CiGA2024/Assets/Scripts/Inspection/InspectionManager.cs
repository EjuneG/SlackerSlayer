using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public List<InspectionEvent> events; // Assign this in the Inspector

    [SerializeField] SlackOffDecisionPanel decisionPanel;

    void Update()
    {
        if (TimeManager.Instance.IsRunning)
        {
            foreach (InspectionEvent inspectionEvent in events)
            {
                inspectionEvent.CheckAndTrigger(TimeManager.Instance.CurrentTime);
            }
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

}
