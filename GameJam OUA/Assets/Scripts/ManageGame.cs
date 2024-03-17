using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class ManageGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHealth;
    [SerializeField] TextMeshProUGUI baseHealth;
    int maxPlayerHealth;
    int maxBaseHealth;

    [SerializeField] PlayerBehavior playerBehaviorScript;
    [SerializeField] RestaurantDefenseManager restaurantScript;

    [SerializeField] GameObject gameOverScreen;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        maxPlayerHealth = playerBehaviorScript.maxHealth;
        maxBaseHealth = restaurantScript.maxRestaurantHealth;
    }

    void Update()
    {
        if (playerBehaviorScript.health <= 0 || restaurantScript.restaurantHealth <= 0)
        {
            gameOverScreen.SetActive(true);
            SoundManager.Instance.StopBackgrounSound();
            //bozuk ses
            //SoundManager.Instance.PlayEffectSound(SoundManager.Instance.GameOverSound);
            Time.timeScale = 0.0f;
        }
        else
        {
            playerHealth.text = " Health: " + playerBehaviorScript.health + "/" + maxPlayerHealth;
            baseHealth.text = " Base Health: " + restaurantScript.restaurantHealth + "/" + maxBaseHealth;
        }
    }

    public void restartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Reloading Scene: " + SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void exitFromTheGame()
    {
        Application.Quit();
    }

}
