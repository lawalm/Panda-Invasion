using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class wave
{
    public GameObject enemyPrefab;
    public int numberOfWaves;
    public int numberPerWave;
}
public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] waypoints;
    public wave[] waves;
    //public GameObject testEnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(testEnemyPrefab).GetComponent<MoveEnemy>().waypoints = waypoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
