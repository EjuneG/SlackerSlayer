using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCUI : MonoBehaviour
{
    public Rulebook ruleBook;
    public GameObject desktopPanel;
    public GameObject inspectionViewPanel;
    public GameObject ruleBookButton;
    public GameObject InspectionButton;
    public GameObject CompanyIntro;
    public UnlockDisplay unlockDisplay;
    public InfoPop InfoPop;

    private void HideEverything(){
        ruleBook.CloseRuleBook();
        desktopPanel.SetActive(false);
        inspectionViewPanel.SetActive(false);
    }
    public void ShowDesktop(){
        HideEverything();
        desktopPanel.SetActive(true);
    }

    public void ShowRuleBook(){
        ruleBook.OpenRuleBook();
    }

    public void ShowInspectionView(){
        HideEverything();
        if(AudioManager.Instance.IsBGMPlayingClip(AudioManager.Instance.BGM.audioClip)){
            //don't play if already playing
        }else{
            AudioManager.Instance.PlayBGM(AudioManager.Instance.BGM.audioClip, AudioManager.Instance.BGM.volume, AudioManager.Instance.BGM.pitch);
        }
        TimeManager.Instance.StartTimer();

        if(TimeManager.Instance.CurrentTime.GameDay == 1) InfoPop.ShowDay1Panel();
        unlockDisplay.UpdateImages();

        inspectionViewPanel.SetActive(true);
    }

    public void HideDesktop(){
        desktopPanel.SetActive(false);
    }

    public void HideRuleBook(){
        ruleBook.CloseRuleBook();
    }

    public void HideInspectionView(){
        inspectionViewPanel.SetActive(false);
    }

    public void ShowCompanyIntro(){
        CompanyIntro.SetActive(true);
    }


}
