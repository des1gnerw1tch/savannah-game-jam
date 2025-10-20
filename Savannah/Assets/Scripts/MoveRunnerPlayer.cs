using System;
using UnityEngine;

public class MoveRunnerPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
        transform.position += this.transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");
    }
}
