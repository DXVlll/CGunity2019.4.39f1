using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneTrigger : MonoBehaviour
{
    void OnTriggerEnter()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameManager.manageDeath(player);

    }

}
