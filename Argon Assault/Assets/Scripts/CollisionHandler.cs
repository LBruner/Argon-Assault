using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float loadLevelDelay;

    [Tooltip("Gameobject")][SerializeField] GameObject explosionSFX;

    bool isCollisionEnabled = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            isCollisionEnabled = !isCollisionEnabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCollisionEnabled)
        {
            SendMessage("StartDeathSequence");
            Invoke("ReloadLevel", loadLevelDelay);
        }
        explosionSFX.gameObject.SetActive(true);
        
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
