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
        Transform player;

        [SerializeField] float timeBetweenShots = 5f;
        [SerializeField] GameObject projectillePrefab = null;
        [SerializeField] Transform projectilleSpawnpoint = null;
        //[SerializeField] bool enableCanvas = false;

        public static Action<int> OnEnemyDie;

        //public static event Action<bool> OnEnemyDeath;

        void OnEnable()
        {
            StartCoroutine(InstantiateProjectille());
        }

        private void Update()
        {
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
            transform.LookAt(player);
        }

        IEnumerator InstantiateProjectille()
        {
            yield return new WaitForSeconds(.5f);
            Instantiate(projectillePrefab, projectilleSpawnpoint.position, transform.rotation);
            yield return new WaitForSeconds(timeBetweenShots);
            Debug.Log("!!");
            StartCoroutine(InstantiateProjectille());
        }

        private void OnParticleCollision(GameObject other)
        {
            Debug.Log("!");
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
