using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Tooltip("In seconds")][SerializeField] float loadLevelDelay;

    [Tooltip("Gameobject")][SerializeField] GameObject explosionSFX;

    [SerializeField] int healthPoints = 3;

    public static Action<int> OnDamageTaken;
    bool isCollisionEnabled = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            isCollisionEnabled = !isCollisionEnabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCollisionEnabled && !other.CompareTag("PowerUp"))
        {
            healthPoints = Mathf.Max(healthPoints - 1, 0);

            OnDamageTaken?.Invoke(healthPoints);
            
            if(healthPoints == 0)
            {
                SendMessage("StartDeathSequence");
                Invoke("ReloadLevel", loadLevelDelay);
                explosionSFX.gameObject.SetActive(true);
            }
        }
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
