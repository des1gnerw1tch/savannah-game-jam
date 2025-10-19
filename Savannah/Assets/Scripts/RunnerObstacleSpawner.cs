using System.Collections.Generic;
using UnityEngine;

public class RunnerObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> treePrefabs;

    [SerializeField] private int minNumberOfTreesToSpawn;
    [SerializeField] private int maxNumberOfTreesToSpawn;
    [SerializeField] private List<GameObject> rockPrefabs;
    [SerializeField] private int minNumberOfRocksToSpawn;
    [SerializeField] private int maxNumberOfRocksToSpawn;
    [SerializeField] private List<GameObject> grassPrefabs;
    [SerializeField] private int minNumberOfGrassToSpawn;
    [SerializeField] private int maxNumberOfGrassToSpawn;
    [SerializeField] private List<GameObject> logPrefabs;
    [SerializeField] private int minNumberOfLogsToSpawn;
    [SerializeField] private int maxNumberOfLogsToSpawn;
    
    [SerializeField] private Bounds bounds;
    
    void Start()
    {
        SpawnObjects(treePrefabs, minNumberOfTreesToSpawn, maxNumberOfTreesToSpawn);
        SpawnObjects(rockPrefabs, minNumberOfRocksToSpawn, maxNumberOfRocksToSpawn);
        SpawnObjects(grassPrefabs, minNumberOfGrassToSpawn, maxNumberOfGrassToSpawn);
        SpawnObjects(logPrefabs, minNumberOfLogsToSpawn, maxNumberOfLogsToSpawn);
    }

    private void SpawnObjects(List<GameObject> objsToPickFrom, int minNumberToSpawn, int maxNumberToSpawn)
    {
        int numToSpawn = Random.Range(minNumberToSpawn, maxNumberToSpawn);
        for (int i = 0; i < numToSpawn; i++)
        {
            GameObject objToSpawn = objsToPickFrom[Random.Range(0, objsToPickFrom.Count - 1)];
            Vector3 positionToSpawn = new Vector3(Random.Range(bounds.GetMinX(), bounds.GetMaxX()), 0, Random.Range(bounds.GetMinZ(), bounds.GetMaxZ()));
            GameObject objSpawned = GameObject.Instantiate(objToSpawn, positionToSpawn, Quaternion.identity, this.transform);
            objSpawned.transform.Rotate(Vector3.up, Random.Range(0f, 360f));
        }
    }
}
