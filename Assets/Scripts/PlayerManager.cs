using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int score = 0;
    public Transform lastSpawn;
    public GameObject currentLevel;
    // Start is called before the first frame update
    void Start()
    {
       /* Transform pTransform = GetComponent<Transform>();
        if (GameManager.currentLevel == null) {
            GameObject[] levels = GameObject.FindGameObjectsWithTag(GameManager.levelTag);
            for (int i = 0; i < levels.Length; ++i)
            {
                if (levels[i].name == GameManager.currentLevelString)
                {
                    GameManager.currentLevel = levels[i];
                }

            }
        }
        GameManager.currentLevel.GetComponent<LevelManager>().load(gameObject, this);*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
