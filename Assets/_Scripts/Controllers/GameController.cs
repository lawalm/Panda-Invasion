using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController _instance;
    // public Waypoint firstWaypoint;
    public Waypoint firstWaypoint;
    public GameObject losingScreen;
    public GameObject winningScreen;
    public HealthBarScript pHealth;

    public int numberOfEnemiesToDefeat;
    public Text enemyCountTxt;

    void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("More than one GameController in scene!");
            return;
        }
        _instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        enemyCountTxt.text = "Enemies: " + numberOfEnemiesToDefeat;
        pHealth = FindObjectOfType<HealthBarScript>();
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
    public void IsGameOver(bool playerHasWon)
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
            
            DestroyAllTaggedObjects();
            losingScreen.SetActive(true);
           // Debug.Log("You lose");
        }

        //Time.timeScale = 0;
    }

    //***********TRACKING REGION***************************
   

    public void OneMorePandaInHeaven()
    {
        numberOfEnemiesToDefeat--;
        UpdateEnemyCount();
        //Debug.Log(numberOfEnemiesToDefeat);
       
        if(numberOfEnemiesToDefeat <= 0)
        {
            numberOfEnemiesToDefeat = 0;
            IsGameOver(true);
        }
    }

    public void BiteTheCake(int damage)
    {
        bool isCakeAllEaten = pHealth.ApplyDamage(damage);
        if (isCakeAllEaten)
        {
            IsGameOver(false);
        }

        OneMorePandaInHeaven();
    }

    void DestroyAllTaggedObjects()
    {
        GameObject[] taggedGO = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject taggedObject in taggedGO)
        {
            Destroy(taggedObject);
        }
    }

    public void UpdateEnemyCount()
    {
        enemyCountTxt.text = "Enemies: " + numberOfEnemiesToDefeat;
    }
}
