using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public EnemySpawner enemySpawner;
    public bool startRound;
    bool gameover = false;
    public int enemyBaseAmmount = 3;
    public int enemyCount;
    public int waveNr = 0;
    public int enemyMultiplier = 2;
    public Bunker_Script bunker_Script;
    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    /*void Update()
    {
        if ( && startRound)
        {
            enemySpawner.ChooseEnemyAmmount(enemyBaseAmmount, waveNr, enemyMultiplier);
        }
    }*/
    void SpawnWaves()
    {

    }
}
