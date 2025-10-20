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
    private int numAnimalsSpawned;
    public static int curNumAnimals = 0;

    void Start()
    {
        GameObject[] spawnPositions = GameObject.FindGameObjectsWithTag("FarPos");
        foreach (GameObject pos in spawnPositions)
        {
            spawnPoints.Add(pos);
        }

        numAnimalsSpawned = 0;

        StartCoroutine(SpawnAnimal());
    }

    void Update()
    {

    }

    IEnumerator SpawnAnimal()
    {
        while(numAnimalsSpawned < maxAnimals)
        {
            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns));

            int spawnPointIndex = Random.Range(0, spawnPoints.Count);
            GameObject spawnPoint = spawnPoints[spawnPointIndex];
            spawnPoints.Remove(spawnPoints[spawnPointIndex]);

            Instantiate(animalPrefab, 
                spawnPoint.transform.position, 
                spawnPoint.transform.rotation);
            numAnimalsSpawned++;
            curNumAnimals++;
        }

        while (curNumAnimals > 0) 
        {
            yield return new WaitForSeconds(5f);
        }

        yield return new WaitForSeconds(5f);
        Debug.Log("Level complete, good night");
        //level complete
        //add fade to black, scene change
    }

    public static void TigerDeath()
    {
        curNumAnimals--;
    }
}
