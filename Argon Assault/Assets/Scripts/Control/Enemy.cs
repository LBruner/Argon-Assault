using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RS.Control
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] GameObject enemyExplosionSFX;
        [SerializeField] int pointsPerKill = 15;
        [SerializeField] int hitsToKill = 10;
        
        //[SerializeField] bool enableCanvas = false;

        public static Action<int> OnEnemyDie;

        //public static event Action<bool> OnEnemyDeath;

        void Start()
        {           
            AddBoxCollider();
        }

        private void AddBoxCollider()
        {
            Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        }

        private void OnParticleCollision(GameObject other)
        {
            hitsToKill--;
            if (hitsToKill <= 0)
            {
                OnEnemyDie?.Invoke(pointsPerKill);
                KillEnemy();
            }
        }

        private void KillEnemy()
        {
            //OnEnemyDeath?.Invoke(enableCanvas);
            GameObject explosions = Instantiate(enemyExplosionSFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
