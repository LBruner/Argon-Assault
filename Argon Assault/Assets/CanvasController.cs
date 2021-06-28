using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Enemy.OnEnemyDeath += EnableAnimation;
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDeath -= EnableAnimation;
    }

    public void EnableAnimation(bool enableCanvas)
    {
        if(enableCanvas)
            GetComponent<Animator>().SetTrigger("enableFade");
    }

    public void LoadNextMap()
    {
        SceneManager.LoadScene(1);
    }

}
