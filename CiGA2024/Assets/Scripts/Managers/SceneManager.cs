using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]PCUI pcUI;
    [SerializeField]GameObject MainCanvas;
    [SerializeField]GameObject effectCanvas;
    [SerializeField]GameObject popupCanvas;
    [SerializeField]DayStartTransition dayStartTransition;
    [SerializeField]ResultPanel resultPanel;
    [SerializeField]GameObject MainMenu;
    [SerializeField]PauseMenu PauseMenu;
    [SerializeField]GameObject firstUnlock;
    [SerializeField]GameEnd gameEnd; 

    public static SceneManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    void Update(){
        if(PauseMenu.gameObject.activeSelf == false){
            if(Input.GetKeyDown(KeyCode.Escape)){
                PauseMenu.PauseGame();
            }
        }else if (PauseMenu.gameObject.activeSelf == true){
            if(Input.GetKeyDown(KeyCode.Escape)){
                PauseMenu.ResumeGame();
            }
        }
    }

    private void HideEverything(){
        HideCanvasContent(MainCanvas);
        HideCanvasContent(effectCanvas);
        HideCanvasContent(popupCanvas);
    }

    private void HideCanvasContent(GameObject canvas)
    {
        foreach (Transform child in canvas.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void ShowMainMenu(){
        //show main menu
        HideEverything();
        if (!AudioManager.Instance.IsBGMPlaying())
        {
            AudioManager.Instance.PlayBGM(AudioManager.Instance.KeyboardBGM.audioClip, AudioManager.Instance.KeyboardBGM.volume, AudioManager.Instance.KeyboardBGM.pitch);
        }
        MainMenu.SetActive(true);
    }

    public void ShowDesktop(){
        HideEverything();
        pcUI.gameObject.SetActive(true);
        pcUI.ShowDesktop();

        if(LevelManager.Instance.IntroducedCompany == false){
            AudioManager.Instance.ReceiveInfoSFX.Play();
            pcUI.ShowCompanyIntro();
            LevelManager.Instance.IntroducedCompany = true;
        }

        if(TimeManager.Instance.CurrentTime.GameDay == 2 && LevelManager.Instance.UnlockedFirst == false){
            firstUnlock.SetActive(true);
            AudioManager.Instance.ReceiveInfoSFX.Play();
        }
    }

    public void EnterDay(){
        HideEverything();
        dayStartTransition.ShowDayStartTransition();
    }

    public void ShowDayResult(){
        HideEverything();
        resultPanel.ShowResult();
    }

    public void ShowGameResult(){
        HideEverything();
        resultPanel.ShowResult();
    
    }

    public void ShowEndGame(Result result){
        HideEverything();
        gameEnd.ShowEnding(result);
    }

    public void QuitGame(){
        Application.Quit();
    }
}
