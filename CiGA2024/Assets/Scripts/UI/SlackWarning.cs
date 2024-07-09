using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlackWarning : MonoBehaviour
{
    public Sound warningSound;
    public void ShowSlackWarning(){
        this.gameObject.SetActive(true);
    }

    public void CloseSlackWarning(){
        this.gameObject.SetActive(false);
    }

    // show for 3 seconds, then close
    public void ShowAndClose(){
        ShowSlackWarning();
        warningSound.Play();
        StartCoroutine(CloseAfterSeconds(2));
    }

    IEnumerator CloseAfterSeconds(float seconds){
        yield return new WaitForSeconds(seconds);
        CloseSlackWarning();
    }
}
