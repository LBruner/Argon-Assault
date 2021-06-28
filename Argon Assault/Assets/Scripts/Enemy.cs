using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosionSFX;
    [SerializeField] Transform parents;
    [SerializeField] int pointsPerKill = 15;

    [SerializeField] int hits = 10;

    [SerializeField] bool enableCanvas = false;

    ScoreBoard scoreBoardScript;

    public static event Action<bool> OnEnemyDeath;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoardScript = FindObjectOfType<ScoreBoard>();
        AddBoxCollider();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        pointsPerKill = UnityEngine.Random.Range(20, 140);
    }

    private void OnParticleCollision(GameObject other)
    {
        hits--;
        if(hits <= 0)
        {
            scoreBoardScript.ScoreHit(pointsPerKill);
            KillEnemy();
        }            
    }

    private void KillEnemy()
    {
        OnEnemyDeath?.Invoke(enableCanvas);
        GameObject explosions = Instantiate(enemyExplosionSFX, transform.position, Quaternion.identity);
        explosions.transform.parent = parents;
        
        Destroy(gameObject);
    }
}
