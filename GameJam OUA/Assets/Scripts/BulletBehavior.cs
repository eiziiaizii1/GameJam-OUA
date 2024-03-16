using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    float deleteTime = 2f;
    int bulletDamage = 5;
    public float knockbackMultiplier = 10f;

    void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    public void setBulletDamage(int damage)
    {
        bulletDamage = damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color damageColor = new Color(1,0,0,0.5f);

        if (collision.gameObject.CompareTag("Player"))
        {
            // Dealing Damage
            collision.gameObject.GetComponent<CharacterController>().dealDamage(bulletDamage);

            // Knockback
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 knockbackDirection = new Vector2(collision.transform.position.x - transform.position.x, 1).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackMultiplier, ForceMode2D.Impulse);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            // Dealing damage
            collision.gameObject.GetComponent<EnemyBehavior>().dealDamage(bulletDamage);

            // Knockback
            Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 knockbackDirection = new Vector2(collision.transform.position.x - transform.position.x,1).normalized;           
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackMultiplier, ForceMode2D.Impulse);
        }

        Destroy(gameObject);
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(deleteTime);
        Destroy(gameObject);
    }
}
