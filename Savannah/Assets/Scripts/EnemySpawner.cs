using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 5;
    public float spawnRadius = 20f;       // Maximum distance from player
    public float minSpawnDistance = 10f;  // Minimum distance from player
    public float spawnDelay = 5f;         // Delay before spawning
    public int level;

    private Transform player;

    void Start()
    {
        // Find the player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
        else
        {
            Debug.LogError("No player found with tag 'Player'");
            return;
        }

        switch(level)
        {
            case 2:
                numberOfEnemies = 7;
                break;
            case 3:
                numberOfEnemies = 10;
                break;
            case 4:
                numberOfEnemies = 15;
                break;
            case 5:
                numberOfEnemies = 20;
                break;
            default:
                break;
        }
           


        StartCoroutine(SpawnEnemiesAfterDelay());
    }

    IEnumerator SpawnEnemiesAfterDelay()
    {
        yield return new WaitForSeconds(spawnDelay);

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPos = GetRandomSpawnPosition();
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                enemyAI.SetupEnemy(level);
            }
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPos;
        int attempts = 0;

        do
        {
            // Pick a random point inside a circle
            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;

            // Convert to 3D around player
            spawnPos = player.position + new Vector3(randomCircle.x, 0, randomCircle.y);

            attempts++;
        }
        while ((Vector3.Distance(spawnPos, player.position) < minSpawnDistance) && attempts < 10);

        return spawnPos;
    }
}
