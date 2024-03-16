using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{   
    // lookDirection = 1 -> Facing Right, lookDirection = -1 -> Facing Left
    float lookDirection = 1f;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPos;
    float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleFlip();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        
    }

    private void HandleFlip()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Flips the Player and changes look direction
        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
            lookDirection = -1f;
        }
        else if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            lookDirection = 1f;
        }
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, bulletSpawnPos.position,bullet.transform.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(lookDirection, 0f);
        rb.velocity = direction * bulletSpeed;
    }
}
