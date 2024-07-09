using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EmployeeActionSO", menuName = "ScriptableObjects/EmployeeActionSO", order = 1)]
public class EmployeeActionSO : ScriptableObject
{
    public bool IsSlackingAction;
    public string AnimationName;
    public string PCAnimationName;
    public AudioClip SFX;
    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(0f, 2f)]
    public float pitch = 1f;

    public bool HasHint = false;
    public bool RequireHearing = false;
}
