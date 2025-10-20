using UnityEngine;

public class EnviroPieceBehavior : MonoBehaviour
{
    public GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        gameObject.transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
    }
}
