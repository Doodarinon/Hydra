using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{

    public Bunker_Script bunker_Script;
    public EnemySpawner enemySpawner;
    public int enemyBaseAmmount = 3;
    public int enemyMultiplier = 2;
    public bool startRound;
    bool gameover = false;
    public int waveNr = 1;
    // Start is called before the first frame update
    void Start()
    {

       
    }
<<<<<<< Updated upstream

    // Update is called once per frame
    /*void Update()
=======
    void Update()
>>>>>>> Stashed changes
    {
        if (enemySpawner.enemyCount <= 0 && startRound)
        {
            SpawnWaves(); 
        }
<<<<<<< Updated upstream
    }*/
    void SpawnWaves()
=======
    }
    public void SpawnWaves()
>>>>>>> Stashed changes
    {
        enemySpawner.ChooseEnemyAmmount(enemyBaseAmmount, waveNr, enemyMultiplier);
        enemySpawner.Randomize();
        enemySpawner.SpawnEnemys();
    }
}
