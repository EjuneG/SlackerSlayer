using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    //if esc if pressed again, close the menu and resume

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(this.gameObject.activeSelf){
                ResumeGame();
            }else{
                PauseGame();
            }
        }
    }

    public void ShowPauseMenu(){
        this.gameObject.SetActive(true);
    }

    public void ClosePauseMenu(){
        this.gameObject.SetActive(false);
    }

    public void PauseGame(){
        Time.timeScale = 0;
        ShowPauseMenu();
    }

    public void ResumeGame(){
        Time.timeScale = 1;
        ClosePauseMenu();
    }
}
