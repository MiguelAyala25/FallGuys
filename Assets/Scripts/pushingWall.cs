
using UnityEngine;
public class MovingWall : MonoBehaviour
{
    public Transform endPositionMarker;
    public float speed = 1.0f;
    private Vector3 startPosition;
    private bool movingToEnd = true;
    private Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = movingToEnd ? endPositionMarker.position : startPosition;

        rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime));

        if (rb.position == targetPosition)
        {
            movingToEnd = !movingToEnd;
        }
    }
}