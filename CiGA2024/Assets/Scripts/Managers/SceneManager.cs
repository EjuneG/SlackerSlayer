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

    public void StartTestWithDesktop(){
        HideEverything();
        pcUI.gameObject.SetActive(true);
        pcUI.ShowDesktop();
    }

    public void EnterDay(){
        dayStartTransition.ShowDayStartTransition();
    }

    public void EndDay(){
        HideEverything();
        resultPanel.ShowResult();
    }
}
