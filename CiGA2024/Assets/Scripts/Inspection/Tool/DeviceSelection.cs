using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceSelection : MonoBehaviour
{
    public void ChooseVisionDevice(){
        PlayerState.Instance.UnleashedLimits.Add(UnleashedLimit.Vision);
    }

    public void ChooseSoundDevice(){
        PlayerState.Instance.UnleashedLimits.Add(UnleashedLimit.Vision);
    }
}
