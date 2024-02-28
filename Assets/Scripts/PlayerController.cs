using UnityEngine;

public class platformsMoving : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    [SerializeField] private float moveDistance = 5f;
    private Rigidbody rb;
    private bool movingUp = true;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector3.up * moveDistance;
        rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void FixedUpdate()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        Vector3 targetDirection = movingUp ? Vector3.up : Vector3.down;
        Vector3 newPosition = rb.position + targetDirection * moveSpeed * Time.fixedDeltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, startPosition.y, startPosition.y + moveDistance);
        
        rb.MovePosition(newPosition);

        if (newPosition.y >= startPosition.y + moveDistance)
        {
            movingUp = false;
        }
        else if (newPosition.y <= startPosition.y)
        {
            movingUp = true;
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
