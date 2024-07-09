using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPop : MonoBehaviour
{
    public GameObject Day1Panel;
    public GameObject Day3Panel;

    public void ShowDay1Panel(){
        AudioManager.Instance.ReceiveInfoSFX.Play();
        gameObject.SetActive(true);
        Day1Panel.SetActive(true);
    }

    public void ShowDay3Panel(){
        AudioManager.Instance.ReceiveInfoSFX.Play();
        gameObject.SetActive(true);
        Day3Panel.SetActive(true);
    }
}
