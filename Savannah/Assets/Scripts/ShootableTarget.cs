using UnityEngine;

public class ShootableTarget : MonoBehaviour
{
    float health = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.tag = "target";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log($"Took {dmg} damage, now at {health} health");
        if(health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
