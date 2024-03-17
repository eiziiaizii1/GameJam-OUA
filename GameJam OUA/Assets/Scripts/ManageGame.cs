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

    [SerializeField] TextMeshProUGUI reaminingTime;
    public int totalLevelTime = 60;
    float timePassed = 0f;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        maxPlayerHealth = playerBehaviorScript.maxHealth;
        maxBaseHealth = restaurantScript.maxRestaurantHealth;
        SoundManager.Instance.PlayBackgroundSound();
    }

    void Update()
    {
        timePassed += Time.deltaTime;

        if (playerBehaviorScript.health <= 0 || restaurantScript.restaurantHealth <= 0)
        {
            gameOverScreen.SetActive(true);
            StartCoroutine(endGameWithDelay(.1f));
        }
        else
        {
            playerHealth.text = " Health: " + playerBehaviorScript.health + "/" + maxPlayerHealth;
            baseHealth.text = " Base Health: " + restaurantScript.restaurantHealth + "/" + maxBaseHealth;
        }

        reaminingTime.text = " Remaining Time: " + (totalLevelTime - (int)timePassed);

        if (timePassed >= totalLevelTime)
        {
            SceneManager.LoadScene(SceneManager.sceneCount+1);
        }

    }

    IEnumerator endGameWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SoundManager.Instance.StopBackgroundSound();
        SoundManager.Instance.PlayEffectSound(SoundManager.Instance.GameOverSound, 0.1f);
        Time.timeScale = 0.0f;
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
