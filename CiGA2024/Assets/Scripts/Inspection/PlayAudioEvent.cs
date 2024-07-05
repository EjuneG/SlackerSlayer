using UnityEngine;

public class PlayAudioEvent : InspectionEvent
{
    public Sound Clip;

    protected override void TriggerEvent()
    {
        if (Clip != null)
        {
            Clip.Play();
        }
    }
}
