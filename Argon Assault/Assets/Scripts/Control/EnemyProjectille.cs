using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectille : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool chaseTarget = true;

    private Vector3 target;
    private Transform playerTargetTransform;


    void Start()
    {
        playerTargetTransform = GameObject.FindWithTag("Target").GetComponent<Transform>();
        target = playerTargetTransform.position;
    }

    void Update()
    {
        if(chaseTarget)
            target = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
            
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.localRotation = Quaternion.Euler(90,90, 0);
    }
}
