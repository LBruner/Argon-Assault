﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyExplosionSFX;
    [SerializeField] Transform parents;
    [SerializeField] int pointsPerKill = 15;

    ScoreBoard scoreBoardScript;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoardScript = FindObjectOfType<ScoreBoard>();
        AddBoxCollider();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        pointsPerKill = Random.Range(20, 140);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoardScript.ScoreHit(pointsPerKill);
        GameObject explosions = Instantiate(enemyExplosionSFX, transform.position, Quaternion.identity);
        explosions.transform.parent = parents;
        Destroy(gameObject);
    }
}