using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    float deleteTime = 2f;
    int bulletDamage = 5;


    void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    public void setBulletDamage(int damage)
    {
        bulletDamage = damage;
    }

    


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
