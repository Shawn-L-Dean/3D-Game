using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Text objects to manage
    public static GameManager Manager = null;

    public GameObject[] enemiesInLevel;
    public TMP_Text EnemyLeftText;
    public string countPrefix = string.Empty;
    public static int enemyCount = 0;

    public Image CrossHair;

    public TMP_Text HealthText;
    public string healthPrefix = string.Empty;
    public static float health;

    public TMP_Text TimerText;
    public string timerPrefix = string.Empty;
    public static float time;

    public TMP_Text GameOverText;

    public GameObject Player;

    private void Awake()
    {
        //Initalize variables upon restart.
        Manager = this;
        health = 200;
        enemyCount = 0;
        enemiesInLevel = GameObject.FindGameObjectsWithTag("Enemy");

        if (SceneManager.GetActiveScene().name == "Level01")
        {
            enemyCount = enemiesInLevel.Length;
            time = 180;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthText != null)
        {
            HealthText.text = healthPrefix + health.ToString();
            if (health <= 0)
            {
                StartCoroutine(GameOver()); //Game is over
            }
        }
        if(TimerText != null)
        {
            time -= Time.deltaTime;
            TimerText.text = timerPrefix + Mathf.Round(time);
            if (time <= 0)
            {
                StartCoroutine(GameOver()); //Game is over
            }
        }
        if (EnemyLeftText != null)
        {
            EnemyLeftText.text = countPrefix + enemyCount.ToString();
            if(enemyCount == 0)
            {
                StartCoroutine(GameOver()); //Game is over
            }
        }
    }

    IEnumerator GameOver()
    {
        time = 0;
        if(Manager.GameOverText != null)
        {
            GameOverText.gameObject.SetActive(true);
            CrossHair.gameObject.SetActive(false);
            if(enemyCount == 0)
            {
                if(SceneManager.GetActiveScene().name == "Level01")
                {
                    GameOverText.text = "You win! Returning to main menu...";
                    yield return new WaitForSeconds(4.0f);
                    SceneManager.LoadScene("MainMenu");
                }
            }
            else
            {
                yield return new WaitForSeconds(4.0f);
                SceneManager.LoadScene("Level01");
            }
        }
    }
}
