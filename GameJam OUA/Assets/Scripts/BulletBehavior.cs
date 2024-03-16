using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    float deleteTime = 2f;
    float bulletSpeed = 10f;
    int bulletDamage = 5;
    
    void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }


    //public void InitializeBullet(int bulletDamage, int bulletSpeed)
    //{
    //    this.bulletDamage = bulletDamage;
    //    this.bulletSpeed = bulletSpeed;
    //}

    public void setBulletDamage(int damage)
    {
        bulletDamage = damage;
    }

    //public void Shoot(Vector3 spawnPosition, Quaternion rotation, float lookDirection, int damage) {
    //    GameObject newBullet = Instantiate(gameObject, spawnPosition, rotation);
    //    Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
    //    Vector2 direction = new Vector2(lookDirection, 0f);

    //    setBulletDamage(damage);

    //    rb.velocity = direction * bulletSpeed;
    //}

    // Bullet culling can be improved
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterController>().dealDamage(bulletDamage);
        }
        Destroy(gameObject);
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(deleteTime);
        Destroy(gameObject);
    }
}
