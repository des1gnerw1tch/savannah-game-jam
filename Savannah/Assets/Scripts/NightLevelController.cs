using System.Collections;
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
    public static int level = 1;
    
    void Start()
    {
        //fade in from black
        Time.timeScale = 1;
        StartCoroutine(RemoveBlackScreen());

        spawner.ConfigureSpawner(level);
    }


    public void LoadNextLevel()
    {
        level++;
        blackScreen.enabled = true;
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1);
        //fade to black
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
