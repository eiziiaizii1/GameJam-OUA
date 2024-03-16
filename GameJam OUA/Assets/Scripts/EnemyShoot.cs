using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public float shootInterval = 2f;
    public int bulletDamage = 10;

    void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine()
    {
        while (true) 
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, bulletPrefab.transform.rotation);

            bullet.GetComponent<BulletBehavior>().setBulletDamage(bulletDamage);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.velocity = transform.right * bulletSpeed;

            Destroy(bullet, 5f);

            yield return new WaitForSeconds(shootInterval);
        }
    }
}
