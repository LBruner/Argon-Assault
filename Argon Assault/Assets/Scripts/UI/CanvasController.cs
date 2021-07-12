using System.Collections;
using System.Collections.Generic;
using RS.Control;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    void OnEnable()
    {
        //Enemy.OnEnemyDeath += EnableAnimation;
    }

    private void OnDestroy()
    {
        //Enemy.OnEnemyDeath -= EnableAnimation;
    }

    public void EnableAnimation(bool enableCanvas)
    {   
        if(enableCanvas)
        {
            Time.timeScale = 0.4f;
            GetComponent<Animator>().SetTrigger("enableFade");
        }
    }

    public void LoadNextMap()
    {
        SceneManager.LoadScene(1);
    }

}
