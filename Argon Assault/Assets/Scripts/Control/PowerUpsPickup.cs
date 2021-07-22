using System;
using UnityEngine;

namespace RS.Control
{
    public class PowerUpsPickup : MonoBehaviour
    {
        [SerializeField] private PowerUpsController.PowerUpType powerUp;
        [SerializeField] private float powerUpDuration = 8f;
       
        public static Action<PowerUpsController.PowerUpType> OnEnablePowerUp;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                PowerUpsController powerUpsController = FindObjectOfType<PowerUpsController>();

                powerUpsController.HandlePowerUp(powerUp, powerUpDuration);

                OnEnablePowerUp?.Invoke(powerUp);
            }
        }
    }
}
