using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private void Awake()
    {
        int levelLoadersCount = FindObjectsOfType<LevelLoader>().Length;
        ;
        if(levelLoadersCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        Invoke("LoadNextLevel", 3f);
    }

    void LoadNextLevel()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentBuildIndex + 1);
    }
}
