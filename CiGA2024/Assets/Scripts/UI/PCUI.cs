using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCUI : MonoBehaviour
{
    public GameObject ruleBookPanel;
    public GameObject desktopPanel;
    public GameObject inspectionViewPanel;
    public GameObject ruleBookButton;
    public GameObject InspectionButton;

    public void OpenRuleBook(){

    }

    private void HideEverything(){
        ruleBookPanel.SetActive(false);
        desktopPanel.SetActive(false);
        inspectionViewPanel.SetActive(false);
    }
    public void ShowDesktop(){
        HideEverything();
        desktopPanel.SetActive(true);
    }

    public void ShowRuleBook(){
        HideEverything();
        ruleBookPanel.SetActive(true);
    }

    public void ShowInspectionView(){
        HideEverything();
        inspectionViewPanel.SetActive(true);
    }

    public void HideDesktop(){
        desktopPanel.SetActive(false);
    }

    public void HideRuleBook(){
        ruleBookPanel.SetActive(false);
    }

    public void HideInspectionView(){
        inspectionViewPanel.SetActive(false);
    }


}
