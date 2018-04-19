using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyByBolt : MonoBehaviour
{
    public GameObject explotion;
    private GameObject newProjectile;
    public GameObject playerExplotion;
    public int scorePoints;

    void gameController_Main()
    {
        GameController gameController = new GameController();
        gameController = GameObject.FindObjectOfType<GameController>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameController != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot Find 'GameController' script");
        }
        gameController.AddScore(scorePoints);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        newProjectile = Instantiate(explotion, transform.position, transform.rotation) as GameObject;
        if (other.tag == "Player")
        {
            newProjectile = Instantiate(playerExplotion, other.transform.position, other.transform.rotation) as GameObject;
            GameController gameController = new GameController();
            gameController = GameObject.FindObjectOfType<GameController>();
            GameObject gameControllerObject = GameObject.FindWithTag("GameController");
            if (gameController != null)
            {
                gameController = gameControllerObject.GetComponent<GameController>();
            }
            gameController.GameOver();
        }
        gameController_Main(); //this the declaration of the function gameController_Main
        Destroy(other.gameObject);
        Destroy(gameObject);

    }


}
