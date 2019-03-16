using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanda : MonoBehaviour
{
    //Private static variable to store the Game Manager
    private static GameController gm;

    public GameObject pandaPrefab;
    public Transform spawner;
    public int numberOfWaves;
    public int numberOfPandaPerWave = 2;
    public int numOfPandasToDefeat;

    // Start is called before the first frame update
    void Start()
    {
        if (gm == null)
        {
            gm = FindObjectOfType<GameController>();
        }

        StartCoroutine(WavesSpawner());
    }

    //Coroutine that spawns the different waves of Pandas
    private IEnumerator WavesSpawner()
    {
        //For each wave
        for (int i = 0; i < numberOfWaves; i++)
        {
            //Let the PandaSpawner coroutine to handle the single wave. When it finishes
            //also the wave is finished, and so this coroutine can continue.
            yield return PandaSpawner();
            //Increase the number of Pandas that are generated per wave
            numberOfPandaPerWave += 3;
        }

        //If the Player won all the waves, call the GameOver function in "winning" mode
        gm.IsGameOver(true);
    }
    /// <summary>
    /// Spwns the panda in a single wave and waits until all pandas are in heaven
    /// </summary>
    /// <returns></returns>
    private IEnumerator PandaSpawner()
    {
        numOfPandasToDefeat = numberOfPandaPerWave;
        for(int i = 0; i < numberOfPandaPerWave; i++)
        {

            Instantiate(pandaPrefab, spawner.position, Quaternion.identity);
            float ratio = (i * 1f) / (numberOfPandaPerWave - 1);
            float timeToWait = Mathf.Lerp(3f, 5f, ratio) + Random.Range(0f, 2f);
            yield return new WaitForSeconds(timeToWait);
        }    
    }
}
