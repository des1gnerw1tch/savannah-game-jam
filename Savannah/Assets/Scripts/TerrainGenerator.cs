using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> closeTerrainPieces;
    public List<GameObject> midTerrainPieces;
    public List<GameObject> farTerrainPieces;
    public int minRangeClose = 4;
    public int maxRangeClose = 8;
    public int minRangeMid = 10;
    public int maxRangeMid = 16;
    public int minRangeFar = 15;
    public int maxRangeFar = 20;
    public int numClosePieces = 25;
    public int numMidPieces = 15;
    public int numFarPieces = 7;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Transform playerTransform = player.transform;

        float angleStepClose = 360f / numClosePieces;
        for (int i = 0; i < numClosePieces; i++)
        {
            float currentAngle = i * angleStepClose;
            float x = playerTransform.position.x + Random.Range(minRangeClose, maxRangeClose) * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
            float z = playerTransform.position.z + Random.Range(minRangeClose, maxRangeClose) * Mathf.Sin(currentAngle * Mathf.Deg2Rad);
            Vector3 spawnPosition = new Vector3(x, playerTransform.position.y, z);

            Instantiate(closeTerrainPieces[Random.Range(0, closeTerrainPieces.Count)], spawnPosition, Quaternion.identity);
        }

        float angleStepMid = 360f / numMidPieces;
        for (int i = 0; i < numMidPieces; i++)
        {
            float currentAngle = i * angleStepMid;
            float x = playerTransform.position.x + Random.Range(minRangeMid, maxRangeMid) * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
            float z = playerTransform.position.z + Random.Range(minRangeMid, maxRangeMid) * Mathf.Sin(currentAngle * Mathf.Deg2Rad);
            Vector3 spawnPosition = new Vector3(x, playerTransform.position.y, z);

            Instantiate(midTerrainPieces[Random.Range(0, midTerrainPieces.Count)], spawnPosition, Quaternion.identity);
        }

        float angleStepFar = 360f / numFarPieces;
        for (int i = 0; i < numFarPieces; i++)
        {
            float currentAngle = i * angleStepFar;
            float x = playerTransform.position.x + Random.Range(minRangeFar, maxRangeFar) * Mathf.Cos(currentAngle * Mathf.Deg2Rad);
            float z = playerTransform.position.z + Random.Range(minRangeFar, maxRangeFar) * Mathf.Sin(currentAngle * Mathf.Deg2Rad);
            Vector3 spawnPosition = new Vector3(x, playerTransform.position.y, z);

            Instantiate(farTerrainPieces[Random.Range(0, farTerrainPieces.Count)], spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
