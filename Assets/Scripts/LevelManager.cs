using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Transform spawn;

    public void load(GameObject player, PlayerManager playerManager) {
        //  player.SetActive(false);
        CharacterController cc = player.GetComponent<CharacterController>();
     //   cc.enabled = false;
        player.transform.position = spawn.position;
       // cc.transform.position = spawn.position;
      //  cc.enabled = true;
        Physics.SyncTransforms(); // added for teleport to work properly

        playerManager.lastSpawn = spawn;
      //  player.SetActive(true);

        UnityEngine.Debug.Log("I have set player position to spawn");
    }

    void Start()
    {
        UnityEngine.Debug.Log("Level loaded spawn:(" + spawn.position.x + ", " + spawn.position.y + ", " + spawn.position.z + ")");
      
    }
}
