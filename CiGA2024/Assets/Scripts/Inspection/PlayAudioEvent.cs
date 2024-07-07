using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class PlayAudioEvent : InspectionEvent
{
    public Sound Clip;

    protected override void TriggerEvent(EmployeeSlot ActingEmployee)
    {
        if (Clip != null)
        {
            Clip.Play();
        }

        //Complete the event after the clip has finished playing
        float length = Clip.audioClip.length;
        StartCoroutine(PlayAudioForDuration(length));
    }

    protected override void CompleteEvent()
    {
        Completed = true;
    }

    private IEnumerator PlayAudioForDuration(float duration)
    {
        if (isPaused)
        {
            CompleteEvent();
            yield break;
        }

        yield return new WaitForSeconds(duration);

        CompleteEvent();
    }

    public override void Pause()
    {
        isPaused = true;
        AudioManager.Instance.PauseClip(Clip.audioClip);
    }
}
