using System;
using UnityEngine;

namespace RS.Control
{
    public class PowerUps : MonoBehaviour
    {
        [SerializeField] private PowerUpType powerUp;
        [SerializeField] private float powerUpDuration = 8f;
       
        private PlayerController player;

        public static Action<PowerUpType> OnEnablePowerUp;

        public enum PowerUpType
        {
            fastShoots,
            slowMotion,
            noDamage,
            none
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                player = other.GetComponent<PlayerController>();

                player.HandlePowerUps(powerUp, powerUpDuration);

                OnEnablePowerUp?.Invoke(powerUp);
            }
        }
    }
}
