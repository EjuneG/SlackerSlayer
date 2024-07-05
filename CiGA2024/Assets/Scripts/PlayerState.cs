using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private static PlayerState _instance;
    public static PlayerState Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerState>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(PlayerState).Name);
                    _instance = singleton.AddComponent<PlayerState>();
                }
            }
            return _instance;
        }
    }
    [field : SerializeField]public List<UnleashedLimit> UnleashedLimits {get; private set; }


    public void UnleashLimit(UnleashedLimit limit){
        if(!UnleashedLimits.Contains(limit)){
            UnleashedLimits.Add(limit);
        }
    }
}

public enum UnleashedLimit{
    Vision,
    Hearing
}

 public interface IPlayerState
    {
        void EnterState();
        void ExitState();
}

public class VisionBuffState : IPlayerState
{
    public void EnterState()
    {
        // Implement behavior when entering the Main Menu state
    }

    public void ExitState()
    {
        // Implement behavior when exiting the Main Menu state
    }
}

public class HearingBuffState : IPlayerState
{
    public void EnterState()
    {
        // Implement behavior when entering the Main Menu state
    }

    public void ExitState()
    {
        // Implement behavior when exiting the Main Menu state
    }
}



