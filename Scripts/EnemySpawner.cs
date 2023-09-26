using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject asteroidPrefab;
    public float spawnRatePerMinute = 30f;
    public float spawnRateIncrement = 1f;
    public float xLimitLeft;
    public float xLimitRigth;
    public float maxTimeLife = 4f;

    private float spawnNext = 0;
    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnNext){

            spawnNext = Time.time + 60 / spawnRatePerMinute;

            spawnRatePerMinute += spawnRateIncrement;

            float rand = Random.Range(xLimitLeft, xLimitRigth);

            Vector3 spawnRatePosition = new Vector3(rand , 41f, 47f);

            GameObject meteor = Instantiate(asteroidPrefab, spawnRatePosition, Quaternion.identity);

            Destroy(meteor, maxTimeLife);
        }
    }
}
