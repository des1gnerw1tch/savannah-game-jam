using UnityEngine;
using UnityEngine.AI;

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
    private NavMeshAgent agent;
    private float turnTimer = 0f;

    void Start()
    {
        // Randomize stats for this instance
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
        turnCooldown = Random.Range(minTurnCooldown, maxTurnCooldown);

        // Find player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;

        // Setup NavMeshAgent if present
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
            agent.speed = moveSpeed;
    }

    void Update()
    {
        if (player == null) return;

        // Move toward player
        if (agent != null)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            transform.position += (player.position - transform.position).normalized * moveSpeed * Time.deltaTime;
        }

        // Turn cooldown
        turnTimer += Time.deltaTime;
        if (turnTimer >= turnCooldown)
        {
            TurnTowardsPlayer();
            turnTimer = 0f;
        }
    }

    void TurnTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        transform.rotation = lookRotation;
    }
}
