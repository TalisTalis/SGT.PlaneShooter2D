using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameController gameController;

    public float respawnTime = 2f;
    public int enemySpawnCount = 10;

    private bool lastEnemySpawned = false;

    private void Start()
    {
        StartCoroutine(EnemySpawner());        
    }

    private void Update()
    {
        if (lastEnemySpawned && FindObjectOfType<EnemyScript>() == null)
        {
            StartCoroutine(gameController.LevelComplete());
        }
    }

    IEnumerator EnemySpawner()
    {
        for (int i = 0; i < enemySpawnCount; i++)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }

        lastEnemySpawned = true;
        //yield return new WaitForSeconds(1f);
        //gameController.LevelComplete();
    }
    void SpawnEnemy()
    {
        int randomValue = Random.Range(0, enemies.Length);
        int randomXPos = Random.Range(-2, 2);
        Instantiate(enemies[randomValue], new Vector3(randomXPos, transform.position.y), Quaternion.identity);
    }
}
