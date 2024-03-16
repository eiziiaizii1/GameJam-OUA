using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    int health = 50;

    public Transform targetPosition;
    public float movementSpeed = 2f;
    public float stopDistance = 1f;

    private Rigidbody2D rb;

    private SpriteRenderer sprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = rb.GetComponent<SpriteRenderer>();
        if (targetPosition == null)
        {
            Debug.LogError("Target position is not set!");
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void setEnemyTarget(Transform target)
    {
        targetPosition = target;
    }

    void FixedUpdate()
    {
        if (targetPosition == null) return;

        Vector2 direction = new Vector2(targetPosition.position.x - transform.position.x, rb.velocity.y).normalized;

        float distance = Mathf.Abs(targetPosition.position.x - transform.position.x);

        if (distance > stopDistance)
        {
            rb.velocity = new Vector2(direction.x * movementSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    public void dealDamage(int incomingDamage)
    {
        health -= incomingDamage;
        StartCoroutine(FlashRed());
        Debug.Log(health);
    }

    public IEnumerator FlashRed()
    {
        Color originalColor = sprite.color;
        sprite.color = new Color(1f,0f,0f,0.5f);
        yield return new WaitForSeconds(0.1f);
        sprite.color= originalColor;
    }
}