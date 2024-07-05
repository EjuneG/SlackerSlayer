using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip audioClip;
    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(0f, 2f)]
    public float pitch = 1f;
    
    public void Play()
    {
        AudioManager.Instance.PlayClip(audioClip, volume, pitch);
    }
}
