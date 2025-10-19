using System;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;


public class ChunkGenerator : MonoBehaviour
{
    [System.Serializable] class Chunk
    {
        public GameObject gameObject;
        public bool hasSpawnedOtherChunks;
        public Point spotOnGrid;
    }
    
    [SerializeField] private List<Chunk> chunkObjects;
    [SerializeField] private GameObject chunkPrefab;
    [SerializeField] private float distanceFromNearestChunkToGenerateNewChunk;
    [SerializeField] private float distanceFromChunkToDespawnChunk;
    [SerializeField] private float distanceToSpawnChunksAway = 200f;
    private Chunk nearestChunk;
    [SerializeField] private int numChunkBatchesToSpawn;

    private Dictionary<Point, bool> pointHasChunk = new Dictionary<Point, bool>();

    private void Start()
    {
        pointHasChunk[new Point(0, 0)] = true;
    }
    
    private void Update()
    {
        if (GetDistanceFromNearestChunk() > distanceFromNearestChunkToGenerateNewChunk)
        {
            if (nearestChunk.hasSpawnedOtherChunks)
            {
                return;
            }
            GenerateNewChunks();
        }
    }

    private float GetDistanceFromNearestChunk()
    {
        float lowestDistance = Mathf.Infinity;
        foreach (Chunk chunk in chunkObjects)
        {
            float distance = Vector3.Distance(this.transform.position, chunk.gameObject.transform.position);
            if (distance < lowestDistance)
            {
                lowestDistance = distance;
                nearestChunk = chunk;
            }
            
        }
        //Debug.Log("Nearest chunk");
        //Debug.Log(lowestDistance);
        //Debug.Log("ID: " + nearestChunk.gameObject.GetInstanceID());
        return lowestDistance;
    }

    private void GenerateNewChunks()
    {
        for (float x = -distanceToSpawnChunksAway * numChunkBatchesToSpawn; x <= distanceToSpawnChunksAway * numChunkBatchesToSpawn; x += distanceToSpawnChunksAway)
        {
            for (float z = -distanceToSpawnChunksAway * numChunkBatchesToSpawn; z <= distanceToSpawnChunksAway * numChunkBatchesToSpawn; z += distanceToSpawnChunksAway)
            {
                Point gridPoint = new Point(nearestChunk.spotOnGrid.X + Convert.ToInt32(x / distanceToSpawnChunksAway), 
                                        nearestChunk.spotOnGrid.Y + Convert.ToInt32(z / distanceToSpawnChunksAway));
                
                
                if (pointHasChunk.ContainsKey(gridPoint))
                {
                    continue;
                }
                Vector3 offset = new Vector3(x, 0, z);
                GameObject chunkObj = GameObject.Instantiate(chunkPrefab, offset + nearestChunk.gameObject.transform.position, Quaternion.identity);
                
                Chunk newChunk = new Chunk{gameObject = chunkObj, hasSpawnedOtherChunks = false, spotOnGrid = gridPoint};
                chunkObjects.Add(newChunk);
                nearestChunk.hasSpawnedOtherChunks = true;
                pointHasChunk[gridPoint] = true;
            }
        }
    }
}
