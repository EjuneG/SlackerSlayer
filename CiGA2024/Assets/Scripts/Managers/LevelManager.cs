using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start(){
        Initialize();
    }

    public List<InspectionLevel> levels; // Assign this in the Inspector

    public InspectionLevel CurrentLevel { get; private set; }

    public void Initialize(){
        foreach(InspectionLevel level in levels){
            level.InitializeScene();
        }
        
        CurrentLevel = levels[0];
    }
    public void StartLevel(int levelIndex)
    {
        TimeManager.Instance.StartTimer();
        CurrentLevel = levels[levelIndex];
        CurrentLevel.InspectionScene.LoadScene();
    }

    public void StartCurrentLevel(){
        StartLevel(CurrentLevel.LevelIndex);
    }

    public void EndLevel()
    {
        CurrentLevel.InspectionScene.CloseScene();
    }

    public void GoToNextLevel()
    {
        EndLevel();
        if (CurrentLevel != null)
        {
            int nextLevelIndex = CurrentLevel.LevelIndex + 1;
            if (nextLevelIndex < levels.Count)
            {
                StartLevel(nextLevelIndex);
            }
            else
            {
                Debug.Log("no more levels");
            }
        }
    }
}
