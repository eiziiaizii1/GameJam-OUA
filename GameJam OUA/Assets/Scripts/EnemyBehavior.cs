using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int health = 50;
    public int damage = 10;

    public Transform targetPosition; // is assigned by Spawn script
    public float movementSpeed = 2f;
    public float stopDistance = 1f;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Color defaultColor;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = rb.GetComponent<SpriteRenderer>();
        defaultColor = GetComponent<SpriteRenderer>().color;
        animator = GetComponent<Animator>();
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
        if (target != null)
        {
            Debug.Log("Target is set");
        }else
        {
            Debug.Log("TARGET IS NULL");
        }
    }

    void FixedUpdate()
    {
        if (targetPosition == null) return;

        Vector2 direction = new Vector2(targetPosition.position.x - transform.position.x, rb.velocity.y).normalized;

        float distance = Mathf.Abs(targetPosition.position.x - transform.position.x);

        if (distance > stopDistance)
        {
            animator.SetBool("isWalking", true);
            rb.velocity = new Vector2(direction.x * movementSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("isWalking", false);
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
        sprite.color = new Color(1f,0f,0f,0.5f);
        yield return new WaitForSeconds(0.1f);
        sprite.color= defaultColor;
    }
}