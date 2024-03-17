using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public AudioClip smash;

    float deleteTime = 2f;
    public int bulletDamage = 5;
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
            collision.gameObject.GetComponent<PlayerBehavior>().dealDamage(bulletDamage);

            // Knockback
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 knockbackDirection = new Vector2(collision.transform.position.x - transform.position.x, 1).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackMultiplier, ForceMode2D.Impulse);
            if (collision.gameObject.GetComponent<PlayerBehavior>().health > 0)
            {
                SoundManager.Instance.PlayEffectSound(SoundManager.Instance.PlayerHurtSound, 0.04f);
            }
            else
            {
                SoundManager.Instance.PlayEffectSound(SoundManager.Instance.DyingPlayerSound, 0.07f);
            }

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
            if (collision.gameObject.GetComponent<EnemyBehavior>().health > 0)
            {
                SoundManager.Instance.PlayEffectSound(SoundManager.Instance.EnemyHurtSound, 0.07f);
            }
            else
            {
                SoundManager.Instance.PlayEffectSound(SoundManager.Instance.DyingEnemySound, 0.04f);
            }
        }

        if (gameObject.CompareTag("Bullet"))
        {
            SoundManager.Instance.PlayEffectSound(SoundManager.Instance.SmashSound, 0.01f);
        }
        Destroy(gameObject);
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(deleteTime);
        Destroy(gameObject);
    }
}
