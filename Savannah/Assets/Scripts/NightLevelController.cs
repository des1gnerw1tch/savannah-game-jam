using UnityEngine;

public class NightLevelController : MonoBehaviour
{

    public AnimalSpawner spawner;
    public int level = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawner.ConfigureSpawner(level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//
}
