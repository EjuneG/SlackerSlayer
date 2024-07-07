using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text slackerCountText;

    public void ShowResult(){
        this.gameObject.SetActive(true);
        moneyText.text = LevelManager.Instance.DailyEarnedMoney.ToString();
        slackerCountText.text = LevelManager.Instance.DailySlackerCaught.ToString();
    }
    void Update(){
        //if left mouse button is clicked, exit game
        if(Mouse.current.leftButton.wasPressedThisFrame){
            ExitGame();
        }

        //exit if any key is pressed
        if(Keyboard.current.anyKey.wasPressedThisFrame){
            ExitGame();
        }
    }
    public void ExitGame(){
        Application.Quit();
    }
}
