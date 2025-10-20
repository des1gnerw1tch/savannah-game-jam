using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class NightLevelController : MonoBehaviour
{
    public AnimalSpawner spawner;
    //public TMP_Text deathText;
    //public static Image deathScreen;
    public Image blackScreen;
    public int level = 1;
    [SerializeField] private string nextDayLevel;
    [SerializeField] private GameObject youWon;
    void Start()
    {
        //fade in from black
        Time.timeScale = 1;
        StartCoroutine(RemoveBlackScreen());

        spawner.ConfigureSpawner(level);
    }


    public void LoadNextLevel()
    {
        if (nextDayLevel != "DoneWithGame")
        {
            blackScreen.enabled = true;
        }
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1);
        //fade to black
        if (nextDayLevel == "DoneWithGame")
        {
            Debug.Log("Game is WON!");
            youWon.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(nextDayLevel);
        }
        
    }

    IEnumerator RemoveBlackScreen()
    {
        yield return new WaitForSeconds(1);
        blackScreen.enabled = false;
    }

    //public void ShowDeathScreen()
    //{
    //    deathScreen.enabled = true;
    //}
}
