using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    [Header("Randomizable Stats")]
    public float minMoveSpeed = 2f;
    public float maxMoveSpeed = 5f;

    public float minRotationSpeed = 3f;
    public float maxRotationSpeed = 8f;

    public float minTurnCooldown = 0.5f;
    public float maxTurnCooldown = 2f;

    private float moveSpeed;
    private float rotationSpeed;
    private float turnCooldown;

    private Transform player;
    private float turnTimer = 0f;

    private int level = 1;

    public void SetupEnemy(int levelNumber)
    {
        level = levelNumber;

        // Optionally scale stats by level
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed) + level * 1.5f;
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed) + level * 0.5f;
        turnCooldown = Mathf.Max(Random.Range(minTurnCooldown, maxTurnCooldown) - level * 0.05f, 0.1f);
    }

    void Start()
    { 
        // Find player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;
        
        // Move forward in current direction
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        // Check if it's time to rotate toward player
        turnTimer += Time.deltaTime;
        if (turnTimer >= turnCooldown)
        {
            RotateTowardPlayer();
            turnTimer = 0f;
        }
    }

    void RotateTowardPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction); // instant snap
    }
}
