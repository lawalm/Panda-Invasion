using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // public Waypoint firstWaypoint;
    public Waypoint firstWaypoint;
    public GameObject losingScreen;
    public GameObject winningScreen;
    public HealthBarScript pHealth;

    //spawning
    [Header("Wave Settings")]
    public int numOfWaves;
    public int numOfPandsPerWave;
    public Transform spawner;
    public GameObject pandaPrefab;

    private int numOfEnemiesToDefeat; //win conditions

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WavesSpawner());
        Debug.Log("Spawning pandas");
    }

    //**************************PLACING TOWER REGION***********************
    private bool _canPlaceCake = true;

    public bool CanPlaceCake()
    {
        return _canPlaceCake;
    }

    private void OnMouseEnter()
    {
        _canPlaceCake = true;
    }

    private void OnMouseExit()
    {
        _canPlaceCake = false;
    }

    //*******************************GAME OVER REGION***********************
    //Private function called when some gameover conditions are met, and displays 
    //the winning or losing screen depending from the value of the parameter passed.
    public void GameOver(bool playerHasWon)
    {
        //Check if the player has won from the parameter
        if (playerHasWon)
        {
            //Display the winning screen
             winningScreen.SetActive(true);
        }
        else
        {
            //Display the loosing screen
            losingScreen.SetActive(true);
        }

        //Time.timeScale = 0;
    }

    public void OnMorePandaInHeaven()
    {
        numOfEnemiesToDefeat--;
    }

    //*************SPAWNING REGION********************
    /// <summary>
    /// Coroutine that spawns the different waves of Pandas
    /// </summary>
    /// <returns></returns>
    private IEnumerator WavesSpawner()
    {
        for(int i = 0; i < numOfWaves; i++)
        {
            yield return EnemySpawner();
            numOfPandsPerWave += 3;
        }
    }

    /// <summary>
    /// Spawns a single wave
    /// </summary>
    /// <returns></returns>
    private IEnumerator EnemySpawner()
    {
        numOfEnemiesToDefeat = numOfPandsPerWave;

        for(int i = 0; i < numOfPandsPerWave; i++)
        {
            Instantiate(pandaPrefab, spawner.position, Quaternion.identity);
            float ratio = (i * 1f) / (numOfPandsPerWave - 1);
            float timeToWait = Mathf.Lerp(3f, 5f, ratio) + Random.Range(0f, 2f);
            yield return new WaitForSeconds(timeToWait);
        }
        yield return new WaitUntil(()=> numOfPandsPerWave < 0);
    }
}
