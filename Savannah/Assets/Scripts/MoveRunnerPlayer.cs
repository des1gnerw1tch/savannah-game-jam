using System;
using UnityEngine;

public class MoveRunnerPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speedIncrementWhenPressMouseButton;

    void Update()
    {
        transform.position += this.transform.forward * speed * Time.deltaTime;
        

        if (Input.GetMouseButtonDown(0))
        {
            this.speed += speedIncrementWhenPressMouseButton;
            Debug.Log("Left mouse button down");
            ClampSpeed();
        }

        if (Input.GetMouseButtonDown(1))
        {
            this.speed -= speedIncrementWhenPressMouseButton;
            Debug.Log("Right mouse button down");
            ClampSpeed();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");
    }

    private void ClampSpeed()
    {
        this.speed = Mathf.Clamp(speed, 0, maxSpeed);
    }
}
