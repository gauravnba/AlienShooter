using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField]
    GameObject EnemyPrefab;
    [SerializeField]
    Vector3 SpawnValues;
    [SerializeField]
    float SpawnWait = 1.0f;
    [SerializeField]
    int MaxEnemiesToSpawn = 4;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        while (true)
        {
            int EnemiesToSpawn = Random.Range(1, MaxEnemiesToSpawn);
            for (int i = 0; i < EnemiesToSpawn; ++i) {
                Vector3 spawnPosition = new Vector3(SpawnValues.x, transform.position.y, Random.Range(-SpawnValues.z, SpawnValues.z));
                GameObject obj = Instantiate(EnemyPrefab, spawnPosition, transform.rotation) as GameObject;
                obj.transform.SetParent(transform);
            }
            yield return new WaitForSeconds(SpawnWait);
        }
    }
}
