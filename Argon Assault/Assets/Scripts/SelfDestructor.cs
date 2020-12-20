using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [SerializeField] float delayTime = 1.5f;
     void Start()
    {
        Destroy(gameObject, delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
