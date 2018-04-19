using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{


    public GameObject hazard;
    public Vector3 SpawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text restartText;
    public Text gameOverText;
    private bool gameOver;
    private bool restart;
    public Text scoreText; //make the GUIText as private
    private int score;

    void Start()
    {
        /*GameObject scoreTextObject = GameObject.FindWithTag("ScoreText");

        if (scoreTextObject != null)
        {
            scoreText = scoreTextObject.GetComponent<Text>();
        }
        if (scoreText == null)
        {
            Debug.Log("Cannot Find 'scoreText' Script");
        }*/
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true && gameOver == false)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-SpawnValue.x, SpawnValue.x), 0.0f, SpawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

          
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
            restartText.text = "Press 'R' for Restart";
            restart = true;         

    }
}