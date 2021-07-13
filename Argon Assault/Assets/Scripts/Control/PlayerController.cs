using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RS.Control
{
    [SelectionBase]
    public class PlayerController : MonoBehaviour
    {
        [Header("General")]
        [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 3f;
        [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 3f;
        [SerializeField] float xClamp = 5f;
        [SerializeField] float minusYClamp, plusYClamp;
        [SerializeField] float shotsDelayTime = .3f;

        [Header("Screen-positions based")]
        [SerializeField] float positionPitchFactor = -5f;
        [SerializeField] float positionYawFactor = 5f;

        [Header("Control Throw Parameters")]
        [SerializeField] float controlPitchFactor = -20f;
        [SerializeField] float controlRollFactor = -20f;
        float horizontalThrow, verticalThrow;

        [Header("Gameobjects References")]
        [SerializeField] GameObject[] guns;
        [SerializeField] AudioClip laserShotSFX;

        bool isControlEnabled = true;

        float timer = 0;
        int currentGunIndex;

        [SerializeField] float timeBetweenShots = 3f;

        private void Start()
        {
            timer = timeBetweenShots;
        }

        void Update()
        {
            if (!isControlEnabled) { return; }

            ProcessRotation();
            ProcessTranslation();
            ProcessFiring();          
        }

        private void ProcessFiring()
        {
            foreach (GameObject gun in guns)
            {
                var gunsEmission = gun.GetComponent<ParticleSystem>().emission;

                if (Input.GetButton("Fire1") && timer > timeBetweenShots)
                {
                    currentGunIndex++;
                    gunsEmission.enabled = true;

                    if(currentGunIndex >= 2)
                    {
                        currentGunIndex = 0;
                        timer = 0;
                    }
                    Debug.Log(timer);
                }
                else
                {
                    gunsEmission.enabled = false;
                }
              
            }
            timer += Time.timeScale;
        }

        public void HandlePowerUps(PowerUps.PowerUpType type)
        {
            switch (type)
            {
                case PowerUps.PowerUpType.fastShoots:
                    StartCoroutine(EnableFastShoot());
                    break;
            }
        }

        IEnumerator EnableFastShoot()
        {
            float oldTime = timeBetweenShots;
            timeBetweenShots = .5f;
            yield return new WaitForSeconds(4f);
            timeBetweenShots = oldTime;
        } 

        void StartDeathSequence()
        {
            isControlEnabled = false;
        }
        private void ProcessRotation()
        {
            float dueToPosition = transform.localPosition.y * positionPitchFactor;
            float dueToControlThrow = verticalThrow * controlPitchFactor;
            float pitch = dueToControlThrow + dueToPosition;


            float yaw = transform.localPosition.y * positionYawFactor;

            float roll = horizontalThrow * controlRollFactor;

            transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
        }

        private void ProcessTranslation()
        {
            horizontalThrow = Input.GetAxis("Horizontal");
            float xOffset = horizontalThrow * xSpeed * Time.deltaTime;

            verticalThrow = Input.GetAxis("Vertical");
            float yOffeset = verticalThrow * ySpeed * Time.deltaTime;

            float rawYValeu = yOffeset + transform.localPosition.y;
            float clampedYRawPos = Mathf.Clamp(rawYValeu, -minusYClamp, plusYClamp);

            float rawXValue = xOffset + transform.localPosition.x;
            float clampedXRawPos = Mathf.Clamp(rawXValue, -xClamp, xClamp);

            transform.localPosition = new Vector3(clampedXRawPos, clampedYRawPos, transform.localPosition.z); ;
        }
    }
}
