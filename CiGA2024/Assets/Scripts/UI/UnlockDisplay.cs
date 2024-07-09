using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockDisplay : MonoBehaviour
{
    [SerializeField] Sprite LockedVision;
    [SerializeField] Sprite LockedHearing;
    [SerializeField] Sprite UnlockedVision;
    [SerializeField] Sprite UnlockedHearing;

    [SerializeField] Image VisionImage;
    [SerializeField] Image HearingImage;

    public void UpdateImages(){
        VisionImage.sprite = PlayerState.Instance.VisionUnlocked ? UnlockedVision : LockedVision;
        HearingImage.sprite = PlayerState.Instance.HearingUnlocked ? UnlockedHearing : LockedHearing;
    }
}
