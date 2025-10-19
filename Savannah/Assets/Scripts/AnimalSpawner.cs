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

        
    }

    public void ConfigureSpawner(int level)
    {
        switch (level)
        {
            case 2:
                maxAnimals = 5;
                minTimeBetweenSpawns = 12;
                maxTimeBetweenSpawns = 25;
                break;
            case 3:
                maxAnimals = 7;
                minTimeBetweenSpawns = 6;
                maxTimeBetweenSpawns = 18;
                break;
            case 4:
                maxAnimals = 20;
                minTimeBetweenSpawns = 1;
                maxTimeBetweenSpawns = 5;
                break;
            default:
                // default is level 1
                break;
        }

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
            //spawnPoints.Remove(spawnPoints[spawnPointIndex]);
            Debug.Log("Spawning animal #: " + curNumAnimals);
            Instantiate(animalPrefab, 
                spawnPoint.transform.position, 
                spawnPoint.transform.rotation);
            curNumAnimals++;
        }
    }
}
