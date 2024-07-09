using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCScreen : MonoBehaviour
{
    public SlackerCamera slackerCamera;
    public Animator animator;

    public void OpenPCAndPlay(){
        gameObject.SetActive(true);
        animator.Play(slackerCamera.CurrentEmployeeSlot.CurrentAction.PCAnimationName);
    }

    public void ClosePC(){
        gameObject.SetActive(false);
    }

    //if esc is pressed while this is active, set this panel to inactive
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            ClosePC();
        }

        //if click at anywhere not in the panel, close the panel
        if(Input.GetMouseButtonDown(0)){
            if(!RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition)){
                ClosePC();
            }
        }
    }
}
