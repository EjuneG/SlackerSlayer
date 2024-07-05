using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{


    [SerializeField] private InspectionScene firstScene;
    public void InitializeInspectionSceneTest(){
        firstScene.LoadScene();
    }
}
