using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyGO;
    float maxSpawnRateInSeconds = 5f;

    void Start()
    {
        Invoke(nameof(SpawnEnemy), maxSpawnRateInSeconds);
        InvokeRepeating(nameof(IncreaseSpawnRate), 0f, 30f);
    }

    void Update()
    {
    }

    void SpawnEnemy()
    {
        // Bottom-left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // Top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject anEnemy = Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInNSeconds = 1f;
        }

        Invoke(nameof(SpawnEnemy), spawnInNSeconds);
    }

    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
        {
            maxSpawnRateInSeconds--;
        }

        if (maxSpawnRateInSeconds == 1f)
        {
            CancelInvoke(nameof(IncreaseSpawnRate));
        }
    }
}
