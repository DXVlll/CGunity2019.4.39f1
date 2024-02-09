using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public GameObject nextLevel;
    public GameObject currentLevel;

    void OnTriggerEnter() {
        UnityEngine.Debug.Log("Trigger activated" + " " + currentLevel.name);
        GameManager.manageFinish(nextLevel, currentLevel);
     //   currentLevel.SetActive(false);
    }
    
}
