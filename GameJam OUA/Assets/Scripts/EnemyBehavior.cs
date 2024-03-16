using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform targetPosition;
    public float movementSpeed = 5f;
    public float stoppingDistance = 1f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (targetPosition == null)
        {
            Debug.LogError("Target position is not set!");
        }
    }

    void FixedUpdate()
    {
        if (targetPosition == null) return;

        Vector2 direction = new Vector2(targetPosition.position.x - transform.position.x, 0).normalized;

        float distance = Mathf.Abs(targetPosition.position.x - transform.position.x);

        if (distance > stoppingDistance)
        {
            rb.velocity = new Vector2(direction.x * movementSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}