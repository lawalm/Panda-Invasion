using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class SpawnEnemy : MonoBehaviour
{
    public Waypoint firstWaypoint;

    //spawning
    [Header("Wave Settings")]
    public int numOfEnemiesToSpawn = 10;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    public Transform spawner;
    public GameObject pandaPrefab;
    GameController gController;

    private void Start()
    {
        gController = GameController._instance;
        StartCoroutine("EnemySpawner", numOfEnemiesToSpawn);
        gController.numberOfEnemiesToDefeat = numOfEnemiesToSpawn;
    }

    
    /// <summary>
    /// Coroutine that spawns the different waves of Pandas
    /// </summary>
    /// <returns></returns>
    private IEnumerator WavesSpawner()
    {
        yield return null;
    }

    /// <summary>
    /// Spawns a single wave
    /// </summary>
    /// <returns></returns>
    //Coroutine that spawns the pandas for a single wave, and waits until "all the pandas are in Heaven"
    private IEnumerator EnemySpawner(int number)
    {
      
        for (int i = 0; i < number; i++)
        {
            //Spawn/Instantiate a Panda at the Spawner position
            Instantiate(pandaPrefab, spawner.position, Quaternion.identity);
            //Wait a time that depends both on how many pandas are left to be
            //spawned and by a random number
            float ratio = (i * 1f) / (number - 1);
            float timeToWait = Mathf.Lerp(minSpawnTime, maxSpawnTime, 1 - ratio);
            yield return new WaitForSeconds(timeToWait);
        }
    }

}
