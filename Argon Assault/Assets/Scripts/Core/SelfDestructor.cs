using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RS.Core
{
    public class SelfDestructor : MonoBehaviour
    {
        [SerializeField] float delayTime = 1.5f;
        void Start()
        {
            Destroy(gameObject, delayTime);
        }
    }
}
