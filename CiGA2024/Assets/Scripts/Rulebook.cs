using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rulebook : MonoBehaviour
{

    public void OpenRuleBook(){
        gameObject.SetActive(true);
    }

    public void CloseRuleBook(){
        gameObject.SetActive(false);
    }


}
