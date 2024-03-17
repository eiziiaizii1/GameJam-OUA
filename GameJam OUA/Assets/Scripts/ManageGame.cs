using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ManageGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHealth;
    [SerializeField] TextMeshProUGUI baseHealth;
    int maxPlayerHealth;
    int maxBaseHealth;

    [SerializeField] PlayerBehavior playerBehaviorScript;
    [SerializeField] RestaurantDefenseManager restaurantScript;


    void Start()
    {
        maxPlayerHealth = playerBehaviorScript.maxHealth;
        maxBaseHealth = restaurantScript.maxRestaurantHealth;
    }

    void Update()
    {
        if (playerBehaviorScript.health <= 0 || restaurantScript.restaurantHealth <= 0)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            playerHealth.text = " Health: " + playerBehaviorScript.health + "/" + maxPlayerHealth;
            baseHealth.text = " Base Health: " + restaurantScript.restaurantHealth + "/" + maxBaseHealth;
        }
    }

}
