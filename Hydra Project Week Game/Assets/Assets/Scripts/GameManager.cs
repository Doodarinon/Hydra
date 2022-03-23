using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public BunkerScript bunkerScript;
    public EnemySpawner enemySpawner;
    int enemyBaseAmmount = 250;
    int enemyMultiplier = 2;
    public bool startRound;
    bool gameover = false;
    int waveNr = 1;
    // Start is called before the first frame update
    void Start()
    {
        bunkerScript = FindObjectOfType<BunkerScript>().GetComponent<BunkerScript>();
        enemySpawner = FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>();
       
    }
    void Update()
    {
        if (enemySpawner.enemyCount <= 0 && startRound)
        {
            SpawnWaves(); 
        }

    }
    public void SpawnWaves()
    {
        enemySpawner.ChooseEnemyAmmount(enemyBaseAmmount, waveNr, enemyMultiplier);
        enemySpawner.Randomize();
        enemySpawner.SpawnEnemys();
    }
}
