using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //障碍
    public GameObject hazard;
    //障碍的位置
    public Vector3 spawnValue;
    //障碍数量
    public int hazardCount;
    //每个障碍物的间隔时间
    public float spawnWait;
    //开始生成障碍物的等待时间
    public float startWait;
    //每一波的间隔时间
    public float waveWait;

    //玩家分数
    private int score;
    //显示分数UI
    public Text scoreText;

    public Text gameOverText;
    private bool gameOver;

    public Button restartButton;
    public Button helpButton;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.text = "";
        gameOver = false;

        restartButton.image.enabled = false;
        Text restartText = restartButton.GetComponentInChildren<Text>();
        restartText.text = "";

        restartButton.onClick.AddListener(onClick);
        helpButton.onClick.AddListener(goToBegin);

        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }
    void onClick()
    {
        SceneManager.LoadScene("Main");
    }
    void goToBegin()
    {
        SceneManager.LoadScene("Begin");
    }
    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "GameOver";
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void addScore(int value)
    {
        score += value;
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        //if (restart)
        //{
        //    if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        SceneManager.LoadScene("Main");
        //    }
        //}
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i=0; i<hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);

                if (gameOver)
                {
                    restartButton.image.enabled = true;
                    restartButton.GetComponentInChildren<Text>().text = "Restart";
                }
            }
            yield return new WaitForSeconds(waveWait);
        }
        
    }
}
