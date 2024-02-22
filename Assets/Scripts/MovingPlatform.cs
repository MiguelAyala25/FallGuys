using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    [SerializeField] private float moveDistance = 5f;

    void Start()
    {
        startPosition = transform.position; 
        targetPosition = startPosition + Vector3.up * moveDistance; 
    }

    void Update()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            if (targetPosition.y >= startPosition.y + moveDistance) 
            {
                targetPosition = startPosition - Vector3.up * moveDistance; 
            }
            else 
            {
                targetPosition = startPosition + Vector3.up * moveDistance; 
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }

}