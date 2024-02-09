using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void LoadMenuScene(){
        SceneManager.LoadScene("Menu");
      //  SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void LoadPlayScene()
    {
        GameManager.loadLevelAndResetChanges(GameManager.currentLevelString, GameManager.currentSceneString);
    }

    public void LoadPlaySceneAfterFailure() // not working
    {
        GameManager.notWorkingLoad();
    }

    public void LoadPlaySceneFromStart()
    {
        GameManager.loadLevelAndResetChanges("Level 1","Levels");
    }
}
