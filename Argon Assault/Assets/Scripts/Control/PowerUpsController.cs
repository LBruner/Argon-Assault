using System.Collections;
using System.Collections.Generic;
using RS.Control;
using UnityEngine;

namespace RS.Control
{
    public class PowerUpsController : MonoBehaviour
    {
        private PlayerController player = null;
        private float timeBetweenShots = 5f;

        [SerializeField] GameObject forceField = null;

        List<PowerUpsController.PowerUpType> enabledPowerUps = new List<PowerUpType>();

        Coroutine routine = null;

        private void Start()
        {
            player = FindObjectOfType<PlayerController>();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.F))
                StopCoroutine(EnableFastShots(0));
        }

        public enum PowerUpType
        {
            fastShoots,
            slowMotion,
            noDamage,
            none
        }

        public void HandlePowerUp(PowerUpsController.PowerUpType type, float powerUpDuration)
        {

            if(enabledPowerUps.Contains(type))
                StopCoroutine(routine);
            else
                enabledPowerUps.Add(type);

            switch (type)
            {
                case PowerUpType.fastShoots:
                    routine = StartCoroutine(EnableFastShots(powerUpDuration));
                    break;
                case PowerUpType.slowMotion:
                    routine = StartCoroutine(EnableSlowMotion(powerUpDuration));
                    break;
                case PowerUpType.noDamage:
                    routine = StartCoroutine(EnableNoDamage(powerUpDuration));
                    break;
            }
        }
        
        IEnumerator EnableFastShots(float effectDuration)
        {
            player.SetTimeBetweenShots(0.5f);
            yield return new WaitForSeconds(effectDuration);
            Debug.Log("aui");
            player.SetTimeBetweenShots(timeBetweenShots);
        }

        IEnumerator EnableSlowMotion(float effectDuration)
        {
            Time.timeScale = 0.65f;
            yield return new WaitForSeconds(effectDuration);
            Time.timeScale = 1f;
        }

        IEnumerator EnableNoDamage(float effectDuration)
        {
            forceField.gameObject.SetActive(true);
            Collider playerCollider = GetComponent<Collider>();
            playerCollider.enabled = false;
            yield return new WaitForSeconds(effectDuration);
            playerCollider.enabled = true;
            forceField.gameObject.SetActive(false);
        }
    }
}
