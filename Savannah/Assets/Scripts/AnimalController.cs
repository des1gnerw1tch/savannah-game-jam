using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalController : MonoBehaviour
{
    public int minMoveTime = 10;
    public int maxMoveTime = 20;
    public int maxMoveDistance = 20;
    public List<GameObject> targetPositionsMiddle;
    public List<GameObject> targetPositionsClose;
    public GameObject player;
    AudioSource rustle;
    //privates, public for testing
    public int personalMoveTime;
    public int distanceFromPlayer;
    public bool x = false;
    public GameObject camera;

    void Start()
    {
        //Time.timeScale = 1;
        player = GameObject.FindWithTag("Player");
        camera = GameObject.FindWithTag("MainCamera");
        rustle = GetComponent<AudioSource>();
        gameObject.transform.LookAt(player.transform.position);
        GameObject[] middlePositions = GameObject.FindGameObjectsWithTag("MiddlePos");
        GameObject[] closePositions = GameObject.FindGameObjectsWithTag("ClosePos");
        foreach(GameObject pos in middlePositions)
        {
            targetPositionsMiddle.Add(pos);
        }
        foreach(GameObject pos in closePositions)
        {
            targetPositionsClose.Add(pos);
        }
        personalMoveTime = Random.Range(minMoveTime, maxMoveTime);
        distanceFromPlayer = 3;

        StartCoroutine(MoveAnimal());
    }


    void Update()
    {
        if (x)
        {
            Vector3 curPos = gameObject.transform.position;
            Vector3 targetPos = player.transform.position;// - new Vector3(0f, .15f, 0f);
            CameraController.LockCamera();
            CameraController.LookAtTarget(gameObject, camera.transform);

            gameObject.transform.position = Vector3.Lerp(curPos, targetPos, 4f * Time.deltaTime);

            if (Mathf.Abs(gameObject.transform.position.x - player.transform.position.x) < 1.5f
            && Mathf.Abs(gameObject.transform.position.z - player.transform.position.z) < 1.5f)
            {
                //game over logic
                Debug.Log("You Died");
                //NightLevelController.deathScreen.enabled = true;
                Time.timeScale = 0;
                StartCoroutine(ReloadScene());
                //StartCoroutine(ReloadScene());

            }
        }
    }

    IEnumerator MoveAnimal()
    {
        while(distanceFromPlayer > 0)
        {
            yield return new WaitForSeconds(personalMoveTime);

            int movePosIndex;
            GameObject movePoint;

            if(distanceFromPlayer == 3)
            {
                movePosIndex = Random.Range(0, targetPositionsMiddle.Count);
                movePoint = targetPositionsMiddle[movePosIndex];
                //Vector3 tryPoint = new Vector3(movePoint.transform.position.x, 0, movePoint.transform.position.z);
                //Vector3 curPoint = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
                //while(Vector3.Distance(tryPoint, curPoint) > maxMoveDistance)
                //{
                //    movePosIndex = Random.Range(0, targetPositionsMiddle.Count);
                //    movePoint = targetPositionsMiddle[movePosIndex];
                //    tryPoint = new Vector3(movePoint.transform.position.x, 0, movePoint.transform.position.z);
                //    curPoint = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
                //}
                //gameObject.SetActive(false);
                gameObject.transform.position = movePoint.transform.position;
                gameObject.transform.rotation = movePoint.transform.rotation;
                gameObject.transform.LookAt(player.transform.position);
                rustle.Play();
                //gameObject.SetActive(true);
                distanceFromPlayer--;
            }
            else if(distanceFromPlayer == 2)
            {
                movePosIndex = Random.Range(0, targetPositionsClose.Count);
                movePoint = targetPositionsClose[movePosIndex];
                //Vector3 tryPoint = new Vector3(movePoint.transform.position.x, 0, movePoint.transform.position.z);
                //Vector3 curPoint = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
                //while (Vector3.Distance(tryPoint, curPoint) > maxMoveDistance)
                //{
                //    movePosIndex = Random.Range(0, targetPositionsMiddle.Count);
                //    movePoint = targetPositionsMiddle[movePosIndex];
                //    tryPoint = new Vector3(movePoint.transform.position.x, 0, movePoint.transform.position.z);
                //    curPoint = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
                //}
                //gameObject.SetActive(false);
                gameObject.transform.position = movePoint.transform.position;
                gameObject.transform.rotation = movePoint.transform.rotation;
                gameObject.transform.LookAt(player.transform.position);
                rustle.Play();
                //gameObject.SetActive(true);
                distanceFromPlayer--;
            }
            else if( distanceFromPlayer == 1) 
            {
                distanceFromPlayer--;
                gameObject.transform.LookAt(player.transform.position);
                rustle.Play();
                x = true;
            }
        }
    }

    IEnumerator ReloadScene()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //IEnumerator LookAtTiger()
    //{



        //}

        //private void OnTriggerEnter(UnityEngine.Collider other)
        //{
        //    if(other.gameObject.tag == "Player")
        //    {

        //    }
        //}
    }
