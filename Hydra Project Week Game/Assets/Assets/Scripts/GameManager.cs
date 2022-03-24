using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public BunkerScript bunkerScript;
    public EnemySpawner enemySpawner;
    FenceUpgrade fenceUpgrade;
    int enemyBaseAmmount = 50;
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


    }
    public void SpawnWaves()
    {
        if (enemySpawner.enemyCount <= 0)
        {
            enemySpawner.ChooseEnemyAmmount(enemyBaseAmmount, waveNr, enemyMultiplier);
            enemySpawner.Randomize();
            enemySpawner.SpawnEnemys();
        }
    }
}
