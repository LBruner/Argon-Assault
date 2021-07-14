using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RS.Core
{
    public class SelfDestructor : MonoBehaviour
    {
        Image imageFillAmount = null;

        [SerializeField] private bool isParticle = true;

        [SerializeField] float delayTime = 1.5f;
        void Start()
        {
            if(isParticle)
            {
                Destroy(gameObject, delayTime);
                return;
            }

            imageFillAmount = GetComponent<Image>();
        }

        private void Update()
        {
            if(imageFillAmount != null)
            {
                if(imageFillAmount.fillAmount <= 0)
                    Destroy(transform.parent.gameObject);
            }
        }
    }
}
