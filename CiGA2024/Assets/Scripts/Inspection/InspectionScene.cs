using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionScene : MonoBehaviour
{
    [SerializeField]Transform NonVisionBuffVersion;
    [SerializeField]Transform VisionBuffVersion;
    public void LoadScene()
    {
        gameObject.SetActive(true);
        if(PlayerState.Instance.UnleashedLimits.Contains(UnleashedLimit.Vision)){
            ShowVisionBuffVersion();
        }else{
            ShowNonVisionBuffVersion();
        }
    }

    public void CloseScene()
    {
        gameObject.SetActive(false);
    }

    private void ShowVisionBuffVersion()
    {
        NonVisionBuffVersion.gameObject.SetActive(false);
        VisionBuffVersion.gameObject.SetActive(true);
    }

    private void ShowNonVisionBuffVersion()
    {
        NonVisionBuffVersion.gameObject.SetActive(true);
        VisionBuffVersion.gameObject.SetActive(false);
    }
}
