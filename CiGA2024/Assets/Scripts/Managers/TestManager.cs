using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    private static TestManager instance;

    public static TestManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TestManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject(typeof(TestManager).Name);
                    instance = singleton.AddComponent<TestManager>();
                    DontDestroyOnLoad(singleton);
                }
            }
            return instance;
        }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start(){
        SceneManager.Instance.StartTestWithDesktop();
    }

    public void TestStartDayOne(){
        TimeManager.Instance.StartTimer();
        Debug.Log("Day 1 started");
        
    }
}
