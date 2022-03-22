using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public Bunker_Script bunker_Script;
    public EnemySpawner enemySpawner;
    Fence_Upgrade fenceUpgrade;
    int enemyBaseAmmount = 25;
    int enemyMultiplier = 2;
    public bool startRound;
    bool gameover = false;
    int waveNr = 1;
    // Start is called before the first frame update
    void Start()
    {
        bunker_Script = FindObjectOfType<Bunker_Script>().GetComponent<Bunker_Script>();
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
