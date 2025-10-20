using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public int maxAnimals = 3;
    public int minTimeBetweenSpawns = 15;
    public int maxTimeBetweenSpawns = 30;
    public GameObject animalPrefab;
    public NightLevelController nightLevelController;
    public List<GameObject> spawnPoints;
    private int numAnimalsSpawned;
    public static int curNumAnimals = 0;

    void Start()
    {
        numAnimalsSpawned = 0;
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

    public void StartLogic()
    {
        GameObject[] spawnPositions = GameObject.FindGameObjectsWithTag("FarPos");
        foreach (GameObject pos in spawnPositions)
        {
            spawnPoints.Add(pos);
        } 
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
            //spawnPoints.Remove(spawnPoints[spawnPointIndex]);
            Debug.Log("Spawning animal #: " + curNumAnimals);
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
        nightLevelController.LoadNextLevel();
    }

    public static void TigerDeath()
    {
        curNumAnimals--;
    }
}
