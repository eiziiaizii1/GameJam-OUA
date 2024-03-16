using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    [SerializeField] Transform enemyTargetLocation;
     
    public float timeInterval = 2;
    public int maxEnemyNumber = 5;
    public int currentEnemyNum = 0;
    public float timePassed = 0;

    void Start()
    {
        
    }

    // Ilk spawn olan enemy target'ý setlenmiyor
    void Update()
    {
        timePassed += Time.deltaTime;
        currentEnemyNum = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (timePassed >= timeInterval && currentEnemyNum < maxEnemyNumber)
        {
            int randomEnemyIndex = Random.Range(0, enemies.Count);
            GameObject newEnemy = Instantiate(enemies[randomEnemyIndex], transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyBehavior>().setEnemyTarget(enemyTargetLocation);
            timePassed = 0;
            timeInterval = Random.Range(1,2);
        }
    }
}
