using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public int minMoveTime = 10;
    public int maxMoveTime = 20;
    public List<GameObject> targetPositionsMiddle;
    public List<GameObject> targetPositionsClose;
    public GameObject player;
    //privates, public for testing
    public int personalMoveTime;
    public int distanceFromPlayer;
    public bool x = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
            gameObject.transform.LookAt(player.transform.position);
            Vector3 curPos = gameObject.transform.position;
            gameObject.transform.position = Vector3.Lerp(curPos, player.transform.position, .01f);
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
                //gameObject.SetActive(false);
                gameObject.transform.position = movePoint.transform.position;
                gameObject.transform.rotation = movePoint.transform.rotation;
                //gameObject.SetActive(true);
                distanceFromPlayer--;
            }
            else if(distanceFromPlayer == 2)
            {
                movePosIndex = Random.Range(0, targetPositionsClose.Count);
                movePoint = targetPositionsClose[movePosIndex];
                //gameObject.SetActive(false);
                gameObject.transform.position = movePoint.transform.position;
                gameObject.transform.rotation = movePoint.transform.rotation;
                //gameObject.SetActive(true);
                distanceFromPlayer--;
            }
            else if( distanceFromPlayer == 1) 
            {
                distanceFromPlayer--;
                x = true;
            }
        }
    }
}
