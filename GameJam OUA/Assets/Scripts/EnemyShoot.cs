using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public float shootInterval = 2f;
    public int bulletDamage = 10;
    [SerializeField] Vector2 bulletSpawn;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine()
    {
        while (true) 
        {
            animator.SetTrigger("Attack");
            Vector2 currentPos = new Vector2(transform.position.x, transform.position.y);
            GameObject bullet = Instantiate(bulletPrefab, (currentPos + bulletSpawn), bulletPrefab.transform.rotation);

            bullet.GetComponent<BulletBehavior>().setBulletDamage(bulletDamage);

            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.velocity = transform.right * bulletSpeed;

            Destroy(bullet, 5f);

            yield return new WaitForSeconds(shootInterval);
        }
    }
}
