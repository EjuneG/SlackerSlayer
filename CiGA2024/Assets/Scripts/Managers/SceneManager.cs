using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField]GameObject HUDCanvas;
    [SerializeField]GameObject PopupCanvas;
    [SerializeField]GameObject InspectionCanvas;
    [SerializeField]GameObject LimitSelectionPanel;

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


    private void Start()
    {
        HideCanvasContent(InspectionCanvas);
        HideCanvasContent(PopupCanvas);
    }

    private void HideCanvasContent(GameObject canvas)
    {
        foreach (Transform child in canvas.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
