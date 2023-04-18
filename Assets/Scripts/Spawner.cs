using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;


    public float respawnTime = 2f;

    private void Start()
    {
        StartCoroutine(EnemySpawner());
        
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        int randomValue = Random.Range(0, enemies.Length);
        int randomXPos = Random.Range(-2, 2);
        Instantiate(enemies[randomValue], new Vector3(randomXPos, transform.position.y), Quaternion.identity);
    }
}
