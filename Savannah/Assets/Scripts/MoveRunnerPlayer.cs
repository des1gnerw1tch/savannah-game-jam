using System;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveRunnerPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float speedIncrementWhenPressMouseButton;
    [SerializeField] private float speedToResetAfterCollision;
    [SerializeField] private TextMeshProUGUI distanceText;
    [SerializeField] private float distanceNeededToEscape;
    [SerializeField] private TextMeshProUGUI speedText;
    private Vector3 startingRunningPosition;

    [SerializeField] private string nextNightLevelToLoad;
    private void Start() => startingRunningPosition = this.transform.position;
    
    void Update()
    {
        transform.position += this.transform.forward * speed * Time.deltaTime;
        

        if (Input.GetMouseButtonDown(0))
        {
            this.speed += speedIncrementWhenPressMouseButton;
            Debug.Log("Left mouse button down");
            ClampSpeed();
            UpdateSpeedText();
        }

        if (Input.GetMouseButtonDown(1))
        {
            this.speed -= speedIncrementWhenPressMouseButton;
            Debug.Log("Right mouse button down");
            ClampSpeed();
            UpdateSpeedText();
        }

        CheckDistanceFromStart();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!");
        if (other.gameObject.tag == "RunnerEnemy")
        {  
            Debug.Log("Game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // by name
        }
        else
        {
            speed = speedToResetAfterCollision;
        }
    }

    private void ClampSpeed()
    {
        this.speed = Mathf.Clamp(speed, 0, maxSpeed);
    }

    private void CheckDistanceFromStart()
    {
        float distance = Vector3.Distance(this.transform.position, startingRunningPosition);
        distanceText.text = distance.ToString();
        if (distance > distanceNeededToEscape)
        {
            SceneManager.LoadScene(nextNightLevelToLoad);
        }
        
    }

    private void UpdateSpeedText()
    {
        speedText.text = speed.ToString();
    }
}
