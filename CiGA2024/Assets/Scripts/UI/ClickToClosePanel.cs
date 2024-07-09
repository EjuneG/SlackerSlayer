using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToClosePanel : MonoBehaviour
{
    public bool ClickEdgeToClose = false;
    public bool PauseTime = false;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            gameObject.SetActive(false);
        }

        if(PauseTime){
            TimeManager.Instance.StopTimer();
        }

        //if click at anywhere not in the panel, close the panel
        if(Input.GetMouseButtonDown(0)){
            if(ClickEdgeToClose){
                if(!RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition)){
                    if(PauseTime){
                        TimeManager.Instance.StartTimer();
                    }
                gameObject.SetActive(false);
                }
            }else{
                if(PauseTime){
                        TimeManager.Instance.StartTimer();
                    }
                gameObject.SetActive(false);
            }
            
        }
    }
}
