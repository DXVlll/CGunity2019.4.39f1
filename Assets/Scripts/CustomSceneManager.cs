using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSceneManager : MonoBehaviour
{
    
    public void intitialize()
    {
        GameObject looseCanvas = GameObject.FindWithTag("FailedLevelUI");
        GameManager.looseCanvas = looseCanvas;
        looseCanvas.SetActive(false);
        UnityEngine.Debug.Log("init");
        GameObject player = GameObject.FindWithTag("Player");
    //    Transform pTransform = player.GetComponent<Transform>();
        PlayerManager pManager = player.GetComponent<PlayerManager>();

        
            
        GameObject[] levels = GameObject.FindGameObjectsWithTag(GameManager.levelTag);

        GameObject levelToLoad = levels[0];

        for (int i = 0; i < levels.Length; ++i)
        {
            if (levels[i].name != GameManager.currentLevelString) { 
                levels[i].SetActive(false);
            } else {
                UnityEngine.Debug.Log("Found right level");
            //    levels[i].SetActive(true);
                levelToLoad = levels[i];
            }
                
        }
        levelToLoad.SetActive(true);
        if (GameManager.currentLevel == null) {
            GameManager.currentLevel = levelToLoad;
        }



        GameManager.currentLevel.GetComponent<LevelManager>().load(player, pManager);

     

    }
    void Start() {
       // UnityEngine.Debug.Log("Start of Scene Trigered");
        intitialize();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
