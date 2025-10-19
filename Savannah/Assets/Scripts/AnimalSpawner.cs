using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public int maxAnimals = 3;
    public int minTimeBetweenSpawns = 15;
    public int maxTimeBetweenSpawns = 30;
    public GameObject animalPrefab;
    public List<GameObject> spawnPoints;
    private int curNumAnimals;

    void Start()
    {
        curNumAnimals = 0;

        StartCoroutine(SpawnAnimal());
    }

    void Update()
    {

    }

    IEnumerator SpawnAnimal()
    {
        while(curNumAnimals < maxAnimals)
        {
            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));

            int spawnPointIndex = Random.Range(0, spawnPoints.Count);
            GameObject spawnPoint = spawnPoints[spawnPointIndex];
            spawnPoints.Remove(spawnPoints[spawnPointIndex]);

            Instantiate(animalPrefab, 
                spawnPoint.transform.position, 
                spawnPoint.transform.rotation);
            curNumAnimals++;
        }
    }
}
