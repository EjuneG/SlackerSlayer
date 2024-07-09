using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource SFXAudioSource;
    public AudioSource MusicAudioSource;
    private float masterVolume = 1f;

    public Sound BGM;
    public Sound KeyboardBGM;
    public Sound ReceiveInfoSFX;
    public Sound ButtonClickSFX;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            if (transform.parent != null)
            {
                transform.parent = null;
            }
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayClip(AudioClip clip, float volume = 1f, float pitch = 1f)
    {
        if (clip != null)
        {
            SFXAudioSource.pitch = pitch;
            SFXAudioSource.PlayOneShot(clip, volume * masterVolume);
        }
    }

    public void PauseClip(AudioClip clip)
    {
        if (clip != null)
        {
            SFXAudioSource.Pause();
        }
    }

    public bool IsBGMPlaying(){
        return MusicAudioSource.isPlaying;
    }

    public bool IsBGMPlayingClip(AudioClip clip){
        return MusicAudioSource.clip == clip && MusicAudioSource.isPlaying;
    }

    public void PlayBGM(AudioClip clip, float volume = 1f, float pitch = 1f)
    {
        if (clip != null)
        {
            MusicAudioSource.pitch = pitch;
            MusicAudioSource.volume = volume * masterVolume;
            MusicAudioSource.clip = clip;
            MusicAudioSource.Play();
        }
    }

    public void StopBGM()
    {
        MusicAudioSource.Stop();
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume);
    }

    public float GetMasterVolume()
    {
        return masterVolume;
    }
}
