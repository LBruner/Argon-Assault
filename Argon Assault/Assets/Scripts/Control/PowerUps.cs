using System.Collections;
using System.Collections.Generic;
using RS.Control;
using UnityEngine;

namespace RS.Control
{
    public class PowerUps : MonoBehaviour
    {
        [SerializeField] private PowerUpType powerUp;
        private PlayerController player;

        public enum PowerUpType
        {
            fastShoots
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                player = other.GetComponent<PlayerController>();

                player.HandlePowerUps(powerUp);
            }
        }
    }
}
