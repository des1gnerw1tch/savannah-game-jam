using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 5;
    public float spawnRadius = 20f;       // Maximum distance from player
    public float minSpawnDistance = 10f;  // Minimum distance from player
    public bool spawnOnRightSide = true;  // true = right, false = left
    public float spawnDelay = 5f;         // Wait before spawning

    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
        else
        {
            Debug.LogError("No player found with tag 'Player'");
            return;
        }

        StartCoroutine(SpawnEnemiesAfterDelay());
    }

    IEnumerator SpawnEnemiesAfterDelay()
    {
        yield return new WaitForSeconds(spawnDelay);

        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPos = GetRandomSpawnPosition();
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPos;
        int attempts = 0;

        do
        {
            // Random point in circle
            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;

            // Force spawn on one side
            if (spawnOnRightSide)
                randomCircle.x = Mathf.Abs(randomCircle.x);
            else
                randomCircle.x = -Mathf.Abs(randomCircle.x);

            spawnPos = player.position + new Vector3(randomCircle.x, 0, randomCircle.y);

            attempts++;
        }
        while ((Vector3.Distance(spawnPos, player.position) < minSpawnDistance) && attempts < 10);

        return spawnPos;
    }
}
