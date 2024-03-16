using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    float deleteTime = 2f;

    void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    // Bullet culling can be improved
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(deleteTime);
        Destroy(gameObject);
    }
}
