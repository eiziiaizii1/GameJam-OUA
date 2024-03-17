using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RestaurantDefenseManager : MonoBehaviour
{
    public int maxRestaurantHealth = 200;
    public int restaurantHealth;
    public float damageInterval = 1f;

    private GameObject currentEnemy;

    private void Start()
    {
        restaurantHealth = maxRestaurantHealth;
    }

    void Update()
    {
        if (restaurantHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentEnemy = collision.gameObject;
            StartCoroutine(DamageOverTime(currentEnemy.GetComponent<EnemyBehavior>().damage));
            Debug.Log("Rest Health:" + restaurantHealth);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentEnemy)
        {
            currentEnemy = null; 
        }
    }

    // Damages to the restaurant overtime
    IEnumerator DamageOverTime(int damage)
    {
        // Enemy is destroyed means it is null
        while (restaurantHealth > 0 && currentEnemy != null)
        {
            restaurantHealth -= damage;
            SoundManager.Instance.PlayEffectSound(SoundManager.Instance.BaseDamageSound, 0.03f);
            yield return new WaitForSeconds(damageInterval);
            Debug.Log("Rest Health:" + restaurantHealth);
        }
    }
}
