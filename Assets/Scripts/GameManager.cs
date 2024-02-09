using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class GameManager
{
    public const string levelTag = "Level";
    public static string currentLevelString = "Level 1";
    public static string currentSceneString = "Levels";

    public static GameObject looseCanvas;
    public static GameObject currentLevel;
    public static bool loadLevelByString = true;
    
    
    public static void manageFinish(GameObject nextLlevel, GameObject currentLevel)
    {
        looseCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        currentLevelString = nextLlevel.name;
        currentSceneString = nextLlevel.scene.name;

        SceneManager.LoadScene("FinishedLevel");
        
      //  loadLevelAndResetChanges(nextLlevel.name, nextLlevel.scene.name);
    }
    public static void manageDeath(GameObject player)
    {
        //   player.SetActive(false);
        //GameObject canvas = GameObject.FindWithTag("FailedLevelUI");
        looseCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public static void loadLevelAndResetChanges(string level, string scene)
    {
        if (GameManager.currentLevel != null)
        {
          //  GameManager.currentLevel.SetActive(false);
            GameManager.currentLevel = null;
        }
        

        currentLevelString = level;
        currentSceneString = scene;

        SceneManager.LoadScene(scene);
    }
    public static void notWorkingLoad()
    {
        GameObject player = GameObject.FindWithTag("Player");
        PlayerManager pManager = player.GetComponent<PlayerManager>();


        GameManager.currentLevel.GetComponent<LevelManager>().load(player, pManager);
    }

}
