using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefabOne;
    [SerializeField] float enemyOneInterval;

    [SerializeField] GameObject enemyPrefabTwo;
    [SerializeField] float enemyTwoInterval;

    void Start()
    {
        StartCoroutine(spawnEnemy(enemyOneInterval, enemyPrefabOne));
        StartCoroutine(spawnEnemy(enemyTwoInterval, enemyPrefabTwo));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        //Create random spawn point within the range
        float xRange = Rounding(UnityEngine.Random.Range(10, 12));
        float yRange = Rounding(UnityEngine.Random.Range(-4.5f, 4.5f));
        Vector3 spawnPoint = new Vector3(xRange, yRange, 0);

        //Check if there's already an enemy at the spawn point
        Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPoint, 0.1f);
        bool isOccupied = false;
        foreach(var col in colliders)
        {
            if(col.CompareTag("Enemy"))
            {
                isOccupied = true;
                break;
            }
        }

        //If spawn point is not occupied, spawn a new enemy
        if(!isOccupied)
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy, spawnPoint, Quaternion.identity);
            StartCoroutine(spawnEnemy(interval, enemy));
            Debug.Log(xRange + ", " + yRange);
        }

        //if the spawn point is occupied, wait and try again
        else
        {
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(spawnEnemy(interval, enemy));
        }
    }

    //function to round a value up to the nearest 0.5 (1.4 = 1.5, 3.6 = 4)
    private float Rounding(float num)
    {
        double roundedValue = Math.Round(num + 0.5) - 0.5;
        return (float)roundedValue;
    }
}
