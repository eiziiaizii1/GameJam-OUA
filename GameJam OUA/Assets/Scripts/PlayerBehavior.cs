using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerBehavior : MonoBehaviour
{
    Rigidbody2D playerRb;
    float playerSpeed = 7f;
    float horizontalInput;

    // lookDirection = 1 -> Facing Right, lookDirection = -1 -> Facing Left
    float lookDirection = 1f;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPos;
    float bulletSpeed = 10f;
    float currentTime = 0f;
    [SerializeField] float shootTime = 0.5f;

    private SpriteRenderer sprite;
    private Color defaultColor;
    
    public int maxHealth = 80;
    public int health;
    public int damage = 10;

    bool isCrouching = false;
    Animator animator;
    [SerializeField] Vector2 crouchOffset;
    [SerializeField] Vector2 crouchSize;
    [SerializeField] Vector2 standOffset;
    [SerializeField] Vector2 standsize;
    CapsuleCollider2D collider;

    void Start()
    {
        health = maxHealth;
        playerRb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        defaultColor = GetComponent<SpriteRenderer>().color;
        animator = GetComponent<Animator>();
        collider = GetComponent<CapsuleCollider2D>();
        collider.offset = standOffset;
        collider.size = standsize;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        
        HandleFlip(horizontalInput);
        
        currentTime += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && currentTime >= shootTime)
        {
            SoundManager.Instance.PlayEffectSound(SoundManager.Instance.PlatethrowSound, 0.02f);
            Shoot();
            currentTime = 0f;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("You are dead");
        }

        // Crouching
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching;
            animator.SetBool("isCrouching", isCrouching);
        }

        handleCrouch(isCrouching);
    }

    private void handleCrouch(bool isCrouching)
    {
        if (isCrouching)
        {
            collider.offset = crouchOffset;
            collider.size = crouchSize;
        }
        else
        {
            collider.offset = standOffset;
            collider.size = standsize;
        }
    }



    private void FixedUpdate()
    {
        // Moves the player
        playerRb.velocity = new Vector2(horizontalInput * playerSpeed, playerRb.velocity.y);
    }

    public void dealDamage(int incomingDamage)
    {
        health -= incomingDamage;
        StartCoroutine(FlashRed());
        Debug.Log(health);
    }

    public IEnumerator FlashRed()
    {
        sprite.color = new Color(1f, 0f, 0f, 0.5f);
        yield return new WaitForSeconds(0.1f);
        sprite.color = defaultColor;
    }

    private void HandleFlip(float horizontalInput)
    {
        // Flips the Player and changes look direction
        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, 0);
            lookDirection = -1f;
        }
        else if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            lookDirection = 1f;
        }
    }

    // Shoots and moves the bullet 
    private void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, bulletSpawnPos.position, bullet.transform.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(lookDirection, 0f);

        // Sets the bullet's damage value equal to the player's damage value.
        BulletBehavior bulletScripts = newBullet.GetComponent<BulletBehavior>();
        bulletScripts.setBulletDamage(damage);
        rb.velocity = direction * bulletSpeed;
    }
}
